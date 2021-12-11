open System

let quote symbol s = 
    sprintf "%c%s%c" symbol s symbol

let singleQuote = quote '\''
let doubleQuote = quote '"'

let add a b = 
    a + b

let c = add 2 3
let d = add 2
let e = d 4

[<EntryPoint>]
let main argv =
    printfn "e: %i" e

    printfn "%s" (singleQuote "It was the beat of times, it was the worst of times.")
    printfn "%s" (doubleQuote "It was the beat of times, it was the worst of times.")
    0