using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.IO;

namespace SerializalizationApplication
{
    public class LinkItemSerializer: IXmlSerializable
    {

        static string ns = "http://www.thatindigogirl.com/samples/2006/06";

        public LinkItemSerializer()
        {
        }

        private LinkItem m_linkItem;

        public LinkItem LinkItem
        {
            get { return m_linkItem; }
            set { m_linkItem = value; }
        }

        #region IXmlSerializable Members

        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
			return null;
        }

        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {
            LinkItem item = new LinkItem();

            while (reader.IsStartElement())
            {
                reader.MoveToContent();
                reader.Read();

                if (reader.IsStartElement("Id"))
                {
                    reader.MoveToContent();
                    item.Id = int.Parse(reader.ReadString());
                    reader.MoveToContent();
                    reader.ReadEndElement();
                }
                else
                    throw new XmlException("ExpectedElementMissing: Id element was expected.");

                if (reader.IsStartElement("Title"))
                {
                    reader.MoveToContent();
                    item.Title = reader.ReadString();
                    reader.MoveToContent();
                    reader.ReadEndElement();
                }
                else
                    throw new XmlException("ExpectedElementMissing: Title element was expected.");

                if (reader.IsStartElement("Description"))
                {
                    reader.MoveToContent();
                    item.Description = reader.ReadString();
                    reader.MoveToContent();
                    reader.ReadEndElement();
                }
                else
                    throw new XmlException("ExpectedElementMissing: Description element was expected.");

                if (reader.IsStartElement("DateStart"))
                {
                    reader.MoveToContent();
                    reader.Read();
                    item.DateStart = reader.ReadContentAsDateTime();
                    reader.MoveToContent();
                    reader.ReadEndElement();
                }
                else
                    throw new XmlException("ExpectedElementMissing: DateStart element was expected.");

                if (reader.IsStartElement("DateEnd"))
                {
                    reader.MoveToContent();
                    reader.Read();
                    item.DateEnd = reader.ReadContentAsDateTime();
                    reader.MoveToContent();
                    reader.ReadEndElement();
                }

                if (reader.IsStartElement("Url"))
                {
                    reader.MoveToContent();
                    item.Url = reader.ReadString();

                    reader.MoveToContent();
                    reader.ReadEndElement();
                }
                else
                    throw new XmlException("ExpectedElementMissing: Url element was expected.");

                reader.MoveToContent();
                reader.ReadEndElement();
            }


            this.m_linkItem = item;
        }

        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("Id", ns);
            writer.WriteValue(m_linkItem.Id);
            writer.WriteEndElement();

            writer.WriteElementString("Title", ns, m_linkItem.Title);
            writer.WriteElementString("Description", ns, m_linkItem.Description);

            writer.WriteStartElement("DateStart", ns);
            writer.WriteValue(m_linkItem.DateStart);
            writer.WriteEndElement();

            writer.WriteStartElement("DateEnd", ns);
            writer.WriteValue(m_linkItem.DateEnd);
            writer.WriteEndElement();

            writer.WriteElementString("Url", ns, m_linkItem.Url);
        }

        #endregion
    }
}
