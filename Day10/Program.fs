open System.IO

let sample = """89010123
78121874
87430965
96549874
45678903
32019012
01329801
10456732"""

assert (Day10.Part1.run sample = 36)
assert (Day10.Part2.run sample = 81)

let input = File.ReadAllText "input.txt"

printfn $"Part1: %i{Day10.Part1.run input}"
printfn $"Part2: %i{Day10.Part2.run input}"
