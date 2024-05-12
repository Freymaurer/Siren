﻿module Index.JS

open System
open System.IO
open System.Text.RegularExpressions

let private getAllJsFiles(path: string) = 
    Util.getAllFiles(path,"*.js")

let private pattern (className: string) = sprintf @"^export class (?<ClassName>%s)+[\s{].*({)?" className

let private findJsClasses (rootPath: string) (whiteList: string []) (filePaths: string []) = 
    Util.findClasses rootPath whiteList pattern filePaths

open System.Text

let private createImportStatements (info: (string*string) []) =
    let sb = StringBuilder()
    let importCollection = info |> Array.groupBy snd |> Array.map (fun (p,a) -> p, a |> Array.map fst )
    for filePath, imports in importCollection do
        let p = filePath.Replace("\\","/")
        sb.Append "export { " |> ignore
        sb.AppendJoin(", ", imports) |> ignore
        sb.Append " } from " |> ignore
        sb.Append (sprintf "\"./%s\"" p) |> ignore
        sb.Append ";" |> ignore
        sb.AppendLine() |> ignore
    sb.ToString()

let private generateIndexfile (rootPath: string, fileName: string, whiteList: string []) =
    getAllJsFiles(rootPath)
    |> findJsClasses rootPath whiteList
    |> createImportStatements
    |> Util.writeIndexFile rootPath fileName

let generate(rootPath: string) = 
    generateIndexfile(rootPath, "index.js", WhiteList.WhiteList)