using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzCodeDemo.Invoices;

namespace OzCodeDemo {
	[Export(typeof(IOzCodeDemo)), ExportMetadata("Demo", "ExceptionHUD")]
	public class ExceptionHudDemo : IOzCodeDemo {
		public void Start() {
			DoDemo();
		}

		Random _rnd = new Random();

		private void DoDemo() {
			var repo = CustomersRepository.LoadCustomers();
			Enumerable.Range(0, 5).Select(i => _rnd.Next(repo.Count)).ToList().ForEach(i => repo[i] = null);

			foreach(var customer in repo) {
				try {
					ProcessCustomer(customer);
				}
				catch(Exception ex) {
					
				}
			
			}

		}

		void ProcessCustomer(Customer customer) 
        {
			SendEmail(customer.EmailAddress);
		}

		private void SendEmail(string email) {
			Debug.WriteLine(string.Format("Sending email to {0}", email));	
		}
	}
}
