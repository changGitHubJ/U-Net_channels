import keras
import matplotlib.pyplot as plt
import numpy as np
import tensorflow as tf

from matplotlib import cm

import common as c
import load_data as data

def readImages(filename, channel):
    images = np.zeros((c.TEST_DATA_SIZE*c.CATEGORY, c.IMG_SIZE, c.IMG_SIZE, channel))
    fileImg = open(filename)
    for k in range(c.TEST_DATA_SIZE*channel):
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
    with tf.device("/gpu:0"):
        filepath = ["./data/testImage256_0.txt",
                    "./data/testImage256_1.txt",
                    "./data/testImage256_2.txt",
                    "./data/testImage256_3.txt",
                    "./data/testImage256_4.txt",
                    "./data/testImage256_5.txt"]
        model = []
        for k in range(c.CATEGORY):
            print("loading model_%d.h5..."%k)
            model.append(keras.models.load_model("model_%d.h5"%k))
        for k in range(c.CATEGORY):
            test_image = readImages(filepath[k], 1)
            output = []
            for j in range(c.CATEGORY):
                output.append(model[j].predict(test_image/127.5 - 1.0))
            for i in range(c.TEST_DATA_SIZE):
                inferred = np.zeros([c.IMG_SIZE, c.IMG_SIZE, c.CATEGORY])
                inferred = np.zeros([c.IMG_SIZE, c.IMG_SIZE, c.CATEGORY])
                for m in range(c.IMG_SIZE):
                    for n in range(c.IMG_SIZE):
                        for j in range(c.CATEGORY):
                            inferred[m, n, j] = output[j][i, m, n]
                plt.figure(figsize=[15, 6])
                plt.subplot(2, 6, 1)
                fig = plt.imshow(test_image[i, :, :, 0].reshape([c.IMG_SIZE, c.IMG_SIZE]))
                fig.axes.get_xaxis().set_visible(False)
                fig.axes.get_yaxis().set_visible(False)
                for j in range(c.CATEGORY):
                    plt.subplot(2, 6, c.CATEGORY + j + 1)
                    fig = plt.imshow(inferred[:, :, j].reshape([c.IMG_SIZE, c.IMG_SIZE]), vmin=0.0, vmax=1.0)
                    fig.axes.get_xaxis().set_visible(False)
                    fig.axes.get_yaxis().set_visible(False)  
                plt.show()

def main_all():
    with tf.device("/gpu:0"):
        filepath = ["./data/testImage256_100.txt"]
        print("reading images...")
        test_image = readImages(filepath[0], 6)
        print("loading model...")
        model = keras.models.load_model("model_100.h5")
        output = model.predict(test_image/127.5 - 1.0)   # OK
        for i in range(c.TEST_DATA_SIZE*c.CATEGORY):
            inferred = np.zeros([c.IMG_SIZE, c.IMG_SIZE, c.CATEGORY])    
            for m in range(c.IMG_SIZE):
                for n in range(c.IMG_SIZE):
                    for j in range(c.CATEGORY):
                        inferred[m, n, j] = output[i][m, n, j]
            plt.figure(figsize=[15, 6])
            plt.subplot(2, 6, 1)
            fig = plt.imshow(test_image[i, :, :, 0].reshape([c.IMG_SIZE, c.IMG_SIZE]))
            fig.axes.get_xaxis().set_visible(False)
            fig.axes.get_yaxis().set_visible(False)
            for j in range(c.CATEGORY):
                plt.subplot(2, 6, c.CATEGORY + j + 1)
                fig = plt.imshow(inferred[:, :, j].reshape([c.IMG_SIZE, c.IMG_SIZE]), vmin=0.0, vmax=1.0)
                fig.axes.get_xaxis().set_visible(False)
                fig.axes.get_yaxis().set_visible(False)  
            plt.show()

if __name__=='__main__':
    #main()
    main_all()
    