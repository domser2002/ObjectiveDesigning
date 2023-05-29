using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public static class SerializationHelper
    {
        public static System.Xml.Schema.XmlSchema? GetSchema(this IMyCommand command)
        {
            return null;
        }

        public static void ReadXml(this IMyCommand command,System.Xml.XmlReader reader)
        {
            reader.MoveToContent();

            Boolean isEmptyElement = reader.IsEmptyElement; // (1)
            reader.ReadStartElement();
            //if (!isEmptyElement) // (1)
            //{
            //    var str = reader.ReadContentAsString();
            //    string[] sa = str.Split(' ');
            //    Amount = double.Parse(sa[0]);
            //    CurrencyCode = sa[1];
            //    reader.ReadEndElement();
            //}
        }
        public static void WriteXml(this IMyCommand command,System.Xml.XmlWriter writer)
        {
            writer.WriteString(command.CommandName);
            foreach (var arg in command.Arguments)
            {
                writer.WriteString(" " + arg);
            }
        }
    }
}
