using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem
{
    class Inventory
    {
        private string name;
        private int code;
        private int income;
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

        public int Income
        {
            get
            {
                return income;
            }

            set
            {
                income = value;
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

        public Inventory(string name, int code, int income, int stock, string date)
        {
            this.name = name;
            this.code = code;
            this.income = income;
            this.stock = stock;
            this.dateBill = date;
        }
    }
}
