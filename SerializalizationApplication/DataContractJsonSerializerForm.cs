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
using System.Runtime.Serialization.Json;

namespace SerializalizationApplication
{
	public partial class DataContractJsonSerializerForm : Form
	{
		public DataContractJsonSerializerForm()
		{
			InitializeComponent();
		}

		#region Control event handlers

		private void SerializeButton_Click(object sender, EventArgs e)
		{
			Serialize("Dog.txt");
		}

		private void DeserializeButton_Click(object sender, EventArgs e)
		{
			Deserialize("Dog.txt");
		}

		private void DeserializeToDog2Button_Click(object sender, EventArgs e)
		{
			DeserializeToDog2("Dog.txt");
		}

		#endregion

		#region Helper methods

		private static void Serialize(string path)
		{
			Dog dog = new Dog();
			dog.Name = "WanWan";
			dog.ID = 2006;
			dog.Birthday = DateTime.Now;

			dog.Address = new Address
			{
				City = "GuangZhou",
				Street = "XianLie",
				Floor = 4
			};

			DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dog));

			using(FileStream fileStream = new FileStream(path, FileMode.Create))
			{
				serializer.WriteObject(fileStream, dog);
			}

			MessageBox.Show(String.Format("Name: {0}\n\nId: {1}\n", dog.Name, dog.ID));
		}

		private static void Deserialize(string path)
		{
			Dog dog = null;

			using(FileStream fileStream = new FileStream(path, FileMode.Open))
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dog));
				dog = (Dog)serializer.ReadObject(fileStream);
			}

			MessageBox.Show(String.Format("Name: {0}\n\nId: {1}\n", dog.Name, dog.ID));
		}

		private static void DeserializeToDog2(string path)
		{
			Dog2 dog2 = null;

			using(FileStream fileStream = new FileStream(path, FileMode.Open))
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dog2));
				dog2 = (Dog2)serializer.ReadObject(fileStream);
			}

			MessageBox.Show(String.Format("Id: {0}\n", dog2.ID));
		}

		#endregion

	}

	#region DataContract

	[DataContract(Name = "Dog", Namespace = "http://www.cohowinery.com/employees")]
	public class Dog
	{
		// DataMember control the following:
		// 1. sequence(by default, Alphabetical)
		// 2. need to be serialized
		// 3. IsRequired

		[DataMember(Order = 1)]
		public int ID;

		[DataMember(Order = 3)]
		public string Name;

		[DataMember(Order = 2)]
		public DateTime Birthday;

		[DataMember(Order = 400)]
		public Address Address;
	}

	[DataContract(Name = "Address", Namespace = "http://www.cohowinery.com/employees")]
	public class Address
	{
		[DataMember(Order = 1)]
		public string City;

		[DataMember(Order = 2)]
		public string Street;

		[DataMember(Order = 3)]
		public int Floor;
	}


	[DataContract(Name = "Dog", Namespace = "http://www.cohowinery.com/employees")]
	public class Dog2
	{
		[DataMember(Order = 1)]
		public int ID;

		[DataMember(Order = 2)]
		public string Name;

		[DataMember(Order = 3)]
		public DateTime Birthday;

		[DataMember(Order = 4)]
		public Address Address;

		[DataMember(Order = 5, IsRequired=true)]
		public string FirstName;
	}
	#endregion
}
