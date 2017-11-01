using System;
using System.Drawing.Text;
using System.Drawing;

namespace Classes
{
    internal static class Fonts
    {
        private static PrivateFontCollection pfc = new PrivateFontCollection();
        private static Font fnt;
        internal static Font Default(float size)
        {
            
            byte[] Bytes = global::Slave.Resources.DIGITAL_7;
            //allocate some memory and get a pointer to it
            IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(Bytes.Length);
            //copy the font data byte array to memory
            System.Runtime.InteropServices.Marshal.Copy(Bytes, 0, ptr, Bytes.Length);
            //Add the font to the private font collection
            pfc.AddMemoryFont(ptr, Bytes.Length);
            //free up the previously allocated memory
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(ptr);
            //define a font from the private font collection
            fnt = new Font(pfc.Families[0], size, System.Drawing.FontStyle.Regular, GraphicsUnit.Point);
            //dispose of the private font collection
            //pfc.Dispose();
            return fnt;
        }
    }
}
