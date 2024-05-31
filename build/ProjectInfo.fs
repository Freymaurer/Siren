module Build.ProjectInfo

open System.IO
open Build.Utils
open Build.Utils.Path

let root = Path.Resolve()

[<Literal>]
let Version = "0.1.0"

[<Literal>]
let PyprojectTOML = "./pyproject.toml"

[<Literal>]
let PackageJSON = "./package.json"

[<Literal>]
let README = "./README.md"

module Keys =
    
    let [<Literal>] PyPi = "PYPI_KEY"
    let [<Literal>] NPM = "NPM_KEY"
    let [<Literal>] Nuget = "NUGET_KEY"

module TestPaths =

    let [<Literal>] BaseDirectory = "./tests"
    let [<Literal>] CoreDirectory = BaseDirectory + "/Core"
    let [<Literal>] CSharpDirectory = BaseDirectory + "/CSharp"
    let [<Literal>] JSNativeDirectory = BaseDirectory + "/JavaScript"
    let [<Literal>] PyNativeDirectory = BaseDirectory + "/Python"

module Packages =

    [<Literal>]
    let PackageFolder = "./dist"

    let NET = Path.Resolve(PackageFolder, "net")
    let JS = Path.Resolve(PackageFolder, "js")
    let TS = Path.Resolve(PackageFolder, "ts")
    let PY = Path.Resolve(PackageFolder, "py")


module Projects =

    let Siren = "./src/Siren/Siren.fsproj"
    let TestsSiren = System.IO.Path.Combine(TestPaths.CoreDirectory, "Siren.Tests.fsproj")
    let TestsSirenSea = System.IO.Path.Combine(TestPaths.CSharpDirectory, "Siren.Sea.Tests.csproj")
