module Build.ProjectInfo

open System.IO
open Build.Utils
open Build.Utils.Path

let root = Path.Resolve()

module ProjectDir =

    let [<Literal>] TestFolder = "./tests"
    let [<Literal>] PackageFolder = "./pkg"

    module Packages =

        let NET = Path.Resolve(PackageFolder, "NET")

    module Tests =

        let NET = TestFolder

module Fsproj =

    module Tests =

        let NET =
            Path.Combine(
                ProjectDir.Tests.NET,
                "Siren.Tests.fsproj"
            )
