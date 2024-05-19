module CodeGen

open System
open System.Reflection
open System.Reflection

[<LiteralAttribute>]
let FSharpOptionDefault = "Optional<string>"

let transformParameterTypeName (paramTypeName: string)=
    match paramTypeName with
    | "String" -> "string"
    | "Int32" -> "int"
    | "Double" -> "double"
    | "FSharpOption`1" -> FSharpOptionDefault // this is not always true but a good approximation
    | "Tuple`2" -> "(string,string)"
    | "Boolean" -> "bool"
    | _ -> paramTypeName

type ParameterInfo = {
    Type: string
    Name: string
} with
    member this.FSharpParam =
        match this with
        | {Type = FSharpOptionDefault} -> this.Name + ".ToOption()"
        | _ -> this.Name
    member this.CSharpParam =
       match this with
       | {Type = FSharpOptionDefault} -> sprintf "%s %s = default" this.Type this.Name
       | _ -> sprintf "%s %s" this.Type this.Name

    static member create(typeName: string, name: string) =
        {Type = transformParameterTypeName typeName; Name = name}

let generateCSharpCode<'A>() =

    let t = typeof<'A>
    let members = t.GetMethods(BindingFlags.Static ||| BindingFlags.Public)

    let mutable csharpCode = sprintf "public static class %s\n{\n" t.Name
    for m in members do
        let methodName = 
            let name0 = m.Name
            if name0.StartsWith("get_") then
                name0.Substring(4)
            else
                name0
        let returnType = m.ReturnType.Name
        let params0 = 
            m.GetParameters() 
            |> Array.map (fun p -> ParameterInfo.create(p.ParameterType.Name, p.Name))
        let csharpParameters =
            if params0.Length = 0 then
                ""
            else    
                params0
                |> Array.map _.CSharpParam
                |> String.concat(", ")
                |> fun s -> "(" + s + ")"
        
        let fsharpParameters = 
            if params0.Length = 0 then
                ""
            else    
                params0 
                |> Array.map _.FSharpParam
                |> String.concat(", ")
                |> fun s -> "(" + s + ")"
        
        let methodSignature = $"public static {transformParameterTypeName returnType} {methodName}{csharpParameters}"
        let methodBody = 
            if methodName.StartsWith("get_") then
                let withoutGet = methodName.Substring(4)
                $"return Siren.{t.Name}.{withoutGet};"
            else
                $" => Siren.{t.Name}.{methodName}{fsharpParameters};"
        csharpCode <- csharpCode + $"    {methodSignature}\n        {methodBody}\n"

    csharpCode <- csharpCode + "}\n"
    csharpCode

let test() = 
    generateCSharpCode<Siren.classDiagram>()
    |> printfn "%A"
    //for memberInfo in staticMembersInfo do
    //    let name, parameters, returnType = memberInfo
    //    printfn "Member Name: %s | Parameters: %A | Return Type: %s" name parameters returnType