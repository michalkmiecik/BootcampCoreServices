using System;
using System.Collections.Generic;
using System.Globalization;

namespace BootcampCoreServices
{
    /// <summary>
    /// Class that represents a single request in a inputfile.
    /// Name of the class needs to be the same as name for request entry used in input file.
    /// </summary>
    public class request
    {
        public string clientId { get; set; }
        public long requestId { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

        public request() { }

        public request(string clientId, long requestId, string name, int quantity, double price)
        {
            this.clientId = clientId;
            this.requestId = requestId;
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }

        /// <summary>
        /// Method used in readign from CSV file.
        /// </summary>
        /// <param name="array"></param>
        public request(string[] array)
        {
            this.clientId = array[0];
            this.requestId = long.Parse(array[1]);
            this.name = array[2];
            this.quantity = int.Parse(array[3]);
            this.price = double.Parse(array[4], CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns request as single string.
        /// </summary>
        /// <returns></returns>
        override public string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", clientId, requestId, name, quantity, price);
        }

        /// <summary>
        /// Returns request as array of its fields.
        /// </summary>
        /// <returns></returns>
        public string[] ToArray()
        {
            string[] result = { clientId, requestId.ToString(), name, quantity.ToString(), price.ToString() };
            return result;
        }
    }

    /// <summary>
    /// Class for JSON deserializer used as root element.
    /// </summary>
    public class Root
    {
        public List<request> requests { get; set; }

        override public string ToString()
        {
            string output = string.Empty;
            foreach (request r in requests)
            {
                output += r.ToString() + "\r\n";
            }
            return output;
        }
    }
}
