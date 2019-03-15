using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem
{
    class Inventory
    {
        private string name;
        private int code;
        private int rate;
        private int stock;
        private string dateBill;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public int Rate
        {
            get
            {
                return rate;
            }

            set
            {
                rate = value;
            }
        }

        public int Stock
        {
            get
            {
                return stock;
            }

            set
            {
                stock = value;
            }
        }

        public string DateBill
        {
            get
            {
                return dateBill;
            }

            set
            {
                dateBill = value;
            }
        }

        public Inventory(string name, int code, int rate, int stock, string date)
        {
            this.name = name;
            this.code = code;
            this.rate = rate;
            this.stock = stock;
            this.dateBill = date;
        }
    }
}
