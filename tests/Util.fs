[<AutoOpen>]
module Util

open Fable.Core
open System

module Fable =
    
    module JS =

        [<Emit("process.stdout.write($0)")>]
        let print (s:string) : unit = nativeOnly

    module Py =

        [<Emit("print($0, end = \"\")")>]
        let print (s:string) : unit = nativeOnly

    let fprint(s: string) =
        #if FABLE_COMPILER_JAVASCRIPT
        JS.print(s)
        #endif
        #if FABLE_COMPILER_PYTHON
        Py.print(s)
        #endif
        #if !FABLE_COMPILER
        printf "%s" s
        #endif

open Fable.Pyxpecto

module Expect =
    /// <summary>
    /// This function only verifies non-whitespace characters
    /// </summary>
    let stringEqual actual expected message =
        let pattern = @"\s+"
        let regex = System.Text.RegularExpressions.Regex(pattern, Text.RegularExpressions.RegexOptions.Singleline)
        let actual = regex.Replace(actual, "")
        let expected = regex.Replace(expected, "")
        let mutable isSame = true
        Seq.iter2 
            (fun s1 s2 -> 
                if isSame && s1 = s2 then 
                    ()
                elif isSame && s1 <> s2 then
                    isSame <- false
                    Fable.fprint (sprintf "%s" (string s1))
                else
                    Fable.fprint (sprintf "%s" (string s1))
            ) 
            actual 
            expected
        Expect.equal actual expected message
