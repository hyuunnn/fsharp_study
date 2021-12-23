open System

[<EntryPoint>]
let main argv = 

    let numbers = [1; 2; 4; 8; 16]

    let moreNumbers = 
        [
            for i in 0..4 -> pown 2 i
        ]

    let yetMoreNumbers = List.init 5 (fun i -> pown 2 i)

    let total = 
        [ for i in 1..1000 -> i * i]
        |> List.sum
    
    let thirdNumber = yetMoreNumbers.[2]
    // yetMoreNumbers.[1] <- 99
    // 에러 발생 -> Array는 메모리에 일정하게 데이터 저장, List는 일정하게 저장 X
    // Array에서는 i번째 해당하는 값을 가져올 때 i만큼 더해서 메모리에 해당하는 값에 접근 가능
    // List는 일정하게 저장안하는 대신, add하는 속도가 빠름

    let strings = ["the"; "cat"; "sat"]
    printfn "strings: %A" strings

    let strings2 = "somethings" :: strings
    printfn "string2: %A" strings2

    match strings2 with
    | head::tail ->
        printfn "head: \"%s\", tail: %A" head tail
    | [] ->
        printfn "Empty List"

    0