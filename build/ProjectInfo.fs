module Build.ProjectInfo

open System.IO
open Build.Utils
open Build.Utils.Path

let root = Path.Resolve()

let [<Literal>] PackageFolder = "./pkg"

module TestPaths =

    let [<Literal>] BaseDirectory = "./tests"
    let [<Literal>] CoreDirectory = BaseDirectory + "/Core"
    let [<Literal>] JSNativeDirectory = BaseDirectory + "/JavaScript"
    let [<Literal>] PyNativeDirectory = BaseDirectory + "/Python"

module Packages =

    let NET = Path.Resolve(PackageFolder, "NET")

module Projects =

    let Siren = "./src/Siren.fsproj"
    let TestsSiren = System.IO.Path.Combine(TestPaths.CoreDirectory, "Siren.Tests.fsproj")
