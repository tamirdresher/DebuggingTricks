using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using OzCodeDemo.Packages;

namespace OzCodeDemo
{    
    [Export(typeof(IOzCodeDemo)), ExportMetadata("Demo", "QuickActions")]
    public class QuickActionsDemo : IOzCodeDemo
    {
        readonly FeeManager _feesManager = new FeeManager();

        public void Start()
        {
            var packages = Package.GetPackages();

            var fees = packages.ToDictionary(package => package, CalculateFee);

            // Why did the delivery fee for some packages come back as zero, or even worst, a negative number?
            // Let's quickly create some conditional breakpoints to find out!
           System.Diagnostics.Debugger.Break();

            Trace.Assert(fees.Values.All(fee => fee > 0), "Something went wrong!!!");
        }

        private double CalculateFee(Package package)
        {
            double amount = package.GetNominalFee();

            double? justBecauseWeCanFee = _feesManager.MakeUpNumber(package);

            // When you reach the next line, place your caret on 'justBecauseWeCanFee', open QuickActions, 
            // and choose: Breakpoint->Add Conditional Breakpoint and choose "justBecauseWeCanFee.HasValue"
            
            amount += justBecauseWeCanFee.HasValue ? justBecauseWeCanFee.Value : 0;

            // When you reach the next line, place your caret on 'GetDeliverySurcharge', open QuickActions, 
            // and choose: Breakpoint->Add Conditional Breakpoint and choose "package.GetDeliverySurcharge() < 0"

            amount *= package.GetDeliverySurcharge();


            return amount;
        }

    }
}
