namespace Emu8086_IOGUI_Csharp.Interfaces
{
    internal interface IModeRepository
    {
        string GetModeName();
        string GetLegend();
        int READ_IO_WORD(long lPORT_NUM);
        void WRITE_IO_WORD(long lPORT_NUM, short iValue);
    }
}
