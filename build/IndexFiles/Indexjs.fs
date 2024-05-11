module Index.JS

open System
open System.IO
open System.Text.RegularExpressions

let private getAllJsFiles(path: string) = 
    let options = EnumerationOptions()
    options.RecurseSubdirectories <- true
    IO.Directory.EnumerateFiles(path,"*.js",options)

let private pattern (className: string) = sprintf @"^export class (?<ClassName>%s)+[\s{].*({)?" className

type private FileInformation = {
    FilePath : string
    Lines : string []
} with
    static member create(filePath: string, lines: string []) = {
        FilePath = filePath
        Lines = lines
    }

let private findClasses (rootPath: string) (cois: string []) (filePaths: seq<string> ) = 
    let files = [|
        for fp in filePaths do
            yield FileInformation.create(fp, System.IO.File.ReadAllLines (fp))
    |]
    let importStatements = ResizeArray()
    let findClass (className: string) = 
        /// maybe set this as default if you do not want any whitelist
        let classNameDefault = @"[a-zA-Z_0-9]"
        let regex = Regex(Regex.Escape(className) |> pattern)
        let mutable found = false
        let mutable result = None
        let enum = files.GetEnumerator()
        while not found && enum.MoveNext() do
            let fileInfo = enum.Current :?> FileInformation
            for line in fileInfo.Lines do
                let m = regex.Match(line)
                match m.Success with
                | true -> 
                    found <- true
                    result <- Some <| (className, IO.Path.GetRelativePath(rootPath,fileInfo.FilePath))
                | false ->
                    ()
        match result with
        | None ->
            failwithf "Unable to find %s" className
        | Some r ->
            importStatements.Add r
    for coi in cois do findClass coi
    importStatements
    |> Array.ofSeq

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

let private writeJsIndexfile (path: string) (fileName: string) (content: string) =
    let filePath = Path.Combine(path, fileName)
    File.WriteAllText(filePath, content)

let private generateIndexfile (rootPath: string, fileName: string, whiteList: string []) =
    getAllJsFiles(rootPath)
    |> findClasses rootPath whiteList
    |> createImportStatements
    |> writeJsIndexfile rootPath fileName

let generate(rootPath: string) = 
    let whiteList = [|
        "SirenElement"
        // ThemeVaruiables
        "quadrantTheme"; 
        "gitTheme"; 
        "timelineTheme"; 
        "xyChartTheme"; 
        // Config
        "flowchartConfig"; 
        "sequenceConfig"; 
        "ganttConfig"; 
        "journeyConfig"; 
        "timelineConfig"; 
        "classConfig"; 
        "stateConfig"; 
        "erConfig"; 
        "quadrantChartConfig"; 
        "pieConfig"; 
        "sankeyConfig"; 
        "xyChartConfig"; 
        "mindmapConfig"; 
        "gitGraphConfig"; 
        "requirementConfig"; 
        // Graphs and Helpers
        "formatting"; 
        "direction"; 
        "flowchart"; 
        "notePosition"; 
        "sequence"; 
        "memberVisibility"; 
        "memberClassifier"; 
        "classDirection"; 
        "classCardinality"; 
        "classRltsType"; 
        "classDiagram"; 
        "stateDiagram"; 
        "erKey"; 
        "erCardinality"; 
        "erDiagram"; 
        "journey"; 
        "ganttTime"; 
        "ganttTags"; 
        "ganttUnit"; 
        "gantt"; 
        "pieChart"; 
        "quadrant"; 
        "rqRisk"; 
        "rqMethod"; 
        "requirement"; 
        "gitType"; 
        "git"; 
        "mindmap"; 
        "timeline"; 
        "sankey"; 
        "xyChart"; 
        "block"; 
        "theme"; 
        "siren"; 
    |]
    generateIndexfile(rootPath, "index.js", whiteList)