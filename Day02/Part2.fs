module Day02.Part2

open FSharpPlus
open FParsec

let (&&<) a b x = a x && b x
let (||<) a b x = a x || b x

let parseReport = sepBy1 pint32 (skipChar ' ') .>> (skipNewline <|> eof)

let incrementing = List.pairwise >> List.forall (fun (a, b) -> b > a)
let decrementing = List.pairwise >> List.forall (fun (a, b) -> b < a)
let stepWithin r = List.pairwise >> List.forall (fun (a, b) -> abs (b - a) <= r)

let subsets xs = seq {
    for i in 0 .. (List.length xs) - 1 do
        yield List.deleteAt i xs
}

let anySubsetSafe =
    subsets >> Seq.exists ((incrementing ||< decrementing) &&< stepWithin 3)

let run input =
    CharStream.ParseString(input, 0, length input, (many1 parseReport), (), null).Result
    |> List.filter anySubsetSafe
    |> List.length
