open System
open Classes

[<EntryPoint>]
let main argv =
    let namePrompt = ConsolePrompt("Please enter your name", 3)
    namePrompt.ColorScheme <- ConsoleColor.Cyan, ConsoleColor.DarkGray
    let name = namePrompt.GetValue()
    printfn "Hello %s" name

    let colorPrompt = ConsolePrompt("What is your favorite color (press Enter if you don't have one)", 1)
    let favoriteColor = colorPrompt.GetValue()

    let person = Person(name, favoriteColor)
    printf "%s" (person.Description())
    0