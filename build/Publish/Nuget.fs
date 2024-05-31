module Publish.Nuget

open SimpleExec
open BlackFox.CommandLine
open Build

open System
open System.IO

let private publish(path: string) =
    let key = Environment.GetEnvironmentVariable(ProjectInfo.Keys.Nuget, EnvironmentVariableTarget.User)
    CmdLine.empty
    |> CmdLine.appendRaw "nuget"
    |> CmdLine.appendRaw "push"
    |> CmdLine.appendRaw (path + "\*.nupkg")
    |> CmdLine.appendPrefix "-s" "https://api.nuget.org/v3/index.json"
    |> CmdLine.appendPrefix "--api-key" key
    |> CmdLine.appendRaw "--skip-duplicate"
    |> CmdLine.toString

open System

let Main(path) = 
    printfn "Ready to publish version %s to nuget. Continue? (y/n)" ProjectInfo.Version
    match Console.ReadLine() with
    | "y" ->
        Command.Run("dotnet", publish path)
        printfn "YEAH!"
    | _ -> printfn "Aborted"