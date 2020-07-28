import matplotlib.cm as cm
import matplotlib.pyplot as plt
import numpy as np
import random

from PIL import Image

import common as c

NUM = 30

def readImages(filename, DATA_SIZE, channel):
    images = np.zeros((DATA_SIZE, c.IMG_SIZE, c.IMG_SIZE, channel))
    fileImg = open(filename)
    for k in range(DATA_SIZE):
        line = fileImg.readline()
        if(not line):
            break
        val = line.split(',')
        for i in range(c.IMG_SIZE):
            for j in range(c.IMG_SIZE):
                for n in range(channel):
                    images[k, i, j, n] = float(val[channel*(c.IMG_SIZE*i + j) + n + 1])
    return images

def main():
    for k in range(c.CATEGORY):
        train_image = readImages('./data/testImage256_%d.txt'%k, NUM, 1)
        train_label = readImages('./data/testLabel256_%d.txt'%k, NUM, 1)

        for i in range(NUM):
            plt.figure(figsize=[10, 4])
            plt.subplot(1, 2, 1)
            fig = plt.imshow(train_image[i, :, : , 0].reshape([c.IMG_SIZE, c.IMG_SIZE]), vmin=0, vmax=255)
            fig.axes.get_xaxis().set_visible(False)
            fig.axes.get_yaxis().set_visible(False)    
            plt.subplot(1, 2, 2)
            fig = plt.imshow(train_label[i, :, :, 0].reshape([c.IMG_SIZE, c.IMG_SIZE]), vmin=0, vmax=1.0)
            fig.axes.get_xaxis().set_visible(False)
            fig.axes.get_yaxis().set_visible(False)

            plt.show()

def main_all():
    train_image = readImages('./data/testImage256_100.txt', NUM*c.CATEGORY, c.CATEGORY)
    train_label = readImages('./data/testLabel256_100.txt', NUM*c.CATEGORY, c.CATEGORY)

    for i in range(NUM*c.CATEGORY):
        plt.figure(figsize=[15, 6])
        for j in range(c.CATEGORY):
            plt.subplot(2, 6, j + 1)
            fig = plt.imshow(train_image[i, :, : , j].reshape([c.IMG_SIZE, c.IMG_SIZE]), vmin=0, vmax=255)
            fig.axes.get_xaxis().set_visible(False)
            fig.axes.get_yaxis().set_visible(False)    
            
        for j in range(c.CATEGORY):
            plt.subplot(2, 6, c.CATEGORY + j + 1)
            fig = plt.imshow(train_label[i, :, :, j].reshape([c.IMG_SIZE, c.IMG_SIZE]), vmin=0, vmax=1.0)
            fig.axes.get_xaxis().set_visible(False)
            fig.axes.get_yaxis().set_visible(False)

        plt.show()

if __name__=='__main__':
    #main()
    main_all()