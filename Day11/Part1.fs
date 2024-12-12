module Day11.Part1

open FSharpPlus

let parseInput =
    String.trimWhiteSpaces
    >> String.split [" "]
    >> Seq.toList

let rec blink iterations stones =
    if iterations = 0 then
        stones
    else
        stones
        |> List.collect (function
               | "0" -> ["1"]
               | value when String.length value % 2 = 0 ->
                   let a = value[0..(String.length value) / 2 - 1]
                   let b = value[String.length value / 2..]
                   [int64 a |> string; int64 b |> string]
               | value -> [int64 value * 2024L |> string]
           )
        |> blink (iterations - 1)

let run =
    parseInput
    >> blink 25
    >> List.length
