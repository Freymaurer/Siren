module Build.Test.Python

open SimpleExec
open BlackFox.CommandLine
open Build

let private outDir = System.IO.Path.Combine [|ProjectInfo.TestPaths.CoreDirectory; "py"|]
let private entryPoint = System.IO.Path.Combine([|outDir; "main.py"|])

let python = @".venv\Scripts\python.exe"

let handleNative (args: string list) =
    let isFast = args |> List.contains "--fast"

    let pytestCommand =
        CmdLine.empty
        |> CmdLine.appendRaw "-m pytest"
        |> CmdLine.appendRaw ProjectInfo.TestPaths.PyNativeDirectory
        |> CmdLine.toString

    if isFast then
        Command.Run(
          python,
          pytestCommand
        )
    else
        let dirPath = ProjectInfo.TestPaths.PyNativeDirectory + "/siren"
        let fableTranspile =
            CmdLine.empty
            |> CmdLine.appendRaw "fable"
            |> CmdLine.appendRaw ProjectInfo.Projects.Siren
            |> CmdLine.appendPrefix "--outDir" dirPath
            |> CmdLine.appendPrefix "--lang" "python"
            |> CmdLine.appendRaw "--noCache"
            |> CmdLine.toString
        Command.Run(
            "dotnet",
            fableTranspile
        )
        Index.PY.generate dirPath "index.py"
        Command.Run(
          python,
          pytestCommand
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
