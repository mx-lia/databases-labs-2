using lab_2.Entities;
using System;
using System.Configuration;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;

namespace lab_2
{
    static class SqlManager
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static object GetByVehicleId(int id)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                 return db.GetTable<Vehicle>().Where(x => x.Vehicle_ID == id).SingleOrDefault();
            }
        }

        public static void GetListOfOrdersByPeriod(DateTime begin_date, DateTime end_date)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "SELECT * FROM orders WHERE order_date >= @begin_date AND order_date <= @end_date";
                SqlCommand command = new SqlCommand();
                command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@begin_date", begin_date);
                command.Parameters.AddWithValue("@end_date", end_date);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("\n{0} {1} {2} {3} {4}\t{5}\t\t{6}\t{7}", reader.GetName(0), reader.GetName(1), reader.GetName(2),
                        reader.GetName(3), reader.GetName(4), reader.GetName(5), reader.GetName(6), reader.GetName(7));
                    while (reader.Read())
                    {
                        object order_id = reader.GetValue(0);
                        object client_id = reader.GetValue(1);
                        object product_id = reader.GetValue(2);
                        object driver_id = reader.GetValue(3);
                        object manager_id = reader.GetValue(4);
                        object order_date = reader.GetValue(5);
                        object delivery_date = reader.GetValue(6);
                        object mark_of_delivery = reader.GetValue(7);

                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t\t{5}\t{6}\t{7}", order_id, client_id, product_id, driver_id, manager_id, order_date, delivery_date, mark_of_delivery);
                    }
                }
                else
                {
                    Console.WriteLine("Data doesn't found");
                }
                Console.WriteLine();
                reader.Close();
            }
        }

        public static void Insert(object item)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                if (item is Client client)
                {
                    db.GetTable<Client>().InsertOnSubmit(client);
                    db.SubmitChanges();
                }
                else if (item is Manager manager)
                {
                    db.GetTable<Manager>().InsertOnSubmit(manager);
                    db.SubmitChanges();
                }
                else if (item is Driver driver)
                {
                    db.GetTable<Driver>().InsertOnSubmit(driver);
                    db.SubmitChanges();
                }
                else if (item is Vehicle vehicle)
                {
                    db.GetTable<Vehicle>().InsertOnSubmit(vehicle);
                    db.SubmitChanges();
                }
                else if (item is Product product)
                {
                    db.GetTable<Product>().InsertOnSubmit(product);
                    db.SubmitChanges();
                }
                else if (item is Order order)
                {
                    db.GetTable<Order>().InsertOnSubmit(order);
                    db.SubmitChanges();
                }
                Console.WriteLine("Object is added.");
            }
        }

        public static void Update(object item)
        {
            using (DataContext db = new DataContext(connectionString))
            {
                if (item is Client new_client)
                {
                    Client client = db.GetTable<Client>().Where(x => x.Client_ID == new_client.Client_ID).SingleOrDefault();
                    client.Surname = new_client.Surname;
                    client.Name = new_client.Name;
                    client.Patronymic = new_client.Patronymic;
                    client.Phone = new_client.Phone;
                    client.Address = new_client.Address;
                    client.Passport = new_client.Passport;
                    client.Payment_account = new_client.Payment_account;
                    db.SubmitChanges();
                }
                else if (item is Manager new_manager)
                {
                    Manager manager = db.GetTable<Manager>().Where(x => x.Manager_ID == new_manager.Manager_ID).SingleOrDefault();
                    manager.Surname = new_manager.Surname;
                    manager.Name = new_manager.Name;
                    manager.Patronymic = new_manager.Patronymic;
                    manager.Phone = new_manager.Phone;
                    db.SubmitChanges();
                }
                else if (item is Driver new_driver)
                {
                    Driver driver = db.GetTable<Driver>().Where(x => x.Driver_ID == new_driver.Driver_ID).SingleOrDefault();
                    driver.Surname = new_driver.Surname;
                    driver.Name = new_driver.Name;
                    driver.Patronymic = new_driver.Patronymic;
                    db.SubmitChanges();
                }
                else if (item is Vehicle new_vehicle)
                {
                    Vehicle vehicle = db.GetTable<Vehicle>().Where(x => x.Vehicle_ID == new_vehicle.Vehicle_ID).SingleOrDefault();
                    vehicle.Model = new_vehicle.Model;
                    vehicle.Number = new_vehicle.Number;
                    db.SubmitChanges();
                }
                else if (item is Product new_product)
                {
                    Product product = db.GetTable<Product>().Where(x => x.Product_ID == new_product.Product_ID).SingleOrDefault();
                    product.Name = new_product.Name;
                    product.Description = new_product.Description;
                    product.Weight = new_product.Weight;
                    db.SubmitChanges();
                }
                else if (item is Order new_order)
                {
                    Order order = db.GetTable<Order>().Where(x => x.Order_ID == new_order.Order_ID).SingleOrDefault();
                    order.Order_date = new_order.Order_date;
                    order.Delivery_date = new_order.Delivery_date;
                    order.Mark_of_delivery = new_order.Mark_of_delivery;
                    db.SubmitChanges();
                }
                Console.WriteLine("Object is updated");
            }
        }

        public static int Delete(object item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = "";
                SqlCommand command = new SqlCommand();
                if (item is Client client)
                {
                    sqlExpression = "DELETE FROM clients WHERE client_id = @id";
                    command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@id", client.Client_ID);
                }
                else if (item is Manager manager)
                {
                    sqlExpression = "DELETE FROM managers WHERE manager_id = @id";
                    command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@id", manager.Manager_ID);
                }
                else if (item is Driver driver)
                {
                    sqlExpression = "DELETE FROM drivers WHERE driver_id = @id";
                    command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@id", driver.Driver_ID);
                }
                else if (item is Vehicle vehicle)
                {
                    sqlExpression = "DELETE FROM vehicles WHERE vehicle_id = @id";
                    command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@id", vehicle.Vehicle_ID);
                }
                else if (item is Product product)
                {
                    sqlExpression = "DELETE FROM products WHERE product_id = @id";
                    command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@id", product.Product_ID);
                }
                else if (item is Order order)
                {
                    sqlExpression = "DELETE FROM orders WHERE order_id = @id";
                    command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@id", order.Order_ID);
                }
                Console.WriteLine("Object is deleted");
                return command.ExecuteNonQuery();
            }
        }
    }
}
