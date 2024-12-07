open System.IO

let sample = """190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20"""

assert (Day07.Part1.run sample = 3749)
assert (Day07.Part2.run sample = 11387)

let input = File.ReadAllText "input.txt"

printfn $"Part1: %i{Day07.Part1.run input}"
printfn $"Part2: %i{Day07.Part2.run input}"
