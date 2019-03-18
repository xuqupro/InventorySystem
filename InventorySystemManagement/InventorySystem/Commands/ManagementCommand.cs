using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace InventorySystem.Commands
{
    class ManagementCommand
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

        public ManagementCommand()
        {

        }
        public void LoadDb(string fname)
        {
            try
            {
                Console.WriteLine("Loading File {0}", fname);

                StreamReader sr = new StreamReader(fname);
                int count = Convert.ToInt16(sr.ReadLine());
                inventories = new Inventory[count];

                for (int i = 0; i < count; i++)
                {
                    string[] line = sr.ReadLine().Split(',');
                    string name = line[0];
                    int code = Convert.ToInt32(line[1]);
                    int rate = Convert.ToInt32(line[2]);
                    int stock = Convert.ToInt32(line[3]);
                    string dateBill = line[4];

                    inventories[i] = new Inventory(name, code, rate, stock, dateBill);
                }

                sr.Close();

                Console.WriteLine("{0} records loaded.", count);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Could not open file: ", exc.Message);
            }
        }
        public void SaveDb(string fname)
        {
            try
            {
                Console.WriteLine("Saving File {0}", fname);

                StreamWriter sw = new StreamWriter(fname);
                sw.WriteLine(inventories.Length);

                for (int i = 0; i < inventories.Length; i++)
                {
                    Inventory inventory = inventories[i];

                    sw.WriteLine("{0},{1},{2},{3},{4}", inventory.Name, inventory.Code, inventory.Income, inventory.Stock, inventory.DateBill);
                }

                sw.Close();

                Console.WriteLine("{0} records saved.", inventories.Length);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Could not save file: ", exc.Message);
            }
        }
        public void FindByDay(string date)
        {
            try
            {
                DateTime outDate;
                string[] dateFormats = { "d.M.yy","dd.MM.yyyy","d-M-yy","dd-MM-yyyy", "d/M/yy","dd/MM/yyyy"};
               
                if (DateTime.TryParseExact(date, dateFormats, DateTimeFormatInfo.InvariantInfo,
                    DateTimeStyles.None, out outDate))
                {
                    string valid = outDate.ToString("dd-MM-yyyy");
                    int idDay = FindIdDay(valid);
                    Console.WriteLine("Find Income follow date: {0},{1}", outDate.ToString("dd-MM-yyyy"),idDay);
                    Inventory inventory = inventories[idDay];
                    PrintInventory(inventory);

                }
                else
                {
                    Console.WriteLine("Not valid: {0}", date);
                }
            }catch(Exception exc)
            {
                Console.WriteLine("Could not find data: ", exc.Message);
            }
        }
        public int FindIdDay(string idDay)
        {
            for(int i = 0; i < inventories.Length; i++)
            {
                if (idDay == inventories[i].DateBill)
                {
                    return i;
                }
            }
            return -1;
        }

        public void FindInventory(string itemCode)
        {
            try
            {
                int idConvert = Convert.ToInt32(itemCode);
                if (idConvert < 0)
                {
                    throw new Exception("Item Code Icorrect");
                }
                if(idConvert == -1)
                {
                    throw new Exception("Item Not Found");
                }
                Console.WriteLine("Code Inventory at {0}", idConvert);
                int id = FindItemIndex(idConvert);
                Inventory inventory = inventories[id];
                // Console.WriteLine("{0},{1},{2},{3},{4}", inventory.Name, inventory.Code, inventory.Rate, inventory.Stock, inventory.DateBill);
                PrintInventory(inventory);
            }
            catch (Exception exec)
            {
                Console.WriteLine("Could not find data: ", exec.Message);
            }
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

        public void Quit()
        {
            Console.WriteLine("Thank you for using My System - Inventory Management System");
        }
        public void Help()
        {
            Console.WriteLine("Management Commands: ");
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", "Cmd", "Command", "Params", "Description");
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", "~~~", "~~~~~~~", "~~~~~~", "~~~~~~~~~~~");

            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", "?", "help", null, "Print this help menu");
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", "ldb", "loaddb", "fname", "Loads the database file");
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", "sdb", "savedb", "fname", "Saves current database in file");
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", "q", "quit", null, "Ends the program and returns");

            Console.WriteLine();
        }
        private void PrintInventory(Inventory inventory)
        {
            Console.WriteLine("{0,-20}{1,5}{2,5}{3,10}{4,15}", "Name", "Code", "Income", "Stock", "Date Bill");
            Console.WriteLine("{0,-20}{1,5}{2,5}{3,10}{4,15}", inventory.Name, inventory.Code, inventory.Income, inventory.Stock, inventory.DateBill);
        }
    }
}
