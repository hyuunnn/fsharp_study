namespace StudentScoresSchool

module SchoolCodes = 

    open System.IO
    open System.Collections.Generic

    let load (filePath : string) =
        //let pairs = 
        //    File.ReadAllLines filePath
        //    |> Seq.skip 1
        //    |> Seq.map (fun row ->
        //            let elements = row.Split('\t')
        //            let id = elements.[0] |> int
        //            let name = elements.[1]
        //            KeyValuePair.Create(id, name))
        //new Dictionary<int, string>(pairs) // 값 변경 가능 (mutable)
        //new Dictionary<_, _>(pairs) // 값 변경 가능 (mutable)
        
        File.ReadAllLines filePath
        |> Seq.skip 1
        |> Seq.map (fun row ->
            let elements = row.Split('\t')
            let id = elements.[0] |> int
            let name = elements.[1]
            id, name)
        |> dict // 값 변경 불가 (immutable)