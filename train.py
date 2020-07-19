import matplotlib.pyplot as plt
import numpy as np
import os
import random
import sys
import tensorflow as tf
import time

from PIL import Image

import common as c
import load_data as data
import model

# Parameter
training_epochs = 200
batch_size = 8

def main(data, model, category, channel):
    print("Reading images...")
    x_train = data.readImages('./data/trainImage256_%d.txt'%category, c.TRAIN_DATA_SIZE*channel)
    x_test = data.readImages('./data/testImage256_%d.txt'%category, c.TEST_DATA_SIZE*channel)
    y_train = data.readLabels('./data/trainLabel256_%d.txt'%category, c.TRAIN_DATA_SIZE*channel)
    y_test = data.readLabels('./data/testLabel256_%d.txt'%category, c.TEST_DATA_SIZE*channel)
    
    print("Creating model...")
    model.create_model()

    print("Now training...")
    history = model.training(x_train, y_train, x_test, y_test)
    accuracy = history.train_acc
    loss = history.train_loss
    val_accuracy = history.val_acc
    val_loss = history.val_loss
    time = history.time
    
    model.save('./model_%d.h5'%category)
    
    with open("training_log_%d.txt"%category, "w") as f:
        for i in range(training_epochs):
            line = "%f,%f,%f,%f,%f\n"%(loss[i], accuracy[i], val_loss[i], val_accuracy[i], time[i])
            f.write(line)

if __name__=='__main__':
    args = sys.argv
    # args[0]: CATEGORY
    # args[1]: channel

    data = data.MyLoadData(c.IMG_SIZE, int(args[2]))
    model = model.MyModel((c.IMG_SIZE, c.IMG_SIZE, int(args[2])), batch_size, training_epochs)
    main(data, model, int(args[1]), int(args[2]))