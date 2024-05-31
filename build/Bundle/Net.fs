module Bundle.Net

open SimpleExec
open BlackFox.CommandLine
open Build

open System.IO
open System

let private clean(targetPath: string) =
    if Directory.Exists targetPath then
        Directory.Delete(targetPath, true)

let private bundle sourcePath targetPath=
    CmdLine.empty
    |> CmdLine.append "pack"
    |> CmdLine.append sourcePath
    |> CmdLine.appendPrefix "-o" targetPath
    |> CmdLine.appendf "-p:PackageVersion=%s" ProjectInfo.Version
    |> CmdLine.toString

let Main(sourcePath, targetPath) = 
    clean(targetPath)
    Command.Run("dotnet", bundle sourcePath targetPath)