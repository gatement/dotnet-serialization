using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.IO;
using System.Xml;

namespace SerializalizationApplication
{
	public partial class DataContractForm : Form
	{
		public DataContractForm()
		{
			InitializeComponent();
		}

		#region Control event handlers

		private void CreateAndSerializePerson2Button_Click(object sender, EventArgs e)
		{
			CreateAndSerializePerson2("person2.xml");
		}

		private void DeserializePerson1AndSerializeAgainButton_Click(object sender, EventArgs e)
		{
			DeserializePerson1AndSerializeAgain("person2.xml", "person1.xml");
		}

		private void DeserializePerson2Button_Click(object sender, EventArgs e)
		{
			DeserializePerson2("person1.xml");
		}

		#endregion

		#region Helper methods

		private static void CreateAndSerializePerson2(string person2Path)
		{
			Person2 person2 = new Person2();
			person2.Name = "Johnson";
			person2.ID = 2006;

			DataContractSerializer serializer = new DataContractSerializer(typeof(Person2));

			using(FileStream fileStream = new FileStream(person2Path, FileMode.Create))
			{
				serializer.WriteObject(fileStream, person2);
			}

			MessageBox.Show(String.Format("Name: {0}\n\nId: {1}\n", person2.Name, person2.ID));
		}

		private static void DeserializePerson1AndSerializeAgain(string person2Path, string person1Path)
		{
			Person1 person1 = null;
			DataContractSerializer serializer = new DataContractSerializer(typeof(Person1));

			using(FileStream fileStream = new FileStream(person2Path, FileMode.Open))
			{
				//XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
				//person1 = (Person1)serializer.ReadObject(reader, false);

				person1 = (Person1)serializer.ReadObject(fileStream);
			}

			MessageBox.Show(String.Format("Name: {0}", person1.Name));

			person1.Name = "Tim";

			using(FileStream fileStream = new FileStream(person1Path, FileMode.Create))
			{
				serializer.WriteObject(fileStream, person1);
			}
		}

		private static void DeserializePerson2(string person1Path)
		{
			Person2 person2 = null;

			using(FileStream fileStream = new FileStream(person1Path, FileMode.Open))
			{
				DataContractSerializer serializer = new DataContractSerializer(typeof(Person2));
				person2 = (Person2)serializer.ReadObject(fileStream);
			}

			MessageBox.Show(String.Format("Name: {0}\n\nId: {1}\n", person2.Name, person2.ID));
		}

		#endregion
	}

	#region DataContract

	[DataContract(Name = "Person1", Namespace = "http://www.cohowinery.com/employees")]
	class Person1 : IExtensibleDataObject  // without it, everything is OK, why???
	{
		[DataMember]
		public string Name;

		private ExtensionDataObject extensionDataObject_value;
		public ExtensionDataObject ExtensionData
		{
			get
			{
				return extensionDataObject_value;
			}
			set
			{
				extensionDataObject_value = value;
			}
		}
	}


	[DataContract(Name = "Person2", Namespace = "http://www.cohowinery.com/employees")]
	class Person2 : IExtensibleDataObject
	{
		[DataMember(Order = 2)]
		public int ID;

		[DataMember]
		public string Name;

		private ExtensionDataObject extensionDataObject_value;
		public ExtensionDataObject ExtensionData
		{
			get
			{
				return extensionDataObject_value;
			}
			set
			{
				extensionDataObject_value = value;
			}
		}
	}

	#endregion
}
