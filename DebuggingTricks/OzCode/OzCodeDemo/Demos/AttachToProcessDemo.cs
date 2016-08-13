using System.ComponentModel.Composition;

namespace OzCodeDemo
{
    [Export(typeof(IOzCodeDemo)), ExportMetadata("Demo", "AttachToProcess")]
    public class AttachToProcessDemo : IOzCodeDemo
    {
        public void Start()
        {
            var invokeGeneratedProcess = new InvokeGeneratedProcess();
            invokeGeneratedProcess.ShowDialog();

        }
    }
}