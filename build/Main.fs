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
            placeholder1            Run the tests for the legacy version
            placeholder2            Run the tests for JavaScript
            placeholder3            Run the tests for Newtonsoft
            placeholder4            Run the tests for Python

        Options for all except integration and standalone:
            --plh                   Watch for changes and re-run the tests
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
    | "examples" :: _ ->
        Examples.Flowchart.writeMoonRocketExample()
        Examples.EntityRelationshipDiagram.writeCarExample()
    | "codegen" :: args ->
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