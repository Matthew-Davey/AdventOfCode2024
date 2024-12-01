module Day01.Part2

open FSharpPlus

module Seq =
    let countBy fn = Seq.filter fn >> Seq.length

let run lines =
    let xs, ys =
        lines
        |> Seq.map (String.split ["   "] >> Seq.map int)
        |> Seq.transpose
        |> fun xs -> (Seq.head xs, Seq.last xs)

    xs
    |> Seq.map (fun x -> (x, Seq.countBy ((=) x) ys))
    |> Seq.map (fun (x, occ) -> x * occ)
    |> Seq.sum
