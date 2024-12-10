module Day08.Part1

open FSharpPlus

let parseInput =
    String.trimWhiteSpaces
    >> String.split ["\n"]
    >> map String.toSeq
    >> array2D

let findSignals m = seq {
    for y in 0..(Array2D.length1 m - 1) do
        for x in 0..(Array2D.length2 m - 1) do
            if m[y, x] <> '.' then
                yield (m[y, x], (y, x))
}

let plotAntinodes (a, b) (x, y) = seq {
        yield (a - (x - a), b - (y - b))
        yield (x + (x - a), y + (y - b))
    }

let inBounds by bx (y, x) =
    y >= 0 && y < by && x >= 0 && x < bx

let run input =
    let m = parseInput input
    findSignals m
    |> Seq.groupBy fst
    |> Seq.map (snd >> map snd)
    |> Seq.collect (fun signals -> seq {
           for i in 0 .. length signals - 2 do
               for j in i + 1 .. length signals - 1 do
                   let signalPair = (Seq.item i signals), (Seq.item j signals)
                   yield! plotAntinodes (fst signalPair) (snd signalPair)
       })
    |> Seq.distinct
    |> Seq.filter (inBounds (Array2D.length1 m) (Array2D.length2 m))
    |> Seq.length
