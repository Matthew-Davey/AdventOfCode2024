module Day06.Part1

open FSharpPlus

let parseInput =
    String.trimWhiteSpaces
    >> String.split ["\n"]
    >> map String.toSeq
    >> array2D

let findStartingPosition grid =
    seq {
        for y in 0..Array2D.length1 grid - 1 do
            for x in 0..Array2D.length2 grid - 1 do
                if grid[y, x] = '^' then yield (y, x)
    }
    |> Seq.exactlyOne

let outOfBounds y x m =
    y < 0 || y >= Array2D.length1 m || x < 0 || x >= Array2D.length2 m

let rotate (y, x) = (x, -y)

let add (a, b) (x, y) = a + x, b + y

let rec step grid position direction path =
    let ny, nx = add position direction
    if outOfBounds ny nx grid then
        path @ [position]
    else if grid[ny, nx] = '#' then
        step grid position (rotate direction) path
    else
        step grid (ny, nx) direction (path @ [position])

let run input =
    let grid = parseInput input
    let startingPosition = findStartingPosition grid
    let path = step grid startingPosition (-1, 0) []
    path |> distinct |> length
