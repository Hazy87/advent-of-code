import os
def getGamma(array):
    commonCounts = [0,0,0,0,0,0,0,0,0,0,0,0]
    for line in array:
        for index in range(len(line)-2):     
            if(int(line[index]) == 0):
                commonCounts[index] = int(commonCounts[index]) - 1 
                
            if(int(line[index]) == 1):
                commonCounts[index] = int(commonCounts[index]) + 1
    finals = []
    for number in commonCounts:
    
        if(number <= 0):
            finals.append(0)
        else:
            finals.append(1)
    print(finals)
    return finals

def getEpisilon(array):
    commonCounts = [0,0,0,0,0,0,0,0,0,0,0,0]
    for line in array:
        for index in range(len(line)-2):     
            if(int(line[index]) == 0):
                commonCounts[index] = int(commonCounts[index]) - 1 
                
            if(int(line[index]) == 1):
                commonCounts[index] = int(commonCounts[index]) + 1
    finals = []
    for number in commonCounts:
    
        if(number <= 0):
            finals.append(0)
        else:
            finals.append(1)
    print(finals)
    return finals

with open('input.txt') as file:
    array = file.readlines()
    gamma = getGamma(array)
    print(gamma)
    epsilon = []
    for index in gamma: 
        if(index == 0):
            epsilon.append(1)
        else:
            epsilon.append(0)
    print(epsilon)
    gammaint = int(''.join(str(x) for x in gamma),2)
    
    epsilonint = int(''.join(str(x) for x in epsilon),2)
    output = gammaint * epsilonint
    print(output)