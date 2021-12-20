open System
open Bricks

[<EntryPoint>]
let main argv =

    let bricks =

        //Seq {
        [|
            do printfn "Creating elements"
            (3, 2, ConsoleColor.Yellow)
            (4, 2, ConsoleColor.Green)
            (2, 1, ConsoleColor.Magenta)
            (1, 1, ConsoleColor.Blue)
            (2, 2, ConsoleColor.Red)
            (4, 2, ConsoleColor.Blue)
            (4, 2, ConsoleColor.Magenta)
            (2, 2, ConsoleColor.Magenta)
            (2, 2, ConsoleColor.Red)
            (4, 2, ConsoleColor.Blue)
            (3, 2, ConsoleColor.Magenta)
            (4, 2, ConsoleColor.Green)
            (3, 2, ConsoleColor.Red)
            (4, 1, ConsoleColor.Blue)
            (4, 2, ConsoleColor.Yellow)
            (4, 2, ConsoleColor.Yellow)
            (1, 1, ConsoleColor.Blue)
            (1, 1, ConsoleColor.Green)
            (2, 1, ConsoleColor.Yellow)
            (4, 1, ConsoleColor.Magenta)
        |]
        //}
        |> Array.map (fun (sc, sr, cc) -> { StudColumns = sc; StudRows = sr; Color = cc })
        
        //|> Seq.map (fun (sc, sr, cc) -> { StudColumns = sc; StudRows = sr; Color = cc })
        //|> Seq.cache

        //|> Array.ofSeq - Array 타입에서 sequences로 사용할 수 있게 해줌
          // ...or Seq.toArray - 위와 반대의 경우

    printfn "All the bricks:"
    bricks
    |> Array.iter (Brick.printConsole)
    //|> Seq.iter (Brick.printConsole)
    printfn "\n"

    printfn "Count of the bricks:"
    let count = bricks |> Array.length
    printfn "Count: %i\n" count

    printfn "Stud counts:"
    bricks
    |> Array.map (fun b -> b.StudColumns * b.StudRows)
    |> Array.iter (fun c -> printf "%i;" c)
    printfn "\n"

    printfn "Red bricks (Array filter):"
    bricks
    |> Array.filter (fun b -> b.Color = ConsoleColor.Red)
    |> Array.iter Brick.printConsole
    printfn "\n"

    printfn "Grouped by color (Array.groupBy):"
    let groupedByColor = 
        bricks
        |> Array.groupBy (fun b -> b.StudColumns * b.StudRows)

    groupedByColor
    //|> Array.sortByDescending (fun (studCount, _) -> studCount)
    |> Array.sortByDescending fst

    |> Array.iter (fun (studCount, bricks) ->
        printfn "%i stud:" studCount
        bricks
        |> Array.iter Brick.printConsole
        printfn "")
    printfn ""

    0 