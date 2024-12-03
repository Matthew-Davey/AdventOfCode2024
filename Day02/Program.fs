open System.IO

let sample = """7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9"""

assert (Day02.Part1.run sample = 2)
assert (Day02.Part2.run sample = 4)

let input = File.ReadAllText("./input.txt")

printfn $"Part1: %i{Day02.Part1.run input}"
printfn $"Part2: %i{Day02.Part2.run input}"
