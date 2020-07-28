import matplotlib.pyplot as plt
import numpy as np

if __name__ == "__main__":
    log0 = np.loadtxt("training_log_0.txt", delimiter=",")
    log1 = np.loadtxt("training_log_1.txt", delimiter=",")
    log2 = np.loadtxt("training_log_2.txt", delimiter=",")
    log3 = np.loadtxt("training_log_3.txt", delimiter=",")
    log4 = np.loadtxt("training_log_4.txt", delimiter=",")
    log5 = np.loadtxt("training_log_5.txt", delimiter=",")
    log100 = np.loadtxt("training_log_100.txt", delimiter=",")

    # plt.plot(log0[:, 3], label="class 1")
    # plt.plot(log1[:, 3], label="class 2")
    # plt.plot(log2[:, 3], label="class 3")
    # plt.plot(log3[:, 3], label="class 4")
    # plt.plot(log4[:, 3], label="class 5")
    # #plt.plot(log5[:, 3], label="class 6")
    # plt.plot(log100[:, 3], label="class all")
    # plt.legend()
    # plt.show()

    print(np.sum(log0[:, 4]))
    print(np.sum(log1[:, 4]))
    print(np.sum(log2[:, 4]))
    print(np.sum(log3[:, 4]))
    print(np.sum(log4[:, 4]))
    print(np.sum(log5[:, 4]))
    print(np.sum(log100[:, 4]))