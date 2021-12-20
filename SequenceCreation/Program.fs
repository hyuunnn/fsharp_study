open System

module MathSequence =

    type State = {N : int; Pn2 : int; Pn1 : int}

    let pell = 
        {N = 0; Pn2 = 0; Pn1 = 0}
        |> Seq.unfold (fun state ->
            let pn = 
                match state.N with
                | 0 | 1
                    -> state.N
                | _
                    -> 2 * state.Pn1 + state.Pn2
            let n' = state.N + 1
            Some(pn, {N = n'; Pn2 = state.Pn1; Pn1 = pn} )) // Some의 첫번째 값은 return 할 값, 두번째는 호출되는 곳으로 전달

[<EntryPoint>]
let main argv = 

    MathSequence.pell
    |> Seq.truncate 10
    |> Seq.iter (fun x -> printf "%i, " x)
    
    printfn "..."

    0