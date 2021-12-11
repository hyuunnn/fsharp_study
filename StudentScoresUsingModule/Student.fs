namespace StudentScores

type Student =
    {
        Surname : string
        GivenName : string
        Name : string
        Id : string
        MeanScore : float
        MinScore : float
        MaxScore : float
    }

module Student = // F#의 module은 Class 역할인 것 같다.

    let namePart i (s : string) = 
        let elements = s.Split(',')
        elements.[i].Trim()

    let fromString (s : string) =
        let elements = s.Split('\t')
        let name = elements.[0]
        let id = elements.[1]
        let given = namePart 1 name
        let sur = namePart 0 name
        let scores =
            elements
            |> Array.skip 2
            |> Array.map (fun s -> Float.fromStringOrNum(50.0, s))
        let meanScore = scores |> Array.average
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
        {
            Surname = sur
            GivenName = given
            Name = name
            Id = id
            MeanScore = meanScore
            MinScore = minScore
            MaxScore = maxScore
        }

    let printSummary (student : Student) =
        printfn "%s, %s\t%s\t%0.2f\t%0.2f\t%0.2f" student.Surname student.GivenName student.Id student.MeanScore student.MinScore student.MaxScore