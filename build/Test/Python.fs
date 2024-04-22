module Build.Test.Python

open SimpleExec
open BlackFox.CommandLine
open Build

let private outDir = System.IO.Path.Combine [|ProjectInfo.TestPaths.CoreDirectory; "py"|]
let private entryPoint = System.IO.Path.Combine([|outDir; "main.py"|])

let python = @".venv\Scripts\python.exe"

let handleNative (args: string list) =
    let isWatch = args |> List.contains "--watch"
    let isFast = args |> List.contains "--fast"
    let pytestCommand =
        CmdLine.empty
        |> CmdLine.appendRaw "-m pytest"
        |> CmdLine.appendRaw ProjectInfo.TestPaths.PyNativeDirectory
        |> CmdLine.toString

    let fableArgs =
        CmdLine.concat
            [
                CmdLine.empty
                |> CmdLine.appendRaw "fable"
                |> CmdLine.appendRaw ProjectInfo.Projects.Siren
                |> CmdLine.appendPrefix "--outDir" (ProjectInfo.TestPaths.PyNativeDirectory + "/siren")
                |> CmdLine.appendPrefix "--lang" "python"
                |> CmdLine.appendRaw "--noCache"

                if isWatch then
                   CmdLine.empty
                   |> CmdLine.appendRaw "--watch"
                   |> CmdLine.appendRaw "--runWatch"
                   |> CmdLine.appendRaw python
                   |> CmdLine.appendRaw pytestCommand
                else
                   CmdLine.empty
                   |> CmdLine.appendRaw "--run"
                   |> CmdLine.appendRaw python
                   |> CmdLine.appendRaw pytestCommand
            ]
        |> CmdLine.toString
    if isFast then
        Command.Run(
          python,
          pytestCommand
        )
    else
        Command.Run(
            "dotnet",
            fableArgs
        )

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
        |> CmdLine.appendRaw ProjectInfo.TestPaths.CoreDirectory
        |> CmdLine.appendPrefix "--outDir" outDir
        |> CmdLine.appendPrefix "--lang" "python"
        |> CmdLine.appendRaw "--noCache"
        |> CmdLine.appendIf isWatch "--watch"
        |> CmdLine.appendRaw runArg
        |> CmdLine.appendRaw python
        |> CmdLine.appendRaw entryPoint
        |> CmdLine.appendRaw "--silent"
        |> CmdLine.toString
    )
