namespace Emu8086_IOGUI_Csharp.Repositories
{
    internal abstract class CommonRepository
    {
        private readonly string currentMode = "Current Mode: ";

        public CommonRepository(string currentMode)
        {
            this.currentMode += currentMode;
        }

        public virtual string GetModeName()
        {
            return currentMode;
        }

        public abstract string GetLegend();
    }
}