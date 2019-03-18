using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Commands
{
    class InventoryCommand
    {
        private Inventory[] inventories;
        public Inventory[] Inventories
        {
            get
            {
                return inventories;
            }

            set
            {
                inventories = value;
            }
        }

        public InventoryCommand()
        {
        }
        public void Help()
        {
            Console.WriteLine("Inventory Commands: ");
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", "Cmd", "Command", "Params", "Description");
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", "~~~", "~~~~~~~", "~~~~~~", "~~~~~~~~~~~");

            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", "li", "listitems", null, "List all items in inventory");
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", "icd", "incomed", "date", "List income items by date");
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", "fi", "findi", "code item", "Find items by code");

            Console.WriteLine();
        }
        public void ListItems()
        {
            if (DataBaseLoaded())
            {
                Console.WriteLine("Inventory report:");

                PrintHeader();

                for (int i = 0; i < inventories.Length; i++)
                {
                    Inventory inventory = inventories[i];

                    Console.WriteLine("{0,-20}{1,5}{2,5}{3,10}{4,15}", inventory.Name, inventory.Code, inventory.Income, inventory.Stock, inventory.DateBill);
                }
            }
        }
        private bool DataBaseLoaded()
        {
            if (inventories == null || inventories.Length == 0)
            {
                Console.WriteLine("Database not loaded. Please use ldb first");

                return false;
            }

            return true;
        }
        
        private int FindItemIndex(int itemCode)
        {
            for (int i = 0; i < inventories.Length; i++)
            {
                // find for item
                if (itemCode == inventories[i].Code)
                {
                    return i;
                }
            }

            return -1;
        }
        private void PrintItem(Inventory inventory)
        {
            Console.WriteLine("Updating inventory");

            Console.WriteLine("{0}-{1}", inventory.Code, inventory.Name);
            Console.WriteLine("Stock: {0}", inventory.Stock);
            Console.WriteLine("Consumption-rate: {0}", inventory.Income);
            Console.WriteLine("Lead-time: {0}", inventory.DateBill);
        }
        private void PrintHeader()
        {
            Console.WriteLine("{0,-20}{1,5}{2,5}{3,10}{4,15}", "Name", "Code", "Income", "Stock", "Date Bill");
            Console.WriteLine("{0,-20}{1,5}{2,5}{3,10}{4,15}", "~~~~", "~~~~", "~~~~", "~~~~~", "~~~~");
        }

    }
}
