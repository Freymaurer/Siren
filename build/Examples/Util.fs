module Build.Examples.Util

let mkMardownCommentOpen (name: string) = sprintf "<!--%s-->" name
let mkMardownCommentClose (name: string) = sprintf "<!--%s-End-->" name

open Build.Utils.Path

let ReadMePath = Path.Resolve("./README.md")

let writeExample(key:string, replacement: string) =
    printfn "START with %s" key
    let startMarker = mkMardownCommentOpen key
    let endMarker = mkMardownCommentClose key
    let content = System.IO.File.ReadAllText(ReadMePath, System.Text.Encoding.UTF8)
    let startIndex = content.IndexOf(startMarker) + startMarker.Length
    let endIndex = content.IndexOf(endMarker, startIndex)
    if startIndex >= startMarker.Length && endIndex >= startIndex then
        let prefix = content.Substring(0, startIndex)
        let suffix = content.Substring(endIndex)
        prefix + replacement + suffix
    else
        content
    |> fun c -> System.IO.File.WriteAllText(ReadMePath, c)
    printfn "DONE with %s" key

