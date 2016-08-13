using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OzCodeDemo {

	public partial class OutputWindow {
		ObservableCollection<string> _lines = new ObservableCollection<string>();
		public OutputWindow() {
			InitializeComponent();
		}

		public ObservableCollection<string> Lines {
			get { return _lines; }
		}
	}
}
