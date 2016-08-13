using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using OzCodeDemo.Invoices;
using System.Diagnostics;

namespace OzCodeDemo {
	[Export(typeof(IOzCodeDemo)), ExportMetadata("Demo", "SetterBreakpoints")]
	public class SetterBreakpointsDemo : IOzCodeDemo {
		public void Start() {
			DoDemo();
		}

		private void DoDemo() {
			// load customers

			var customers = GetCustomers();

			// save to stream

			var formatter = new BinaryFormatter();

           System.Diagnostics.Debugger.Break();

			using(var ms = new MemoryStream()) {
				foreach(var customer in customers)
					formatter.Serialize(ms, customer);
			}

		}

		private ICollection<Customer> GetCustomers() {
			var customers = CustomersRepository.LoadCustomers();
			customers.AddRange(CustomersRepository.LoadCustomers());
			customers.AddRange(CustomersRepository.LoadCustomers());
			customers.AddRange(CustomersRepository.LoadCustomers());
			customers.AddRange(CustomersRepository.LoadCustomers());
			customers.AddRange(CustomersRepository.LoadCustomers());

			return customers;
		}
	}
}
