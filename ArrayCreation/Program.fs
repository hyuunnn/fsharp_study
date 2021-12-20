open System

[<EntryPoint>]
let main argv =
    let total = 
        //seq { for i in 1..1000 -> i * i}
        //|> Seq.sum
        Seq.init 1000 (fun i ->
            let x = i + 1
            x * x)
        |> Seq.sum

    let squares = 
        Seq.initInfinite (fun i ->
            let x = i + 1
            x * x)

    let total2 = 
        squares
        |> Seq.truncate 1000
        |> Seq.sum

    printfn "%i" total
    printfn "%i" total2
    0