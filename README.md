# Instruction Processor

Console Application that will evaluate a list of instructions passed in via a txt file

## Assumptions

- No circular dependencies, do not check instruction is already in chain of instructions being processed
- Input numbers and labels are always ints
- Result will always evaluate to be within 32-bits (using int not long)
- You weren't interested in how long it takes to calculated a cached instruction
