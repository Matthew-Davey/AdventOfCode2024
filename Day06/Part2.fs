module Day06.Part2

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

let inline outOfBounds y x m =
    y < 0 || y >= Array2D.length1 m || x < 0 || x >= Array2D.length2 m

let isLooping xs =
    let rec findCycle window xs =
        let length = List.length xs
        if window > length / 2 then
            false
        else
            let lastn = xs[length - window..length]
            let prevn = xs[length - (window * 2)..length - 1 - window]
            let result = if lastn = prevn then true else findCycle (window + 1) xs
            result
    findCycle 2 xs

let inline rotate (y, x) = (x, -y)

let inline add (a, b) (x, y) = a + x, b + y

let rec step grid position direction path =
    let ny, nx = add position direction
    if outOfBounds ny nx grid then
        path @ [position]
    else if grid[ny, nx] = '#' then
        step grid position (rotate direction) path
    else
        step grid (ny, nx) direction (path @ [position])

let rec escapes position direction path grid =
    let ny, nx = add position direction
    if outOfBounds ny nx grid then
        true
    else if grid[ny, nx] = '#' then
        if isLooping path then
            false
        else
            escapes position (rotate direction) path grid
    else
        escapes (ny, nx) direction (path @ [position]) grid

let run input =
    let grid = parseInput input
    let startingPosition = findStartingPosition grid
    let originalPath = step grid startingPosition (-1, 0) []
    let candidatePositions =
         originalPath
         |> Seq.distinct
         |> Seq.filter (fun (y, x) -> grid[y, x] = '.')

    candidatePositions
    |> Seq.filter (fun (y, x) ->
           let newGrid = Array2D.copy grid
           newGrid[y, x] <- '#'

           escapes startingPosition (-1, 0) [] newGrid |> not
       )
    |> Seq.length
