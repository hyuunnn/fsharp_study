namespace StudentScores

module Summary = 

    open System.IO

    let printGroupSummary (surname : string) (students : Student[]) =
        printfn "%s" (surname.ToUpperInvariant())
        students
        |> Array.sortBy (fun student -> student.GivenName, student.Id) // 동일한 이름이 생겼을 때 Id로 sort한다.
        |> Array.iter (fun student ->
            printfn "\t%20s\t%s\t%0.1f\t%0.1f\t%0.1f"
                student.GivenName student.Id student.MeanScore student.MinScore student.MaxScore)

    let summarize filePath = 
    
        let rows = File.ReadAllLines filePath
        let studentCount = rows.Length - 1
        printfn "Student count %i" studentCount
        rows
        |> Array.skip 1
        // Convert each line to a Student instance
        |> Array.map Student.fromString
        |> Array.groupBy (fun s -> s.Surname)
        |> Array.sortBy fst
        |> Array.iter (fun (surname, students) ->
            printGroupSummary surname students)

        (*
        // Sort by mean score (descending)
        |> Array.sortByDescending (fun student -> student.MeanScore) // lambda - 내림차순 MeanScore
        //|> Array.sortBy (fun student -> student.Name) // lambda - 오름차순 이름 순서
        // Print each Student instance
        |> Array.iter Student.printSummary
        *)
