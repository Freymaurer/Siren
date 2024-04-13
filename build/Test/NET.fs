module Build.Test.NET

open SimpleExec
open BlackFox.CommandLine
open Build

let handle (args: string list) =
    let isWatch = args |> List.contains "--watch"

    let args : string =
        CmdLine.empty
        |> CmdLine.appendIf isWatch "watch"
        |> CmdLine.appendRaw "run"
        |> CmdLine.appendPrefix "--project" ProjectInfo.Projects.TestsSiren
        |> CmdLine.toString

    Command.Run(
        "dotnet",
        args
    )