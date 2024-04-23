namespace Siren

[<RequireQualifiedAccess>]
module Yaml =

    open System.Text

    type Config = {
        Whitespace: int
        Level: int
    } with
        static member init(?whitespace) : Config = {
            Whitespace = defaultArg whitespace 4
            Level = 0
        }
        member this.WhitespaceString =
            String.init (this.Level*this.Whitespace) (fun _ -> " ")
    
    type AST =
        | Root of AST list
        | Level of AST list
        | Line of string

        static member write(rootElement:AST, ?fconfig: Config -> Config) =
            let config = Config.init() |> fun config -> if fconfig.IsSome then fconfig.Value config else config
            let sb = new StringBuilder()
            let rec loop (current: AST) (sb: StringBuilder) (config: Config) =
                match current with
                | Line line ->
                    sb.AppendLine(config.WhitespaceString+line) |> ignore
                | Level children ->
                    let nextConfig = {config with Level = config.Level + 1}
                    for child in children do
                        loop child sb nextConfig
                | Root children ->
                    for child in children do
                        loop child sb config
            loop rootElement sb config
            sb.ToString()
            

    let line (line:string) = Line line

    let level (children: #seq<AST>) = List.ofSeq children |> Level 

    let root (children: #seq<AST>) = List.ofSeq children |> Root

    let write rootElement = AST.write(rootElement)

type IYamlConvertible =
    abstract ToYamlAst: unit -> Yaml.AST list