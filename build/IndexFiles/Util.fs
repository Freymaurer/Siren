module Index.Util

open System
open System.IO
open System.Text.RegularExpressions

type FileInformation = {
    FilePath : string
    Lines : string []
} with
    static member create(filePath: string, lines: string []) = {
        FilePath = filePath
        Lines = lines
    }

let getAllFiles(path: string, extension: string) = 
    let options = EnumerationOptions()
    options.RecurseSubdirectories <- true
    IO.Directory.EnumerateFiles(path,extension,options)
    |> Seq.filter (fun s -> s.Contains("fable_modules") |> not)
    |> Array.ofSeq

let findClasses (rootPath: string) (cois: string []) (regexPattern: string -> string) (filePaths: seq<string>) = 
    let files = [|
        for fp in filePaths do
            yield FileInformation.create(fp, System.IO.File.ReadAllLines (fp))
    |]
    let importStatements = ResizeArray()
    let findClass (className: string) = 
        /// maybe set this as default if you do not want any whitelist
        let classNameDefault = @"[a-zA-Z_0-9]"
        let pattern = Regex.Escape(className) |> regexPattern
        let regex = Regex(pattern)
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

let writeIndexFile (path: string) (fileName: string) (content: string) =
    let filePath = Path.Combine(path, fileName)
    File.WriteAllText(filePath, content)