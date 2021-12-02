import os
with open('input.txt') as file:
    array = file.readlines()
    horizontalPosition = 0
    depth = 0
    for instruction in array:
       instructions = instruction.split(" ")
       if(instructions[0] == "up"):
         depth = depth - int(instructions[1])
       if(instructions[0] == "down"):
         depth = depth + int(instructions[1])
       if(instructions[0] == "forward"):
         horizontalPosition = horizontalPosition + int(instructions[1])

    print(depth * horizontalPosition)