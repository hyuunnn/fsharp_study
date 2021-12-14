open System

[<EntryPoint>]

let main argv = 


    let total = 
        //[| 
        //    for i in 1..1000 do
        //        yield i * i
        //|]
        Array.init 1000 (fun i ->
            let x = i + 1
            x * x)
        |> Array.sum
        
    let initiallyZeros = Array.zeroCreate<int> 10
    initiallyZeros.[0] <- 42

    printfn "%i" total
    printfn "%i" initiallyZeros.[0]
    0
