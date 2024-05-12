module Test.CSharp

open SimpleExec
open BlackFox.CommandLine
open Build

let handle (args: string list) =
    let isWatch = args |> List.contains "--watch"

    let args : string =
        CmdLine.empty
        |> CmdLine.appendIf isWatch "watch"
        |> CmdLine.appendRaw "test"
        |> CmdLine.append ProjectInfo.Projects.TestsSirenSea
        |> CmdLine.toString

    Command.Run(
        "dotnet",
        args
    )