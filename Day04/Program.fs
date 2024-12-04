open System.IO

let sample = """MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX"""

assert (Day04.Part1.run sample = 18)
assert (Day04.Part2.run sample = 9)

let input = File.ReadAllText("./input.txt")

printfn $"Part1: %i{Day04.Part1.run input}"
printfn $"Part2: %i{Day04.Part2.run input}"
