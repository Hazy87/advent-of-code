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
    return finals
def getEpsilon(gamma):
    epsilon = []
    for index in gamma: 
        if(index == 0):
            epsilon.append(1)
        else:
            epsilon.append(0)
    return epsilon

def getCommonRating(array, position, default):
    zeroCount = 0
    oneCount = 0
    for line in array:
        if(int(line[position]) == 0):
            zeroCount = zeroCount + 1
        else:
            oneCount = oneCount + 1
    if(zeroCount == oneCount):
        return default
    if(zeroCount > oneCount):
        return "0"
    return "1"

def filterArray(array, startingDecimal):
    filteredArray = []
    for line in array:
        if(line.startswith(startingDecimal)):
            filteredArray.append(line)
    return filteredArray

def getOxygenRating(array):
    found = False
    counter = 0
    firstRating = ""
    filteredArray = array
    while (found == False):
        firstRating = firstRating + getCommonRating(filteredArray, counter, "1")
        filteredArray = filterArray(array, firstRating)
        if(len(filteredArray) == 1):
            found = True
        counter = counter +1
    return int(filteredArray[0],2) 

def getCoRating(array):
    found = False
    counter = 0
    firstRating = ""
    filteredArray = array

    while (found == False):
        common = getCommonRating(filteredArray, counter, "1")
        if(common == "1"):
            firstRating =  firstRating + "0"
        else:
            firstRating = firstRating + "1"
        filteredArray = filterArray(array, str(firstRating))
        if(len(filteredArray) == 1):
            found = True
        counter = counter +1 
    return int(filteredArray[0],2)

with open('input.txt') as file:
    array = file.readlines()
    gamma = getGamma(array)
    epsilon = getEpsilon(gamma)
    gammaint = int(''.join(str(x) for x in gamma),2)
    epsilonint = int(''.join(str(x) for x in epsilon),2)
    output = gammaint * epsilonint
    print(output)
    oxygenrating = getOxygenRating(array)
    corating = getCoRating(array)
    rating = oxygenrating * corating
    print(rating)