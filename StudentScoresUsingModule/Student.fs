namespace StudentScores

type Student =
    {
        Surname : string
        GivenName : string
        Id : string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }

module Student = // F#의 module은 Class 역할인 것 같다.

    let nameParts (s : string) =
        let elements = s.Split(',')
        match elements with
        | [|surname; givenName|] ->
            // surname.Trim(), givenName.Trim()

            // anonymous records
            {| Surname = surname.Trim()
               GivenName = givenName.Trim() |}
        | [|surname|] ->
            // surname.Trim(), "(None)"

            // anonymous records
            {| Surname = surname.Trim()
               GivenName = "(None)" |}
        | _ ->
            raise (System.FormatException(sprintf "Invalid name format: \"%s\"" s))

    let namePart i (s : string) = 
        let elements = s.Split(',')
        elements.[i].Trim()

    let fromString (s : string) =
        let elements = s.Split('\t')

        //let name = elements.[0]
        //let given = namePart 1 name
        //let sur = namePart 0 name
        //let sur, given = name |> nameParts
        let name = elements.[0] |> nameParts

        let id = elements.[1]
        let scores =
            elements
            |> Array.skip 2
            //|> Array.map (fun s -> Float.fromStringOrNum(50.0, s)) // Enable -> StudentScoresNA.txt
            |> Array.map TestResult.fromString // Enable -> StudentScoresAE.txt
            |> Array.choose TestResult.tryEffectiveScore // Enable -> StudentScoresAE.txt

        let meanScore = scores |> Array.average
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
        {
            Surname = name.Surname
            GivenName = name.GivenName
            Id = id
            MeanScore = meanScore
            MinScore = minScore
            MaxScore = maxScore
        }

    let printSummary (student : Student) =
        printfn "%s, %s\t%s\t%0.2f\t%0.2f\t%0.2f" student.Surname student.GivenName student.Id student.MeanScore student.MinScore student.MaxScore