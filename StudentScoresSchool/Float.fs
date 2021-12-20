namespace StudentScoresSchool

module Float = 

    let tryFromString (s : string) : float option = 
        if s = "N/A" then
            None
            // Nothing
        else
            Some (float s)
            // Something (float s)

    let fromStringOrNum (num : float, s : string) : float = 
        s
        |> tryFromString
        |> Option.defaultValue num
        // Optional.defaultValue num