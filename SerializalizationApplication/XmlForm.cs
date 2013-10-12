using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SerializalizationApplication
{
	public partial class XmlForm : Form
	{
		private string path = "myObject.xml";

		public XmlForm()
		{
			InitializeComponent();
		}

		#region Control event handlers

		private void SerializeButton_Click(object sender, EventArgs e)
		{
			MyObject2 obj = new MyObject2();
			obj.n1 = 1;
			obj.n2 = 2;
			obj.str = "Some String";

			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyObject2));

			using(StreamWriter writer = new System.IO.StreamWriter(path))
			{
				serializer.Serialize(writer, obj);
			}

			MessageBox.Show("serialize success");
		}

		private void DeserializeButton_Click(object sender, EventArgs e)
		{
			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyObject2));
			MyObject2 obj = null;

			using(FileStream stream = new FileStream(path, System.IO.FileMode.Open))
			{
				obj = (MyObject2)serializer.Deserialize(stream);
			}

			MessageBox.Show(String.Format("n1:{0}\n\nn2:{1}\n\nn34: {2}\n\nstr: {3}\n\nstr23: {4}", obj.n1, obj.n2, obj.n34, obj.str, obj.str23));
		}

		#endregion
	}

	#region Classes

	public class MyObject2
	{
		// note:
		// 1. only public fields are serialized
		// 2. use XmlIgnore to indicate not serialize that field
		// 3. many attributes are availble to control the behavior of serialization
		// 4. customize the serialization process by inheriting IXmlSerializable interface

		[System.Xml.Serialization.XmlAttribute(AttributeName = "my_n1")]
		public int n1 = 0;

		//[System.Xml.Serialization.XmlIgnore]
		public int n2 = 0;

		private int n3 = 100;
		private int n4 = 200;

		public string str = null;

		private string str2 = "PrivateString2";
		private string str3 = "PrivateString3";

		public int n34
		{
			get
			{
				return n3 + n4;
			}
		}

		public string str23
		{
			get
			{
				return str2 + str3;
			}
		}
	}

	#endregion
}
