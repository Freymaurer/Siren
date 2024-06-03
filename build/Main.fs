module Build.Main

// This is a basic help message, as the CLI parser is not a "real" CLI parser
// For now, it is enough as this is just a dev tool
let printHelp () =
    let helpText =
        """
Usage: dotnet run <command> [<args>]

Available commands:
    test                            Run the main tests suite
        Subcommands:
            f#                      Run f# tests in `Core`
            c#                      Run c# tests in `CSharp`
            js                      Run the js transpiled tests
            js native               Run the native mocha tests
            py                      Run the py transpiled tests
            py native               Run the native pytest tests

    bundle
        Subcommands:
            ts                      Bundle the TypeScript package
            py                      Bundle the Python package
            f#                      Bundle the F# package
            c#                      Bundle the C# package

    Publish
        Subcommands:
            full                    Run all tests, bundle all packages and publish all packages
            npm                     Publish the npm package
            pypi                    Publish the pypi package
            nuget                   Publish the nuget package

    codegen                         Print active class to console

    index
        Subcommands:
            js                      Generate the js index file
            py                      Generate the py index file
"""

    printfn $"%s{helpText}"

[<EntryPoint>]
let main argv =
    let argv = argv |> Array.map (fun x -> x.ToLower()) |> Array.toList

    match argv with
    | "test" :: args ->
        match args with
        | "f#" :: args -> Test.FSharp.handle args
        | "c#" :: args -> Test.CSharp.handle args
        | "js" :: "native" :: args -> 
            Test.JavaScript.handleNative args
        | "js" :: args -> Test.JavaScript.handle args
        | "py" :: "native" :: args -> Test.Python.handleNative args
        | "py" :: args -> Test.Python.handle args
        | [] | "all" :: _ -> 
            Test.FSharp.handle []
            Test.CSharp.handle args
            Test.JavaScript.handle []
            Test.Python.handle []
            Test.Python.handleNative args
            Test.JavaScript.handleNative args
        | _ -> printHelp ()
    | "bundle" :: args ->
        match args with
        | "ts" :: _ -> 
            Bundle.TypeScript.Main(ProjectInfo.Packages.JS)
        | "py" :: _ ->
            Bundle.Python.Main(ProjectInfo.Packages.PY)
        | "f#" :: _ ->
            Bundle.Net.Main(ProjectInfo.Projects.Siren, ProjectInfo.Packages.FSHARP)
        | "c#" :: _ ->
            Bundle.Net.Main(ProjectInfo.Projects.SirenSea, ProjectInfo.Packages.CSHARP)
        | _ -> printHelp ()
    | "publish" :: args ->
        match args with
        | "full" :: _ ->
            // test
            Test.FSharp.handle []
            Test.CSharp.handle args
            Test.JavaScript.handle []
            Test.Python.handle []
            Test.Python.handleNative args
            Test.JavaScript.handleNative args
            // bundle
            Bundle.TypeScript.Main(ProjectInfo.Packages.JS)
            Bundle.Python.Main(ProjectInfo.Packages.PY)
            Bundle.Net.Main(ProjectInfo.Projects.Siren, ProjectInfo.Packages.FSHARP)
            Bundle.Net.Main(ProjectInfo.Projects.SirenSea, ProjectInfo.Packages.CSHARP)
            // publish
            Publish.Npm.Main()
            Publish.PyPi.Main()
            Publish.Nuget.Main(ProjectInfo.Packages.FSHARP)
            Publish.Nuget.Main(ProjectInfo.Packages.CSHARP)
        | "npm" :: _ -> 
            Publish.Npm.Main()
        | "pypi" :: _ -> 
            Publish.PyPi.Main()
        | "nuget" :: _ -> 
            Publish.Nuget.Main(ProjectInfo.Packages.FSHARP)
            Publish.Nuget.Main(ProjectInfo.Packages.CSHARP)
        | _ -> printHelp ()
    | "codegen" :: _ ->
        printfn "STARTING CODEGEN..."
        CodeGen.test() 
        printfn "ENDING CODEGEN..."
    | "index" :: args ->
        match args with
        | "js" :: _ -> 
            Index.JS.generate @"C:\Users\Kevin\source\repos\Siren\tests\JavaScript\siren" false
        | "py" :: _ -> 
            Index.PY.generate @"C:\Users\Kevin\source\repos\Siren\tests\Python\siren" 
        | _ -> printHelp ()
    | _ -> printHelp ()

    0