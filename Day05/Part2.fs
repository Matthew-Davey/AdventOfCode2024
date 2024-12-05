module Day05.Part2

open FSharpPlus
open FParsec

let parseRule = pint32 .>>. (skipChar '|' >>. pint32)
let parseRules = sepEndBy1 parseRule newline
let parseUpdate = sepBy1 pint32 (pchar ',')
let parseUpdates = sepEndBy1 parseUpdate (skipNewline <|> eof)

let indexOf x = Seq.findIndex ((=) x)

let isValid rules update =
    rules |> Seq.forall (function
        | x, y when Seq.contains x update && Seq.contains y update ->
            indexOf x update < indexOf y update
        | _ -> true
    )

let swap i j xs = List.init (List.length xs) (fun x ->
    if x = i then xs[j]
    else if x = j then xs[i]
    else xs[x]
)

let fix rules update =
    let mutable update = update
    while not (isValid rules update) do
        update <- Seq.fold (fun state (rx, ry) ->
            if Seq.contains rx state && Seq.contains ry state then
                let i = indexOf rx state
                let j = indexOf ry state
                if i > j then state |> swap i j else state
            else state) update rules
    update

let middleElement xs = Seq.item (Seq.length xs / 2) xs

let run input =
    let rules, updates = CharStream.ParseString(input, 0, length input, (parseRules .>>. (spaces >>. parseUpdates)), (), null).Result

    updates
    |> Seq.filter (not << isValid rules)
    |> Seq.map (fix rules)
    |> Seq.map middleElement
    |> Seq.sum
