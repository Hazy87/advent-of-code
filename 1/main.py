import os
with open('input.txt') as file:
    array = file.readlines()
    previous = int(array[0]);
    counter = 0;
    for line in array:
      if(previous < int(line)):
          counter = counter + 1
      previous = int(line)
    print(counter)