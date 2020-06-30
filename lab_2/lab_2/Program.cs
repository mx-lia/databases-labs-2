using lab_2.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose one option:\n 0 - exit \n 1 - insert\n 2 - update \n 3 - delete \n 4 - list of orders");
                Console.Write(" --> ");
                string op = Console.ReadLine();
                if(op == "0")
                {
                    break;
                }
                else if (op == "4")
                {
                    DateTime begin_date, end_date;
                    Console.Write("Begin date (yyyy-mm-dd) ---> ");
                    begin_date = DateTime.Parse(Console.ReadLine());
                    Console.Write("End date (yyyy-mm-dd) ---> ");
                    end_date = DateTime.Parse(Console.ReadLine());
                    SqlManager.GetListOfOrdersByPeriod(begin_date, end_date);
                    continue;
                } 
                else if (op != "1" && op != "2" && op != "3")
                {
                    continue;
                }
                Console.WriteLine("Choose entity:\n 0 - cancel \n 1 - client\n 2 - manager \n 3 - driver \n 4 - vehicle \n 5 - product");
                Console.Write(" --> ");
                switch (Console.ReadLine())
                {
                    case "0": break;
                    case "1":
                        {
                            if (op == "1")
                            {
                                Client client = new Client();
                                Console.Write("Surname ---> ");
                                client.Surname = Console.ReadLine();
                                Console.Write("Name ---> ");
                                client.Name = Console.ReadLine();
                                Console.Write("Patronymic ---> ");
                                client.Patronymic = Console.ReadLine();
                                Console.Write("Phone ---> ");
                                client.Phone = Console.ReadLine();
                                Console.Write("Address ---> ");
                                client.Address = Console.ReadLine();
                                Console.Write("Passport ---> ");
                                client.Passport = Console.ReadLine();
                                Console.Write("Payment account ---> ");
                                client.Payment_account = Console.ReadLine();
                                SqlManager.Insert(client);
                            }
                            else if (op == "2")
                            {
                                Client client = new Client();
                                Console.Write("ID ---> ");
                                client.Client_ID = int.Parse(Console.ReadLine());
                                Console.Write("Surname ---> ");
                                client.Surname = Console.ReadLine();
                                Console.Write("Name ---> ");
                                client.Name = Console.ReadLine();
                                Console.Write("Patronymic ---> ");
                                client.Patronymic = Console.ReadLine();
                                Console.Write("Phone ---> ");
                                client.Phone = Console.ReadLine();
                                Console.Write("Address ---> ");
                                client.Address = Console.ReadLine();
                                Console.Write("Passport ---> ");
                                client.Passport = Console.ReadLine();
                                Console.Write("Payment account ---> ");
                                client.Payment_account = Console.ReadLine();
                                SqlManager.Update(client);
                            }
                            else if (op == "3")
                            {
                                Client client = new Client();
                                Console.Write("ID ---> ");
                                client.Client_ID = int.Parse(Console.ReadLine());
                                SqlManager.Delete(client);
                            }
                        }
                        break;
                    case "2":
                        {
                            if (op == "1")
                            {
                                Manager manager = new Manager();
                                Console.Write("Surname ---> ");
                                manager.Surname = Console.ReadLine();
                                Console.Write("Name ---> ");
                                manager.Name = Console.ReadLine();
                                Console.Write("Patronymic ---> ");
                                manager.Patronymic = Console.ReadLine();
                                Console.Write("Phone ---> ");
                                manager.Phone = Console.ReadLine();
                                SqlManager.Insert(manager);
                            }
                            else if (op == "2")
                            {
                                Manager manager = new Manager();
                                Console.Write("ID ---> ");
                                manager.Manager_ID = int.Parse(Console.ReadLine());
                                Console.Write("Surname ---> ");
                                manager.Surname = Console.ReadLine();
                                Console.Write("Name ---> ");
                                manager.Name = Console.ReadLine();
                                Console.Write("Patronymic ---> ");
                                manager.Patronymic = Console.ReadLine();
                                Console.Write("Phone ---> ");
                                manager.Phone = Console.ReadLine();
                                SqlManager.Update(manager);
                            }
                            else if (op == "3")
                            {
                                Manager manager = new Manager();
                                Console.Write("ID ---> ");
                                manager.Manager_ID = int.Parse(Console.ReadLine());
                                SqlManager.Delete(manager);
                            }
                        }
                        break;
                    case "3":
                        {
                            if (op == "1")
                            {
                                Driver driver = new Driver();
                                Console.Write("Surname ---> ");
                                driver.Surname = Console.ReadLine();
                                Console.Write("Name ---> ");
                                driver.Name = Console.ReadLine();
                                Console.Write("Patronymic ---> ");
                                driver.Patronymic = Console.ReadLine();
                                Console.Write("Vehicle ---> ");
                                driver.Vehicle = SqlManager.GetByVehicleId(int.Parse(Console.ReadLine())) as Vehicle;
                                SqlManager.Insert(driver);
                            }
                            else if (op == "2")
                            {
                                Driver driver = new Driver();
                                Console.Write("ID ---> ");
                                driver.Driver_ID = int.Parse(Console.ReadLine());
                                Console.Write("Surname ---> ");
                                driver.Surname = Console.ReadLine();
                                Console.Write("Name ---> ");
                                driver.Name = Console.ReadLine();
                                Console.Write("Patronymic ---> ");
                                driver.Patronymic = Console.ReadLine();
                                SqlManager.Update(driver);
                            }
                            else if (op == "3")
                            {
                                Driver driver = new Driver();
                                Console.Write("ID ---> ");
                                driver.Driver_ID = int.Parse(Console.ReadLine());
                                SqlManager.Delete(driver);
                            }
                        }
                        break;
                    case "4":
                        {
                            if (op == "1")
                            {
                                Vehicle vehicle = new Vehicle();
                                Console.Write("Model ---> ");
                                vehicle.Model = Console.ReadLine();
                                Console.Write("Number ---> ");
                                vehicle.Number = Console.ReadLine();
                                SqlManager.Insert(vehicle);
                            }
                            else if (op == "2")
                            {
                                Vehicle vehicle = new Vehicle();
                                Console.Write("ID ---> ");
                                vehicle.Vehicle_ID = int.Parse(Console.ReadLine());
                                Console.Write("Model ---> ");
                                vehicle.Model = Console.ReadLine();
                                Console.Write("Number ---> ");
                                vehicle.Number = Console.ReadLine();
                                SqlManager.Update(vehicle);
                            }
                            else if (op == "3")
                            {
                                Vehicle vehicle = new Vehicle();
                                Console.Write("ID ---> ");
                                vehicle.Vehicle_ID = int.Parse(Console.ReadLine());
                                SqlManager.Delete(vehicle);
                            }
                        }
                        break;
                    case "5":
                        {
                            if (op == "1")
                            {
                                Product product = new Product();
                                Console.Write("Name ---> ");
                                product.Name = Console.ReadLine();
                                Console.Write("Description ---> ");
                                product.Description = Console.ReadLine();
                                Console.Write("Weight ---> ");
                                product.Weight = int.Parse(Console.ReadLine());
                                SqlManager.Insert(product);
                            }
                            else if (op == "2")
                            {
                                Product product = new Product();
                                Console.Write("ID ---> ");
                                product.Product_ID = int.Parse(Console.ReadLine());
                                Console.Write("Name ---> ");
                                product.Name = Console.ReadLine();
                                Console.Write("Description ---> ");
                                product.Description = Console.ReadLine();
                                Console.Write("Weight ---> ");
                                product.Weight = int.Parse(Console.ReadLine());
                                SqlManager.Update(product);
                            }
                            else if (op == "3")
                            {
                                Product product = new Product();
                                Console.Write("ID ---> ");
                                product.Product_ID = int.Parse(Console.ReadLine());
                                SqlManager.Delete(product);
                            }
                        }
                        break;
                }
            }
        }
    }
}
