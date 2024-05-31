module Bundle.TypeScript

open SimpleExec
open BlackFox.CommandLine
open Build

open System.IO

let private clean(jspath: string) =
    if Directory.Exists jspath then
        Directory.Delete(jspath, true)
    if Directory.Exists ProjectInfo.Packages.TS then
        Directory.Delete(ProjectInfo.Packages.TS, true)

let private transpileFSharp =
    CmdLine.empty
    |> CmdLine.appendRaw "fable"
    // |> CmdLine.appendIf isWatch "--watch"
    |> CmdLine.appendRaw ProjectInfo.Projects.Siren
    |> CmdLine.appendPrefix "-o" ProjectInfo.Packages.TS
    |> CmdLine.appendRaw "--noCache"
    |> CmdLine.appendPrefix "--lang" "ts"
    |> CmdLine.appendPrefix "--fableLib" "fable-library"
    |> CmdLine.appendRaw "--noReflection"
    |> CmdLine.toString

let private transpileTypeScript(jsPath) =
    CmdLine.empty
    |> CmdLine.appendRaw "tsc"
    |> CmdLine.appendPrefix "--outDir" jsPath
    |> CmdLine.appendRaw "--declaration"
    |> CmdLine.appendPrefix "--noEmit" "false"
    |> CmdLine.toString


let Main(jsDir: string) = 
    clean(jsDir)
    Command.Run("dotnet", transpileFSharp)
    Index.JS.generate ProjectInfo.Packages.TS true
    Command.Run("npx", transpileTypeScript jsDir)