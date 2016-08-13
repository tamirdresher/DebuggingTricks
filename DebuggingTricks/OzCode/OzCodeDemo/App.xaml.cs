using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OzCodeDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		 public static OutputWindow Output { get; private set; }

        protected override void OnStartup(StartupEventArgs e) {
			 base.OnStartup(e);

            // For Experimental Linq support

            var win = new MainWindow();

			 Output = new OutputWindow();
			 win.Show();
			 Output.Owner = win;
			 win.Left = 0;
			 Output.Left = win.ActualWidth;
			 Output.Show();
		 }
    }
}
