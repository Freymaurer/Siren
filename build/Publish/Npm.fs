module Publish.Npm

open SimpleExec
open BlackFox.CommandLine
open Build

open System.IO

let private publish =
    CmdLine.empty
    |> CmdLine.appendRaw "publish"
    |> CmdLine.toString

let private publishDryRun =
    CmdLine.empty
    |> CmdLine.appendRaw "publish"
    |> CmdLine.appendRaw "--dry-run"
    |> CmdLine.toString

open System.Text.RegularExpressions

let private updateVersion =
    printfn "Updating version in package.json (%s)" ProjectInfo.Version
    let pattern = "\"version\":\s?\"(?<versions>.*)\""
    let regex = Regex(pattern)
    let file = File.ReadAllText(ProjectInfo.PackageJSON)
    let updatedFile = regex.Replace(file, $"\"version\": \"{ProjectInfo.Version}\"")
    File.WriteAllText(ProjectInfo.PackageJSON, updatedFile)

open System

let Main() = 
    updateVersion
    Command.Run("npm",publishDryRun)
    printfn "Ready to publish version %s to npm. Continue? (y/n)" ProjectInfo.Version
    match Console.ReadLine() with
    | "y" ->
        Command.Run("npm", publish)
        printfn "YEAH!"
    | _ -> printfn "Aborted"