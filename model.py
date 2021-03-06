import keras
import tensorflow as tf
import time

from keras.models import Model, Sequential
from keras.layers import Input, Conv2D, MaxPooling2D, UpSampling2D, Dropout
from keras.layers.merge import concatenate

class MyHistory(keras.callbacks.Callback):
    def __init__(self):
        self.train_acc = []
        self.train_loss = []
        self.val_acc = []
        self.val_loss = []
        self.time = []
        self.Epoch_time_start = 0

    def on_epoch_begin(self, Epoch, logs={}):
        self.Epoch_time_start = time.time()

    def on_epoch_end(self, epoch, logs={}):
        self.train_acc.append(logs['accuracy'])
        self.val_acc.append(logs['val_accuracy'])
        self.train_loss.append(logs['loss'])
        self.val_loss.append(logs['val_loss'])
        self.time.append(time.time() - self.Epoch_time_start)

class MyModel:
    def __init__(self, input_size, batch_size, epochs):
        self.model = ""
        self.input_size = input_size
        self.channels = input_size[2]
        self.batch_size = batch_size
        self.epochs = epochs
        self.graph = tf.get_default_graph()

    def create_model(self):
        inputs = Input(self.input_size)

        # encoding ##############
        conv1_1 = Conv2D(64, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(inputs)
        conv1_2 = Conv2D(64, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(conv1_1)
        pool1 = MaxPooling2D(pool_size=(2, 2))(conv1_2)

        conv2_1 = Conv2D(128, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(pool1)
        conv2_2 = Conv2D(128, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(conv2_1)
        pool2 = MaxPooling2D(pool_size=(2, 2))(conv2_2)

        conv3_1 = Conv2D(256, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(pool2)
        conv3_2 = Conv2D(256, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(conv3_1)
        pool3 = MaxPooling2D(pool_size=(2, 2))(conv3_2)

        conv4_1 = Conv2D(512, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(pool3)
        conv4_2 = Conv2D(512, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(conv4_1)
        pool4 = MaxPooling2D(pool_size=(2, 2))(conv4_2)

        conv5_1 = Conv2D(1024, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(pool4)
        conv5_2 = Conv2D(1024, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(conv5_1)
        conv_up5 = Conv2D(512, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(UpSampling2D(size=(2, 2))(conv5_2))
        concated5 = concatenate([conv4_2, conv_up5], axis=3)

        # decoding ##############
        conv6_1 = Conv2D(512, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(concated5)
        conv6_2 = Conv2D(512, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(conv6_1)
        conv_up6 = Conv2D(256, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(UpSampling2D(size=(2, 2))(conv6_2))
        concated6 = concatenate([conv3_2, conv_up6], axis=3)

        conv7_1 = Conv2D(256, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(concated6)
        conv7_2 = Conv2D(256, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(conv7_1)
        conv_up7 = Conv2D(128, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(UpSampling2D(size=(2, 2))(conv7_2))
        concated7 = concatenate([conv2_2, conv_up7], axis=3)

        conv8_1 = Conv2D(128, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(concated7)
        conv8_2 = Conv2D(128, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(conv8_1)
        conv_up8 = Conv2D(64, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(UpSampling2D(size=(2, 2))(conv8_2))
        concated8 = concatenate([conv1_2, conv_up8], axis=3)

        conv9_1 = Conv2D(64, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(concated8)
        conv9_2 = Conv2D(64, 3, activation="relu", padding="same", kernel_initializer="he_normal", bias_initializer="zeros")(conv9_1)
        outputs = Conv2D(self.channels, 1, activation="sigmoid")(conv9_2)

        self.model = Model(input=inputs, output=outputs)

        self.model.compile(loss="binary_crossentropy", optimizer=keras.optimizers.Adam(lr = 1e-4), metrics=['accuracy'])

    def predict(self, y_pred, batch_size):
        return self.model.predict(y_pred, batch_size)

    def training(self, x_train, y_train, x_test, y_test):
        myCallback = MyHistory()
        self.model.fit(x_train, y_train, batch_size=self.batch_size, epochs=self.epochs, verbose=1, shuffle=True, validation_data=(x_test, y_test), callbacks=[myCallback])
        return myCallback

    def evaluate(self, x_test, y_test):
        return self.model.evaluate(x_test, y_test, verbose=0)

    def save(self, output_filename):
        self.model.save(output_filename)
