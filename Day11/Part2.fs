module Day11.Part2

open FSharpPlus

module List =
    let sumByL fn =
        List.fold (fun acc x -> acc + fn x) 0L

let parseInput =
    String.trimWhiteSpaces
    >> String.split [" "]
    >> Seq.map (fun value -> (value, 1L))
    >> Seq.toList

let rec blink iterations stones =
    if iterations = 0 then
        stones
    else
        stones
        |> List.collect (function
               | "0", count -> [("1", count)]
               | value, count when String.length value % 2 = 0 ->
                   let a = value[0..(String.length value) / 2 - 1]
                   let b = value[String.length value / 2..]
                   [(int64 a |> string, count); (int64 b |> string, count)]
               | value, count -> [(int64 value * 2024L |> string, count)]
           )
        |> List.groupBy fst
        |> List.map (fun (key, stones) -> (key, List.sumByL snd stones))
        |> blink (iterations - 1)

let run =
    parseInput
    >> blink 75
    >> List.sumByL snd
