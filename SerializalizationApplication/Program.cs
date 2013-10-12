using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SerializalizationApplication
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new BinForm());
			//Application.Run(new XmlForm());
			//Application.Run(new Xml2Form());
			//Application.Run(new DataContractForm());
			//Application.Run(new DataContractJsonSerializerForm());
		}
	}
}
