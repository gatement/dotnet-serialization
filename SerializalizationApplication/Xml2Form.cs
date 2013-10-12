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
	public partial class Xml2Form : Form
	{
		private string path = "myObject2.xml";

		public Xml2Form()
		{
			InitializeComponent();
		}

		#region Control event handlers

		private void SerializeButton_Click(object sender, EventArgs e)
		{
			LinkItem linkItem = new LinkItem();
			linkItem.Id = 1;
			linkItem.Title = "MyTitle";
			linkItem.Url = "www.google.com";
			linkItem.Description = "My Description";
			linkItem.DateStart = new DateTime();

			LinkItemSerializer obj = new LinkItemSerializer();
			obj.LinkItem = linkItem;

			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(LinkItemSerializer));
			using(StreamWriter writer = new System.IO.StreamWriter(path))
			{
				serializer.Serialize(writer, obj);
			}

			MessageBox.Show("serialize success");
		}

		private void DeserializeButton_Click(object sender, EventArgs e)
		{
			LinkItemSerializer obj = null;
			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(LinkItemSerializer));

			using(FileStream stream = new FileStream(path, FileMode.Open))
			{
				obj = (LinkItemSerializer)serializer.Deserialize(stream);
			}

			MessageBox.Show(obj.LinkItem.Title);
		}

		#endregion
	}
}
