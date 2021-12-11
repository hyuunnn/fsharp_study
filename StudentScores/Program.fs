open System
open System.IO

let printMeanScore (row : string) =
    let elements = row.Split('\t')
    let name = elements.[0]
    let id = elements.[1]
    let meanScore = 
        elements
        |> Array.skip 2
        // |> Array.map float
        // |> Array.average
        |> Array.averageBy float

    let scores = 
        elements
        |> Array.skip 2
        |> Array.map float

    // let meanScore = scores |> Array.average
    let minScore = scores |> Array.min
    let maxScore = scores |> Array.max
    printfn "%s\t%s\t%0.2f\t%0.2f\t%0.2f" name id meanScore minScore maxScore

let summarize filePath = 
    let rows = File.ReadAllLines filePath
    let studentCount = rows.Length - 1
    printfn "Student count %i" studentCount
    rows
    |> Array.skip 1
    |> Array.iter printMeanScore

[<EntryPoint>]
// StudentScores.txt
let main argv =
    if argv.Length = 1 then
        let filePath = argv.[0]
        if IO.File.Exists filePath then
            printfn "Processing %s" filePath
            summarize filePath
            0
        else
            printfn "File not found: %s" filePath
            2
    else
        printfn "Please specify a file"
        1