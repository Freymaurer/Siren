module Siren.Util

module Option =

    let formatString (format: string -> string) (str: string option) =
        match str with |None -> "" | Some str -> format str

    let defaultBind (mapping: 'A -> 'T) (def: 'T) (opt: 'A option) =
        match opt with
        | Some a -> mapping a
        | None -> def

module Bool =

    let toString (b: bool) =
        match b with
        | true -> "true"
        | false -> "false"