module Day05.Part1

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

let middleElement xs = Seq.item (Seq.length xs / 2) xs

let run input =
    let rules, updates = CharStream.ParseString(input, 0, length input, (parseRules .>>. (spaces >>. parseUpdates)), (), null).Result

    updates
    |> Seq.filter (isValid rules)
    |> Seq.map middleElement
    |> Seq.sum
