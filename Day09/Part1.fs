module Day09.Part1

open FSharpPlus

let parseInput =
    String.trimWhiteSpaces
    >> String.toArray
    >> Array.map (fun c -> int c - int '0')

type Block =
    | File of index : int
    | FreeSpace

let sequenceBlocks =
    Array.indexed
    >> Array.collect (fun (i, count) ->
           let block = if i % 2 = 0 then File (i / 2) else FreeSpace
           Array.replicate count block
       )

let compactBlocks (blocks : Block array) =
    let mutable i, j = 0, Array.length blocks - 1
    while i <> j do
        match blocks[i], blocks[j] with
        | File _, _    -> i <- i + 1
        | _, FreeSpace -> j <- j - 1
        | FreeSpace, File index ->
            blocks[i] <- File index
            blocks[j] <- FreeSpace
    blocks

let checksum =
    Array.mapi (fun i block ->
        match block with
        | File j -> (int64 i * int64 j)
        | _ -> 0
    )
    >> Array.sum

let run =
    parseInput
    >> sequenceBlocks
    >> compactBlocks
    >> checksum
