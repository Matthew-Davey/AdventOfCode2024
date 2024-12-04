module Day04.Part2

open FSharpPlus

let parseInput = String.trimWhiteSpaces >> String.toSeq >> Seq.split ["\n"] >> array2D

module Array2D =
    let windowed width height m =
        seq {
            for y in 0..(Array2D.length1 m - height) do
                for x in 0..(Array2D.length2 m - width) do
                    yield m[y..y + (height - 1), x..x + (width - 1)]
        }

let hasMiddleA (m : char[,]) = m[1, 1] = 'A'

let cornerElements (m : 'a[,]) =
    let height, width = (Array2D.length1 m - 1, Array2D.length2 m - 1)
    seq { m[0, 0]; m[0, width]; m[height, 0]; m[height, width] }

let notContains x = (not << Seq.contains x)

let findXmas input =
    Array2D.windowed 3 3 input
    |> Seq.filter hasMiddleA
    |> Seq.filter (cornerElements >> notContains 'A')
    |> Seq.filter (cornerElements >> notContains 'X')
    |> Seq.filter (fun a -> a[0, 0] <> a[2, 2] && a[2, 0] <> a[0, 2]) // filter out MAM's and SAS's...

let run input =
    parseInput input
    |> findXmas
    |> Seq.length
