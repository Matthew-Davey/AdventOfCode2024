module Day04.Part1

open FSharpPlus

let parseInput = String.trimWhiteSpaces >> String.toSeq >> Seq.split ["\n"] >> array2D

module Array2D =
    let windowed width height m =
        seq {
            for y in 0 .. (Array2D.length1 m - height) do
                for x in 0 .. (Array2D.length2 m - width) do
                    yield m[y..y + (height - 1), x .. x + (width - 1)]
        }

    let rotate90 m =
        let height, width = (Array2D.length1 m, Array2D.length2 m)
        Array2D.init width height (fun y x -> m[x, height - 1 - y])

let xmasHorizontal (m : char[,]) =
    m[0, 0..3] = [|'X'; 'M'; 'A'; 'S' |]

let xmasDiagonal (m : char[,]) =
    m[0, 0] = 'X' && m[1, 1] = 'M' && m[2, 2] = 'A' && m[3, 3] = 'S'

let countHorizontal = Array2D.windowed 4 1 >> Seq.filter xmasHorizontal >> Seq.length
let countDiagonal = Array2D.windowed 4 4 >> Seq.filter xmasDiagonal >> Seq.length
let count m = countHorizontal m + countDiagonal m

let run input =
    let rec countXmas m acc = function
        | 0 -> acc
        | i -> countXmas (Array2D.rotate90 m) (acc + (count m)) (i - 1)
    countXmas (parseInput input) 0 4
