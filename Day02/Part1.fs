module Day02.Part1

open FSharpPlus
open FParsec

let (||<) a b x = a x || b x

let parseReport = sepBy1 pint32 (skipChar ' ') .>> (skipNewline <|> eof)

let incrementing = List.pairwise >> List.forall (fun (a, b) -> b > a)
let decrementing = List.pairwise >> List.forall (fun (a, b) -> b < a)
let stepWithin r = List.pairwise >> List.forall (fun (a, b) -> abs (b - a) <= r)

let run input =
    CharStream.ParseString(input, 0, length input, (many1 parseReport), (), null).Result
    |> List.filter (incrementing ||< decrementing)
    |> List.filter (stepWithin 3)
    |> List.length
