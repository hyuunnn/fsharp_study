open System

let sayHello person = 
    printfn "Hello %s from my F# Program" person

let isValid person = 
    String.IsNullOrWhiteSpace person |> not

let isAllowed person = 
    person <> "Eve"

[<EntryPoint>]
let main argv =
    let person = 
        if argv.Length > 0 then
            argv.[0]
        else
            "Anonymous Person"
    printfn "Hello %s from my F# program!" person
    
    let mutable person = "Anonymous Person"
    if argv.Length > 0 then
        person <- argv.[0]
    printfn "Hello %s from my F# program!" person
    
    //for i in 0..argv.Length-1 do
    for person in argv do
        printfn "Hello %s from my F# program" person
    
    Array.iter sayHello argv
    printfn "Nice to meet you."

    ///////// pipeing
    
    let validNames = argv |> Array.filter isValid
    validNames |> Array.iter sayHello
    
    argv 
    |> Array.filter isValid 
    |> Array.filter isAllowed
    |> Array.iter sayHello
    printfn "Nice to meet you."
    0