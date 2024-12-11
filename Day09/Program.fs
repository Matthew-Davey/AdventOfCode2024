open System.IO

let sample = """2333133121414131402"""

assert (Day09.Part1.run sample = 1928)
assert (Day09.Part2.run sample = 2858)

let input = File.ReadAllText "input.txt"

printfn $"Part1: %i{Day09.Part1.run input}"
printfn $"Part2: %i{Day09.Part2.run input}"
