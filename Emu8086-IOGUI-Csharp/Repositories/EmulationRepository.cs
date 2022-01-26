using Emu8086_IOGUI_Csharp.Interfaces;
using System;
using System.IO;

namespace Emu8086_IOGUI_Csharp.Repositories
{
    internal class EmulationRepository : CommonRepository, IModeRepository
    {
        private static readonly string currentMode = "Emulation";
        private readonly string sIO_FILE = Settings.Filepath;

        public EmulationRepository() : base(currentMode)
        {
        }

        public override string GetModeName() => base.GetModeName() + "!";

        public override string GetLegend() => "0(Reset) - Green   1(Set) - Red   2 - Yellow   3 - Orange";

        public byte READ_IO_BYTE(long lPORT_NUM)
        {
            string sFilename = sIO_FILE;
            FileStream rdr = new FileStream(sFilename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            rdr.Seek(lPORT_NUM, SeekOrigin.Begin);
            int ch = rdr.ReadByte();
            rdr.Close();
            return (byte)ch;
        }

        public int READ_IO_WORD(long lPORT_NUM)
        {
            Int16 ti;
            byte tb1;
            byte tb2;

            tb1 = READ_IO_BYTE(lPORT_NUM);
            tb2 = READ_IO_BYTE(lPORT_NUM + 1);
            // Convert 2 bytes to a 16 bit word:
            ti = (Int16)(tb2 * 256 + tb1);

            return ti;
        }

        public void WRITE_IO_BYTE(long lPORT_NUM, byte uValue)
        {
            string sFilename = sIO_FILE;
            FileStream rdr = new FileStream(sFilename, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            rdr.Seek(lPORT_NUM, SeekOrigin.Begin);
            rdr.WriteByte(uValue);
            rdr.Close();
        }

        public void WRITE_IO_WORD(long lPORT_NUM, short iValue)
        {
            WRITE_IO_BYTE(lPORT_NUM, (Byte)(iValue & 0x00FF));
            WRITE_IO_BYTE(lPORT_NUM + 1, (Byte)((iValue & 0xFF00) / 256));
        }
    }
}
