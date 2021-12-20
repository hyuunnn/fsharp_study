open System

module Drunkard = 
    
    let r = System.Random()

    let step() =
        r.Next(-1, 2)

    type position = { X : int; Y : int }

    let walk = 
        { X = 0; Y = 0 }
        |> Seq.unfold (fun position ->
            let x' = position.X + step()
            let y' = position.Y + step()
            let position' = { X = x'; Y = y' }
            Some(position', position'))

[<EntryPoint>]
let main argv = 

    printf "Drunkard's walk"
    Drunkard.walk
    |> Seq.take 10
    |> Seq.iter (fun p -> printfn "X: %i Y: %i" p.X p.Y)

    0