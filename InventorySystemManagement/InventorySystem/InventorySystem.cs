using InventorySystem.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem
{
    class InventorySystem
    {
        private InventoryCommand inventoryCmd;
        private ManagementCommand managementCmd;
        private string[] parameters;

        public void Run()
        {
            inventoryCmd = new InventoryCommand();
            managementCmd = new ManagementCommand();
            PrintWelcome();
            RequestCommand();
        }
        private void PrintWelcome()
        {
            Console.WriteLine("Welcome to My System - Inventory Management System");
            Console.WriteLine("Type ? for help");
        }
        private void RequestCommand()
        {
            Console.Write("cmd> ");
            parameters = Console.ReadLine().ToLower().Split(' ');

            bool quit = false;

            switch (parameters[0])
            {
                case "li":
                case "listitems":
                    inventoryCmd.ListItems();
                    break;
                case "ldb":
                case "loaddb":
                    if (IsValidPameter(1))
                    {
                        managementCmd.LoadDb(parameters[1]);
                        inventoryCmd.Inventories = managementCmd.Inventories;
                    }
                    break;
                case "sdb":
                case "savedb":
                    if (IsValidPameter(1))
                    {
                        managementCmd.SaveDb(parameters[1]);
                    }
                    break;
                case "icd":
                case "incomed":
                    if (IsValidPameter(1))
                    {
                        managementCmd.FindByDay(parameters[1]);
                    }
                    break;
                case "fi":
                case "findi":
                    if (IsValidPameter(1))
                    {
                        managementCmd.FindInventory(parameters[1]);
                    }
                    break;
                case "q":
                case "quit":
                    managementCmd.Quit();
                    quit = true;
                    break;
                case "?":
                case "help":
                    inventoryCmd.Help();
                    managementCmd.Help();
                    break;
                default:
                    Console.WriteLine("Command {0} is not recongnized. Please try again.", parameters[0]);
                    break;
            }

            managementCmd.Inventories = inventoryCmd.Inventories;
            if (!quit)
            {
                RequestCommand();
            }
        }
        private bool IsValidPameter(int paramNumber)
        {
            try
            {
                if (parameters[paramNumber] != "")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid no of arguments. Index was outside the bounds of the array");
                }
            }
            catch
            {
                Console.WriteLine("Invalid no of arguments. Index was outside the bounds of the array");
            }

            return false;
        }
    }

}
