module Day09.Part2

open FSharpPlus

let parseInput =
    String.trimWhiteSpaces
    >> String.toArray
    >> Array.map (fun c -> int c - int '0')

type Block =
    | File of index : int * size : int
    | FreeSpace of length : int

let sequenceBlocks =
    Array.indexed
    >> Array.collect (fun (i, count) ->
           if i % 2 = 0 then
               Array.replicate count (File (i / 2, count))
           else
               [| for j = count downto 1 do (FreeSpace j) |]
       )

let inline findFreeSpace size =
    Array.tryFindIndex (function
    | FreeSpace length when length >= size -> true
    | _ -> false)

let compactBlocks blocks =
    let mutable i, j = 0, Array.length blocks - 1
    while i <> j do
        match blocks[i], blocks[j] with
        | File _, _      -> i <- i + 1
        | _, FreeSpace _ -> j <- j - 1
        | FreeSpace _, File (index, size) ->
            match blocks[i..j] |> (findFreeSpace size) with
            | Some l -> // file can be moved to position i + l
                for k = 0 to size - 1 do
                    blocks[i + l + k] <- File (index, size)
                    blocks[j - k]     <- FreeSpace 1
            | None -> // Not enough free space to move this file...
                j <- j - size
    blocks

let checksum =
    Array.mapi (fun i block ->
        match block with
        | File (index, _) -> (int64 i * int64 index)
        | _ -> 0
    )
    >> Array.sum

let run =
    parseInput
    >> sequenceBlocks
    >> compactBlocks
    >> checksum
