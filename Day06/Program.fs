open System.IO

let sample = """....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#..."""

assert (Day06.Part1.run sample = 41)
assert (Day06.Part2.run sample = 6)

let input = File.ReadAllText("./input.txt")

printfn $"Part1: %i{Day06.Part1.run input}"
printfn $"Part2: %i{Day06.Part2.run input}"
