open System.IO

let sample = """47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47"""

assert (Day05.Part1.run sample = 143)
assert (Day05.Part2.run sample = 123)

let input = File.ReadAllText("./input.txt")

printfn $"Part1: %i{Day05.Part1.run input}"
printfn $"Part2: %i{Day05.Part2.run input}"
