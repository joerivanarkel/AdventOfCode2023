import 'dart:io';

bool isNumber(String value) {
  return int.tryParse(value) != null || double.tryParse(value) != null;
}

void main(List<String> arguments) {
  var lines = readLines('./bin/input.txt');
  var symbols = getSymbols(lines);
  var sum = getSum(symbols);
  print(sum);
}

List<String> readLines(String path) {
  var file = File(path);
  var lines = file.readAsLinesSync();
  return lines;
}

List<String> getSymbols(List<String> lines) {
  return lines.expand((line) => line.split('.')).toList();
}

int getSum(List<String> symbols) {
  return symbols.where(isNumber).map(int.parse).reduce((a, b) => a + b);
}