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
        | "dotnet" :: args -> Test.NET.handle args
        | "js" :: "native" :: args -> 
            Test.JavaScript.handleNative args
        | "js" :: args -> Test.JavaScript.handle args
        | "py" :: "native" :: args -> Test.Python.handleNative args
        | "py" :: args -> Test.Python.handle args
        | [] | "all" :: _ -> 
            Test.NET.handle []
            Test.JavaScript.handle []
            Test.Python.handle []
            Test.Python.handleNative args
            Test.JavaScript.handleNative args
        | _ -> printHelp ()
    | "examples" :: _ ->
        Examples.Flowchart.writeMoonRocketExample()
        Examples.ClassDiagram.writeAnimalExample()
    | _ -> printHelp ()

    0