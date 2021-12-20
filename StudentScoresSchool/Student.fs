namespace StudentScoresSchool

type Student =
    {
        Surname : string
        GivenName : string
        Id : string
        SchoolName : string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }

module Student = // F#의 module은 Class 역할인 것 같다.

    open System.Collections.Generic

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

    let fromString (schoolCodes : IDictionary<int, string>) (s : string) =
        let elements = s.Split('\t')
        let name = elements.[0] |> nameParts
        let id = elements.[1]
        let schoolCode = elements.[2] |> int
        let schoolName = schoolCodes.[schoolCode]

        let scores =
            elements
            |> Array.skip 2
            |> Array.map TestResult.fromString
            |> Array.choose TestResult.tryEffectiveScore

        let meanScore = scores |> Array.average
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
        {
            Surname = name.Surname
            GivenName = name.GivenName
            Id = id
            SchoolName = schoolName
            MeanScore = meanScore
            MinScore = minScore
            MaxScore = maxScore
        }

    let printSummary (student : Student) =
        printfn "%s, %s\t%s\t%s\t%0.2f\t%0.2f\t%0.2f" student.Surname student.GivenName student.Id student.SchoolName student.MeanScore student.MinScore student.MaxScore