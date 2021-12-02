import os
with open('input.txt') as file:
    array = file.readlines()
    previous = int(array[0]) + int(array[1]) + int(array[2])
    counter = 0
    for index in range(len(array)-2):
      new = (int(array[index]) + int(array[index+1]) + int(array[index+2]))
      if(previous < new):
          counter = counter + 1
      previous = new
    print(counter)