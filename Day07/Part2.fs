module Day07.Part2

open FParsec

let parseEquation = (pint64 .>> skipString ": ") .>>. (sepBy pint64 (skipChar ' '))
let parseEquations = (sepEndBy parseEquation (skipNewline <|> eof))

type Operator = | Add | Mul | Cat
let operators = [Add; Mul; Cat]

let rec operatorCombinations = function
    | 1 -> operators |> Seq.map (fun x -> [x])
    | n -> operatorCombinations (n - 1) |> Seq.collect (fun acc -> operators |> Seq.map (fun x -> acc @ [x]))

let solveEquation x operands operators =
    Seq.zip operators operands
    |> Seq.fold (fun acc (operator, operand) ->
       match (operator, operand) with
       | Add, n -> acc + n
       | Mul, n -> acc * n
       | Cat, n -> int64 $"%i{acc}%i{n}") x

let isSolvable (expected, operands) =
    operatorCombinations (List.length operands - 1)
    |> Seq.map (solveEquation operands[0] operands[1..])
    |> Seq.exists ((=) expected)

let run input =
    CharStream.ParseString(input, 0, String.length input, parseEquations, (), null).Result
    |> Seq.filter isSolvable
    |> Seq.sumBy fst
