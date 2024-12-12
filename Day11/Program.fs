open System.IO

let sample = "125 17"

assert (Day11.Part1.run sample = 55312)
assert (Day11.Part2.run sample = 65601038650482L)

let input = File.ReadAllText "input.txt"

printfn $"Part1: %i{Day11.Part1.run input}"
printfn $"Part2: %i{Day11.Part2.run input}"
