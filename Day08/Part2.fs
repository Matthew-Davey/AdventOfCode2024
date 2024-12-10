module Day08.Part2

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
        for i in 0 .. 50 do
            yield (a - ((x - a) * i), b - ((y - b) * i))

        for i in 0 .. 50 do
            yield (x + ((x - a) * i), y + ((y - b) * i))
    }

let inBounds by bx (y, x) =
    y >= 0 && y < by && x >= 0 && x < bx

let run input =
    let m = parseInput input
    findSignals m
    |> Seq.groupBy fst
    |> Seq.map (snd >> map snd)
    |> Seq.collect (fun locations -> seq {
           for i in 0 .. length locations - 2 do
               for j in i + 1 .. length locations - 1 do
                   let location = (Seq.item i locations), (Seq.item j locations)
                   yield! plotAntinodes (fst location) (snd location)
       })
    |> Seq.distinct
    |> Seq.filter (inBounds (Array2D.length1 m) (Array2D.length2 m))
    |> Seq.length
