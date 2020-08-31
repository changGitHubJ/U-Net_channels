using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Viewer
{
    class WrapInferenceDLL
    {
        [DllImport("inference.dll")]
        public static extern int initializeDll();

        [DllImport("inference.dll")]
        public static extern int finalizeDll();

        [DllImport("inference.dll")]
        public static extern int loadModel(string model_name, int model_num);

        [DllImport("inference.dll")]
        public static extern int prepareSession(int model_num, int channel);

        [DllImport("inference.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int infer(System.IntPtr input, int model_num, int channel, out System.IntPtr result);

        [DllImport("inference.dll")]
        public static extern void releaseBuffer();
    }
}
