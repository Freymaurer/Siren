module Build.Test.JavaScript

open SimpleExec
open BlackFox.CommandLine
open Build

[<LiteralAttribute>]
let private outDir = "js"
let private entryPoint = System.IO.Path.Combine([|outDir; "main.js"|])

let handleNative (args: string list) =
    let isWatch = args |> List.contains "--watch"
    let isFast = args |> List.contains "--fast"

    let mochaComand =
        CmdLine.empty
        |> CmdLine.appendRaw "mocha"
        // |> CmdLine.appendIf isWatch "--watch"
        |> CmdLine.appendRaw ProjectInfo.TestPaths.JSNativeDirectory
        |> CmdLine.toString

    let fableArgs =
        CmdLine.concat
            [
                CmdLine.empty
                |> CmdLine.appendRaw "fable"
                |> CmdLine.appendRaw ProjectInfo.Projects.Siren
                |> CmdLine.appendPrefix "--outDir" (ProjectInfo.TestPaths.JSNativeDirectory + "/siren")
                |> CmdLine.appendRaw "--noCache"

                if isWatch then
                   CmdLine.empty
                   |> CmdLine.appendRaw "--watch"
                   |> CmdLine.appendRaw "--runWatch"
                   |> CmdLine.appendRaw "npx"
                   |> CmdLine.appendRaw mochaComand
                else
                   CmdLine.empty
                   |> CmdLine.appendRaw "--run"
                   |> CmdLine.appendRaw "npx"
                   |> CmdLine.appendRaw mochaComand
            ]
        |> CmdLine.toString
    if isFast then
        Command.Run(
          "npx",
          mochaComand
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
        |> CmdLine.appendPrefix "--outDir" outDir
        |> CmdLine.appendRaw "--noCache"
        |> CmdLine.appendIf isWatch "--watch"
        |> CmdLine.appendRaw runArg
        |> CmdLine.appendRaw "node"
        |> CmdLine.appendRaw entryPoint
        |> CmdLine.appendRaw "--silent"
        |> CmdLine.toString,
        workingDirectory = ProjectInfo.TestPaths.CoreDirectory
    )
