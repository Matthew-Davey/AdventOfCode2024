module Day03.Part1

open System.Text.RegularExpressions

let pattern = Regex("mul\((\d{1,3}),(\d{1,3})\)")

let run input =
    seq {
        for m in pattern.Matches input do
            yield (m.Groups[1].Value |> int, m.Groups[2].Value |> int)
    }
    |> Seq.map (fun (x, y) -> x * y)
    |> Seq.sum
