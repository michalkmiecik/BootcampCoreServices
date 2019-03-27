using System;
using System.Collections.Generic;
using System.Globalization;

namespace BootcampCoreServices
{
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

        public request(string[] array)
        {
            this.clientId = array[0];
            this.requestId = long.Parse(array[1]);
            this.name = array[2];
            this.quantity = int.Parse(array[3]);
            this.price = double.Parse(array[4], CultureInfo.InvariantCulture);
        }

        override public string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", clientId, requestId, name, quantity, price);
        }

        public string[] ToArray()
        {
            string[] result = { clientId, requestId.ToString(), name, quantity.ToString(), price.ToString() };
            return result;
        }
    }

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
