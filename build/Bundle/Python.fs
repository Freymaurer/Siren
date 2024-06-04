module Bundle.Python

open SimpleExec
open BlackFox.CommandLine
open Build

open System.IO
open Utils.Path.Operators

let private clean(pyPath: string) =
    if Directory.Exists pyPath then
        Directory.Delete(pyPath, true)

let private transpileFSharp(pyPath) =
    CmdLine.empty
    |> CmdLine.appendRaw "fable"
    // |> CmdLine.appendIf isWatch "--watch"
    |> CmdLine.appendRaw ProjectInfo.Projects.Siren
    |> CmdLine.appendPrefix "-o" pyPath
    |> CmdLine.appendRaw "--noCache"
    |> CmdLine.appendPrefix "--lang" "py"
    |> CmdLine.appendPrefix "--fableLib" "fable-library"
    |> CmdLine.appendRaw "--noReflection"
    |> CmdLine.toString

let private copyMetadata(pyPath) =
    File.Copy(ProjectInfo.PyprojectTOML, Path.Combine(pyPath, "pyproject.toml"))
    File.Copy(ProjectInfo.README, Path.Combine(pyPath, "README.md"))

let private peotryBundle =
    CmdLine.empty
    |> CmdLine.appendPrefix "-m" "poetry"
    |> CmdLine.appendRaw "build"
    |> CmdLine.toString

let Main(pyDir: string) = 
    let publishDir = pyDir </> "siren_dsl"
    clean(pyDir)
    Command.Run("dotnet", transpileFSharp publishDir)
    Index.PY.generate publishDir "__init__.py"
    copyMetadata pyDir
    Command.Run("python", peotryBundle, workingDirectory=pyDir)