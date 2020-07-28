import math
import matplotlib.pyplot as plt
import numpy as np
import os
import tensorflow as tf

from PIL import Image

import common as c

FILENAMES = ['../DAGM/Class1_def/',
            '../DAGM/Class2_def/',
            '../DAGM/Class3_def/',
            '../DAGM/Class4_def/',
            '../DAGM/Class5_def/',
            '../DAGM/Class6_def/']

weight = [0.9, 1.0, 0.9, 0.9, 0.9, 0.8]

if __name__ == "__main__":
    cntTrain = 0
    cntTest = 0
    lineTrainAll = []
    lineTestAll = []
    for n in range(c.CATEGORY):
        lineTrain = []
        lineTest = []
        for k in range(c.TRAIN_DATA_SIZE + c.TEST_DATA_SIZE):
            filename = FILENAMES[n] + str(k + 1) + '.png'
            print(filename)
            img = Image.open(filename)
            resized = img.resize([c.IMG_SIZE, c.IMG_SIZE], Image.LANCZOS)
            array = np.array(resized)
            # plt.imshow(array)
            # plt.show()
            
            if(k < c.TRAIN_DATA_SIZE):
                line = str(cntTrain)
                lineAll = str(cntTrain)
                for i in range(c.IMG_SIZE):
                    for j in range(c.IMG_SIZE):
                        line = line + ',' + str(array[i, j])
                        for N in range(c.CATEGORY):
                            lineAll = lineAll + ',' + str(array[i, j])
                line = line + '\n'
                lineAll = lineAll + '\n'
                lineTrain.append(line)
                lineTrainAll.append(lineAll)
                cntTrain += 1
            else:
                line = str(cntTest)
                lineAll = str(cntTest)
                for i in range(c.IMG_SIZE):
                    for j in range(c.IMG_SIZE):
                        line = line + ',' + str(array[i, j])
                        for N in range(c.CATEGORY):
                            lineAll = lineAll + ',' + str(array[i, j])
                line = line + '\n'
                lineAll = lineAll + '\n'
                lineTest.append(line)
                lineTestAll.append(lineAll)
                cntTest += 1

        if not os.path.exists('./data'):
            os.mkdir('./data')
        with open("./data/trainImage256_%d.txt"%n, "w") as f:
            for l in lineTrain:
                f.write(l)
        with open("./data/testImage256_%d.txt"%n, "w") as f:
            for l in lineTest:
                f.write(l)
    
    with open("./data/trainImage256_100.txt", "w") as f:
        for l in lineTrainAll:
            f.write(l)
    with open("./data/testImage256_100.txt", "w") as f:
        for l in lineTestAll:
            f.write(l)

    # label
    Labels = []
    for n in range(c.CATEGORY):
        filename = FILENAMES[n] + 'labels.txt'
        label = open(filename, 'r')
        print('reading ' + filename)
        lines = label.readlines()
        Labels.append(lines)
    lineTrainAll = []
    lineTestAll = []
    for n in range(c.CATEGORY):
        lineTrain = []
        lineTest = []
        for k in range(c.TRAIN_DATA_SIZE + c.TEST_DATA_SIZE):
            x = np.linspace(1.0, 511, c.IMG_SIZE)
            y = np.linspace(1.0, 511, c.IMG_SIZE)                
            val = Labels[n][k].split('\t')
            num = int(val[0]) - 1
            mjr = float(val[1])
            mnr = float(val[2])
            rot = float(val[3])
            cnx = float(val[4])
            cny = float(val[5])

            # inverse rotate pixels
            label = np.zeros([c.OUTPUT_SIZE + 1], dtype=np.int32)
            labelAll = np.zeros([c.OUTPUT_SIZE*c.CATEGORY + 1], dtype=np.int32)
            label[0] = num # index
            labelAll[0] = num # index
            for i in range(c.IMG_SIZE):
                for j in range(c.IMG_SIZE):
                    dist = math.sqrt((x[i] - cnx)**2 + (y[j] - cny)**2)
                    xTmp = (x[i] - cnx) * math.cos(-rot) - (y[j] - cny) * math.sin(-rot)
                    yTmp = (x[i] - cnx) * math.sin(-rot) + (y[j] - cny) * math.cos(-rot)
                    ang = math.atan2(yTmp, xTmp)
                    distToEllipse = math.sqrt((mjr * math.cos(ang))**2 + (mnr * math.sin(ang))**2)
                    if(dist < distToEllipse):
                        label[j*c.IMG_SIZE + i + 1] = 1.0 # defection
                        labelAll[(j*c.IMG_SIZE + i)*c.CATEGORY + n + 1] = weight[n] # defection
                    else:
                        label[j*c.IMG_SIZE + i + 1] = 0.0
                        labelAll[(j*c.IMG_SIZE + i)*c.CATEGORY + n + 1] = 0.0
        
            if(k < c.TRAIN_DATA_SIZE):
                lineTrain.append(label)
                lineTrainAll.append(labelAll)
            else:
                lineTest.append(label)
                lineTestAll.append(labelAll)

        np.savetxt('./data/trainLabel256_%d.txt'%n, np.array(lineTrain), delimiter=",", fmt="%d")
        np.savetxt('./data/testLabel256_%d.txt'%n, np.array(lineTest), delimiter=",", fmt="%d")

    np.savetxt('./data/trainLabel256_100.txt', np.array(lineTrainAll), delimiter=",", fmt="%d")
    np.savetxt('./data/testLabel256_100.txt', np.array(lineTestAll), delimiter=",", fmt="%d")
