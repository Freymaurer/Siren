module Publish.PyPi

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
    printfn "Updating version in pyproject.toml (%s)" ProjectInfo.Version
    let pattern = "version = \"0.1.0\""
    let regex = Regex(pattern)
    let file = File.ReadAllText(ProjectInfo.PyprojectTOML)
    let updatedFile = regex.Replace(file, $"version = \"{ProjectInfo.Version}\"")
    File.WriteAllText(ProjectInfo.PackageJSON, updatedFile)

open System

let Main() = 
    updateVersion
    printfn "Ready to publish version %s to PyPi. Continue? (y/n)" ProjectInfo.Version
    match Console.ReadLine() with
    | "y" ->
        printfn "YEAH!"
    | _ -> printfn "Aborted"