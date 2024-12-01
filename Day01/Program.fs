open System.IO

let sample = [
    "3   4";
    "4   3";
    "2   5";
    "1   3";
    "3   9";
    "3   3"
]

let sample2 = [ ]

assert (Day01.Part1.run sample = 11)
assert (Day01.Part2.run sample = 31)

let input = File.ReadAllLines("./input.txt")

printfn $"Part1: %i{Day01.Part1.run input}"
printfn $"Part2: %i{Day01.Part2.run input}"
