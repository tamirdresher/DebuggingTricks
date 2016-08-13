using System.Diagnostics;

namespace OzCodeDemo
{
    class FullAdder
    {
        public bool AInput { get; set; }
        public bool BInput { get; set; }
        public bool CInput { get; set; }

        public bool COut
        {
            get
            {
                if (AInput && BInput && CInput)
                   System.Diagnostics.Debugger.Break();
                var fullAdderCarryOut = AInput && BInput || CInput && (AInput ^ BInput);
                return fullAdderCarryOut;
            }
        }

        public bool Out
        {
            get
            {
                if (AInput && BInput && !CInput)
                   System.Diagnostics.Debugger.Break();
                return AInput ^ BInput ^ CInput;
            }
        }

        public override string ToString()
        {
            return string.Format("AIn: {0}, BIn: {1}, CIn: {2}, COut: {3}, Out: {4}", AInput, BInput, CInput, COut, Out);
        }
    }
}