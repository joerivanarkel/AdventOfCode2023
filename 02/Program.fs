open System.IO

type showSet = {
    greens: int
    reds: int
    blues: int
}

type game = {
    id: int
    sets : showSet list
}

let readAllLines (path:string) =
    File.ReadAllLines(path)
    |> Array.toList

let parseInput (lines:list<string>) =
    let mutable result = [] : game list list
    for line in lines do
        let splitLine = line.Split(": ")

        let id = splitLine.[0].Split(" ").[1] |> int

        let seperatedValues = splitLine.[1].Split(";")
        let mutable sets = [] : showSet list

        for set in seperatedValues do
            let mutable greens = 0
            let mutable reds = 0
            let mutable blues = 0
            let setValues = set.Split(",")

            for value in setValues do
                let splitValue = value.Trim().Split(" ")
                match splitValue.[1].Trim() with
                | "green" -> greens <- splitValue.[0] |> int
                | "red" -> reds <- splitValue.[0] |> int
                | "blue" -> blues <- splitValue.[0] |> int
                | _ -> ()
            sets <- sets @ [{greens = greens; reds = reds; blues = blues}]
        result <- result @ [ [{id = id; sets = sets}] ]
    result

let filterValid (games:game list list) =
    let mutable result = [] : game list list
    for game in games do
        let mutable valid = true
        for set in game.[0].sets do
            if set.greens > 13 then 
                valid <- false
            if set.reds > 12 then
                valid <- false  
            if set.blues > 14 then
                valid <- false    
        if valid then
            result <- result @ [game]
    result

let sumOfIds (games:game list list) =
    let mutable result = 0
    for game in games do
        result <- result + game.[0].id
    result

let powerSetMinCube (games:game list list) =
    let mutable result = 0
    for game in games do
        let mutable minBlue = 0
        let mutable minRed = 0
        let mutable minGreen = 0

        for set in game.[0].sets do
            if set.greens > minGreen then
                minGreen <- set.greens
            if set.reds > minRed then
                minRed <- set.reds
            if set.blues > minBlue then
                minBlue <- set.blues

        result <- result + (minBlue * minRed * minGreen)
    result

// execution starts here
let lines = 
    // part 1
    readAllLines "input.txt" 
    |> parseInput
    |> filterValid
    |> sumOfIds
    |> printfn "%A"

    // part 2
    readAllLines "input.txt"
    |> parseInput
    |> powerSetMinCube
    |> printfn "%A"


