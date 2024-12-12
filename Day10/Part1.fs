module Day10.Part1

open FSharpPlus

type Node = { Height : int; Location : int * int; Children : Node list }

let parseInput =
    String.trimWhiteSpaces
    >> split ["\n"]
    >> map (toArray >> map (fun c -> int c - int '0'))
    >> array2D

let locateTrailheads m = seq {
    for y in 0..(Array2D.length1 m - 1) do
        for x in 0..(Array2D.length2 m - 1) do
            if m[y, x] = 0 then yield (y, x)
}

let uphillSlopes (y, x) (m : int[,]) =
    let height = m[y, x]
    [(y - 1, x); (y + 1, x); (y, x - 1); (y, x + 1)]
    |> filter (fun (y, x) -> y >= 0 && y < Array2D.length1 m && x >= 0 && x < Array2D.length2 m)
    |> filter (fun (y, x) -> m[y, x] = height + 1)

let rec followTrail (m : int[,]) (y, x) =
    let children = uphillSlopes (y, x) m |> map (followTrail m)
    { Height = m[y, x]; Location = (y, x); Children = children }

let score trail =
    let rec peaks trail =
        if trail.Height = 9 then [trail.Location] else List.collect peaks trail.Children

    peaks trail |> (distinct >> length)

let run input =
    let m = parseInput input

    locateTrailheads m
    |> Seq.map (followTrail m)
    |> Seq.map score
    |> Seq.sum
