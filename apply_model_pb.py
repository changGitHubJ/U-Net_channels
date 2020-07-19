import tensorflow as tf

def main(pb_name):
    with tf.device("/gpu:0"):

        graph = tf.Graph()
        sess = tf.InteractiveSession(graph = graph)

        with open(pb_name, 'rb') as f:
            graph_def = tf.GraphDef()
            graph_def.ParseFromString(f.read())
            tf.import_graph_def(graph_def, name='') #, {'x':input})

        print('=' * 60)
        for op in tf.get_default_graph().get_operations():
            print(op.name)
            for output in op.outputs:
                print('  ', output.name)
        print('=' * 60)

if __name__=='__main__':    
    main("frozen_graph_100.pb")