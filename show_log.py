import matplotlib.pyplot as plt
import numpy as np

if __name__ == "__main__":
    log0 = np.loadtxt("./training_log_0.txt", delimiter=",")
    log100 = np.loadtxt("./training_log_100.txt", delimiter=",")

    plt.plot(log0[:, 3], color="blue", label="1 Channel(Class_1)")
    plt.plot(log100[:, 3], color="orange", label="6 Channel")
    plt.legend()
    plt.show()