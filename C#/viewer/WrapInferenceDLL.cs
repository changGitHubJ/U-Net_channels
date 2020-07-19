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
        public static extern int loadModel_0();

        [DllImport("inference.dll")]
        public static extern int loadModel_1();

        [DllImport("inference.dll")]
        public static extern int loadModel_2();

        [DllImport("inference.dll")]
        public static extern int loadModel_3();

        [DllImport("inference.dll")]
        public static extern int loadModel_4();

        [DllImport("inference.dll")]
        public static extern int loadModel_5();

        [DllImport("inference.dll")]
        public static extern int loadModel_100();

        [DllImport("inference.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int infer_0(System.IntPtr input, out System.IntPtr result);

        [DllImport("inference.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int infer_1(System.IntPtr input, out System.IntPtr result);

        [DllImport("inference.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int infer_2(System.IntPtr input, out System.IntPtr result);

        [DllImport("inference.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int infer_3(System.IntPtr input, out System.IntPtr result);

        [DllImport("inference.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int infer_4(System.IntPtr input, out System.IntPtr result);

        [DllImport("inference.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int infer_5(System.IntPtr input, out System.IntPtr result);

        [DllImport("inference.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int infer_All(System.IntPtr input, out System.IntPtr result);
    }
}
