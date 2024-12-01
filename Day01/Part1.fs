module Day01.Part1

open FSharpPlus

let distance (a, b) = abs (a - b)

let run : string seq -> int =
    Seq.map (String.split ["   "] >> Seq.map int)
    >> Seq.transpose
    >> Seq.map Seq.sort
    >> fun xs -> Seq.zip (Seq.head xs) (Seq.last xs)
    >> Seq.map distance
    >> Seq.sum
