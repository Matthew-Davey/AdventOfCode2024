open System.IO

let sample = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"

assert (Day03.Part1.run sample = 161)
assert (Day03.Part2.run sample = 48)

let input = File.ReadAllText("./input.txt")

printfn $"Part1: %i{Day03.Part1.run input}"
printfn $"Part2: %i{Day03.Part2.run input}"
