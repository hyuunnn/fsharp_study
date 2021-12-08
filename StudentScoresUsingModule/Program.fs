open System
open System.IO

type Student =
    {
        Name : string
        Id : string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }

module Student = // F#의 module은 Class 역할인 것 같다.

    let fromString (s : string) =
        let elements = s.Split('\t')
        let name = elements.[0]
        let id = elements.[1]
        let scores =
            elements
            |> Array.skip 2
            |> Array.map float
        let meanScore = scores |> Array.average
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max

        {
            Name = name
            Id = id
            MeanScore = meanScore
            MinScore = minScore
            MaxScore = maxScore
        }

    let printSummary (student : Student) =
        printfn "%s\t%s\t%0.2f\t%0.2f\t%0.2f" student.Name student.Id student.MeanScore student.MinScore student.MaxScore

let summarize filePath = 
    let rows = File.ReadAllLines filePath
    let studentCount = rows.Length - 1
    printfn "Student count %i" studentCount
    rows
    |> Array.skip 1
    |> Array.map Student.fromString
    |> Array.sortByDescending (fun student -> student.MeanScore) // lambda - 내림차순 MeanScore
    //|> Array.sortBy (fun student -> student.Name) // lambda - 오름차순 이름 순서
    |> Array.iter Student.printSummary

[<EntryPoint>]
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