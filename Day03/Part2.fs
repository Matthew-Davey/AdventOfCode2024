module Day03.Part2

open System.Text.RegularExpressions

let pattern = Regex("mul\((\d{1,3}),(\d{1,3})\)|don't\(\)|do\(\)")

type Instruction =
    | Enable
    | Disable
    | Mul of int * int

let run input =
    seq {
        for m in pattern.Matches input do
            yield match m.Value with
                  | "do()" -> Enable
                  | "don't()" -> Disable
                  | _ -> Mul (m.Groups[1].Value |> int, m.Groups[2].Value |> int)
    }
    |> Seq.fold (fun (enabled, sum) instruction ->
           match instruction with
           | Mul (x, y) when enabled -> (true, sum + x * y)
           | Enable when not enabled -> (true, sum)
           | Disable when enabled -> (false, sum)
           | _ -> (enabled, sum)
       ) (true, 0)
    |> snd
