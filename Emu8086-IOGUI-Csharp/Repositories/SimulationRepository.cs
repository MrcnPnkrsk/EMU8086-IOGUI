using Emu8086_IOGUI_Csharp.Interfaces;
using System.Collections.Generic;

namespace Emu8086_IOGUI_Csharp.Repositories
{
    internal class SimulationRepository : CommonRepository, IModeRepository
    {
        private static readonly string currentMode = "Simulation";
        private readonly Dictionary<long, int> mockIo;

        public SimulationRepository() : base(currentMode)
        {
            mockIo = new Dictionary<long, int>();
        }

        public override string GetModeName() => base.GetModeName() + "!";

        public override string GetLegend() => "0(Inc) - Green   1(Dec) - Red   2 - Yellow   3 - Orange";

        public int READ_IO_WORD(long lPORT_NUM)
        {
            mockIo.TryGetValue(lPORT_NUM,out int value);
            return value;
        }

        public void WRITE_IO_WORD(long lPORT_NUM, short iValue)
        {
            mockIo.TryGetValue(lPORT_NUM, out int value);

            if (iValue == 1)
                mockIo[lPORT_NUM] = (value + 1) % 4;
            else if (iValue == 0)
                mockIo[lPORT_NUM] = ((value - 1) == -1) ? 3 : value - 1;
        }
    }
}
