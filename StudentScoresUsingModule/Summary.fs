namespace StudentScores

module Summary = 

    open System.IO

    let summarize filePath = 
    
        let rows = File.ReadAllLines filePath
        let studentCount = rows.Length - 1
        printfn "Student count %i" studentCount
        rows
        |> Array.skip 1
        // Convert each line to a Student instance
        |> Array.map Student.fromString
        // Sort by mean score (descending)
        |> Array.sortByDescending (fun student -> student.MeanScore) // lambda - 내림차순 MeanScore
        //|> Array.sortBy (fun student -> student.Name) // lambda - 오름차순 이름 순서
        // Print each Student instance
        |> Array.iter Student.printSummary
