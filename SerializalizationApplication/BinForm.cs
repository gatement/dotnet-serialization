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
	public partial class BinForm : Form
	{
		private string path = "myObject.bin";

		public BinForm()
		{
			InitializeComponent();
		}

		#region Control event handlers

		private void SerializeButton_Click(object sender, EventArgs e)
		{
			MyObject obj = new MyObject(1);
			obj.n1 = 1;
			obj.n2 = 2;
			obj.str = "Some String";

			System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

			using(Stream stream = new System.IO.FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				formatter.Serialize(stream, obj);
			}

			MessageBox.Show("Serialize successfully!");
		}

		private void DeserializeButton_Click(object sender, EventArgs e)
		{
			System.Runtime.Serialization.IFormatter formater = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

			MyObject obj = null;

			using(Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
			{
				obj = (MyObject)formater.Deserialize(stream);
			}

			MessageBox.Show(String.Format("n1: {0}\n\nn2: {1}\n\nn34:{2}\n\nstr: {3}\n\nstr23: {4}", obj.n1, obj.n2, obj.n34, obj.str, obj.str23));
		}

		#endregion
	}

	#region Classes

	[Serializable]
	public class MyObject //:System.Runtime.Serialization.ISerializable  // ???
	{
		// note: 
		// 1. both the public and private fields are serialized by default
		// 2. there are chance to impletement serialization and deserialization events
		// 3. customize the serialization process by inheriting ISerializable interface

		public MyObject(int N1)
		{
			this.n1 = N1;
		}

		#region Serialization events

		//[System.Runtime.Serialization.OnSerializing]
		//public void OnSerializing2(System.Runtime.Serialization.StreamingContext context)
		//{
		//    MessageBox.Show("OnSerializing");
		//}

		//[System.Runtime.Serialization.OnSerialized]
		//public void OnSerialized2(System.Runtime.Serialization.StreamingContext context)
		//{
		//    MessageBox.Show("OnSerialized");
		//}

		//[System.Runtime.Serialization.OnDeserializing]
		//public void OnDeserializing2(System.Runtime.Serialization.StreamingContext context)
		//{
		//    MessageBox.Show("OnDeserializing");
		//}

		//[System.Runtime.Serialization.OnDeserialized]
		//public void OnDeserialized2(System.Runtime.Serialization.StreamingContext context)
		//{
		//    MessageBox.Show("OnDeserialized");
		//}

		#endregion

		//[System.Runtime.Serialization.OptionalField]
		public MyObjectSubClass SubClass;

		public int n1 = 0;
		public int n2 = 0;

		private int n3 = 100;
		private int n4 = 200;

		// ???
		[System.Runtime.Serialization.IgnoreDataMember]
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

		#region ISerializable Members

		public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
			//MessageBox.Show(
			//    String.Format("info.AssemblyName: {0}\ninfo.FullTypeName: {1}\ninfo.MemberCount: {2}\n",
			//    info.AssemblyName,
			//    info.FullTypeName,
			//    info.MemberCount
			//    ));

			//info.AssemblyName = "AssemblyName";
			//info.FullTypeName = "FullTypeName";

			//info.SetType(typeof(MyObjectCopy));

			//info.AddValue("n1", 10);
			//info.AddValue("n2", 20);

			//info.AddValue("n3", 1000);
			//info.AddValue("n4", 2000);

			//info.AddValue("str", "aaaa");
			//info.AddValue("str2", "abc");
			//info.AddValue("str3", "123");

			//MessageBox.Show(info.MemberCount.ToString());
		}

		#endregion
	}

	[Serializable]
	public class MyObjectSubClass
	{
		public string name;
	}

	#endregion
}
