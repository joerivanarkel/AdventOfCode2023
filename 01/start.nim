import strutils, sequtils, math, tables

proc readFile(filename: string): seq[string] =
    var lines = newSeq[string]()
    for line in lines(filename):
        lines.add(line)
    return lines

proc parseTextNumbers(lines: seq[string]): seq[string] =
    # Actrual genius solution from https://www.reddit.com/r/adventofcode/comments/1884fpl/comment/kbiywz6/?utm_source=share&utm_medium=web2x&context=3
    let numberMap = {"one": "o1e", "two": "t2o", "three": "t3e", "four": "f4r", "five": "f5e", "six": "s6x", "seven": "s7n", "eight": "e8t", "nine": "n9e"}.toTable
    var parsedLines = newSeq[string]()
    for line in lines:
        var parsedLine = line
        for key, value in numberMap:
            parsedLine = parsedLine.replace(key, value)
        parsedLines.add(parsedLine)
    return parsedLines

proc getNumbers(lines: seq[string]): seq[seq[int]] =
    var numbers = newSeq[seq[int]]()
    for line in lines:
        var lineNumbers = newSeq[int]()
        for char in line:
            if char.isDigit():
                lineNumbers.add(ord(char) - ord('0'))
        numbers.add(lineNumbers)
    return numbers

proc getFirstAndLast(numbers: seq[seq[int]]): seq[seq[int]] =
    var firstAndLast = newSeq[seq[int]]()
    for line in numbers:
        var first = line[0]
        var last = line[line.len - 1]
        firstAndLast.add(@[first, last])
    return firstAndLast

proc combineNumbers(numbers: seq[seq[int]]): seq[int] =
    var combinedNumbers = newSeq[int]()
    for line in numbers:
        for i in 0 ..< line.len - 1:
            let combinedNumber = $line[i] & $line[i+1]
            combinedNumbers.add(parseInt(combinedNumber))
    return combinedNumbers

# execution starts here
let file = readFile("input.txt")
let parsedText = parseTextNumbers(file)
for line in parsedText:
    echo line
let numbers = getNumbers(parsedText)
let firstAndLast = getFirstAndLast(numbers)
let combinedNumbers = combineNumbers(firstAndLast)

let sum = combinedNumbers.sum()
echo sum

