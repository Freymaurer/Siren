module Build.Test.Python

open SimpleExec
open BlackFox.CommandLine
open Build

[<LiteralAttribute>]
let private outDir = "py"
let private entryPoint = System.IO.Path.Combine([|outDir; "main.py"|])

let handle (args: string list) =
    let isWatch = args |> List.contains "--watch"

    let runArg =
        if isWatch then
            "--runWatch"
        else
            "--run"

    Command.Run(
        "dotnet",
        CmdLine.empty
        |> CmdLine.appendRaw "fable"
        |> CmdLine.appendPrefix "--outDir" outDir
        |> CmdLine.appendPrefix "--lang" "python"
        |> CmdLine.appendRaw "--noCache"
        |> CmdLine.appendIf isWatch "--watch"
        |> CmdLine.appendRaw runArg
        |> CmdLine.appendRaw "python"
        |> CmdLine.appendRaw entryPoint
        |> CmdLine.appendRaw "--silent"
        |> CmdLine.toString,
        workingDirectory = ProjectInfo.TestPaths.CoreDirectory
    )
