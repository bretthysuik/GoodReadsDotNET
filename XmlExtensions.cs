using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GoodreadsDotNET
{
    public static class XmlExtensions
    {
        public static int IntValue(this XElement element)
        {
            return int.Parse(element.Value);
        }

        public static long LongValue(this XElement element)
        {
            return long.Parse(element.Value);
        }

        public static double DoubleValue(this XElement element)
        {
            return double.Parse(element.Value);
        }
    }
}
