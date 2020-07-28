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

if __name__ == "__main__":
    for FILENAME in FILENAMES:
        for i in range(150):
            filename = FILENAME + str(i + 1) + '.png'
            print(filename)
            img = Image.open(filename)
            resized = img.resize([c.IMG_SIZE, c.IMG_SIZE], Image.LANCZOS)
            array = np.array(resized)
            # plt.imshow(array)
            # plt.show()

            ofilename = FILENAME + str(i + 1) + '.txt'
            np.savetxt(ofilename, array, fmt="%d", delimiter=",")
