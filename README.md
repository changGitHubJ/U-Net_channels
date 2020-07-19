Defection using multi-channel U-Net
====

Overview

- Deep learning for defection
- U-Net algorithm
- DAGM dataset
- keras + tensorflow
- multi-channel

## Requirement

- python 3.6.9
- tensorflow-gpu 1.14.0
- keras 2.3.1
- Visual Studio 2017
- .Net framework 4.6.1
- tensorflow_for_C 1.14.0

## Usage

1. Configurate image and lable  
place DAGM dataset to ../  
start configurate_data.py

1. Check image and label
start chek_data.py  
Note that main() and main_all() is for single channel and multi-channel, respectively.

1. Training with tensorflow  
start train.sh

1. Check result on Linux  
start apply_model.py  
Note that main() and main_all() is for single channel and multi-channel, respectively.

1. Transfer created model to Windows OS
start keras_to_tensorflow.sh to transform h5 files to pb files.
Then copy the pb files to Window PC using memory stick or so.

1. Check result on Windows
Drag and drop a image to the PictureBox.

**The environment for tensorflow for C is required.**
Please check the followings:  
https://changlikesdesktop.hatenablog.com/entry/2020/04/18/175527

## Licence

[MIT](https://github.com/tcnksm/tool/blob/master/LICENCE)