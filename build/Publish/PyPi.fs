module Publish.PyPi

open SimpleExec
open BlackFox.CommandLine
open Build

open System.IO
open System

let private setAuth(token) =
    CmdLine.empty
    |> CmdLine.appendPrefix "-m" "poetry"
    |> CmdLine.appendRaw "config"
    |> CmdLine.appendRaw "pypi-token.pypi"
    |> CmdLine.appendRaw token
    |> CmdLine.toString

let private publish =
    CmdLine.empty
    |> CmdLine.appendPrefix "-m" "poetry"
    |> CmdLine.appendRaw "publish"
    |> CmdLine.toString

let private publishDryRun =
    CmdLine.empty
    |> CmdLine.appendPrefix "-m" "poetry"
    |> CmdLine.appendRaw "publish"
    |> CmdLine.appendRaw "--build"
    |> CmdLine.appendRaw "--dry-run"
    |> CmdLine.toString

open System.Text.RegularExpressions

let private updateVersion =
    printfn "Updating version in pyproject.toml (%s)" ProjectInfo.Version
    let pattern = "version = \".*\""
    let regex = Regex(pattern)
    let file = File.ReadAllText(ProjectInfo.PyprojectTOML)
    let updatedFile = regex.Replace(file, $"version = \"{ProjectInfo.Version}\"")
    File.WriteAllText(ProjectInfo.PackageJSON, updatedFile)
    File.WriteAllText(Path.Combine([|ProjectInfo.Packages.PY; "pyproject.toml"|]), updatedFile)

open System

let Main() = 
    updateVersion
    Command.Run("python", publishDryRun, workingDirectory = ProjectInfo.Packages.PY)
    printfn "Ready to publish version %s to PyPi. Continue? (y/n)" ProjectInfo.Version
    match Console.ReadLine() with
    | "y" ->
        let token = Environment.GetEnvironmentVariable(ProjectInfo.Keys.PyPi, EnvironmentVariableTarget.User)
        Command.Run("python", setAuth token)
        Command.Run("python", publish, workingDirectory = ProjectInfo.Packages.PY)
        printfn "YEAH!"
    | _ -> printfn "Aborted"