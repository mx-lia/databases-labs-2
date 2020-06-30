using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace lab_11_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SQLiteConnection con;
        SQLiteDataAdapter da;
        SQLiteCommand cmd;
        DataSet ds;

        void GetProductsList()
        {
            con = new SQLiteConnection(@"Data Source=D:\Study\Databases-1\lab_11\transportation.db;Version=3;");
            da = new SQLiteDataAdapter("select * from products", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "products");
            products.DataSource = ds.Tables["products"];
            con.Close();
        }

        void GetOrdersList()
        {
            con = new SQLiteConnection(@"Data Source=D:\Study\Databases-1\lab_11\transportation.db;Version=3;");
            da = new SQLiteDataAdapter("select * from orders", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "orders");
            orders.DataSource = ds.Tables["orders"];
            con.Close();
        }

        void GetClientsList()
        {
            con = new SQLiteConnection(@"Data Source=D:\Study\Databases-1\lab_11\transportation.db;Version=3;");
            da = new SQLiteDataAdapter("select * from clients", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "clients");
            clients.DataSource = ds.Tables["clients"];
            con.Close();
        }

        void GetView()
        {
            con = new SQLiteConnection(@"Data Source=D:\Study\Databases-1\lab_11\transportation.db;Version=3;");
            da = new SQLiteDataAdapter("select * from today_orders", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "today_orders");
            view.DataSource = ds.Tables["today_orders"];
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetProductsList();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedTab.Text)
            {

                case "Products":
                    {
                        GetProductsList();
                        break;
                    }
                case "Orders":
                    {
                        GetOrdersList();
                        break;
                    }
                case "Clients":
                    {
                        GetClientsList();
                        break;
                    }
                case "Today orders":
                    {
                        GetView();
                        break;
                    }
            }
        }

        private void ExecuteCommand(string text)
        {
            con.Open();
            using (var transaction = con.BeginTransaction())
            {
                try
                {
                    cmd = new SQLiteCommand();
                    cmd.Connection = con;
                    cmd.CommandText = text;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch { transaction.Rollback(); }
                finally { con.Close(); }
            }
        }

        private void insertProduct_Click(object sender, EventArgs e)
        {
            ExecuteCommand("insert into products(name, description, weight) values ('" + productName.Text + "','" + productDescription.Text + "','" + productWeight.Value + "')");
            GetProductsList();
        }

        private void updateProduct_Click(object sender, EventArgs e)
        {
            ExecuteCommand("update products set name='" + productName.Text + "',description='" + productDescription.Text + "',weight='" + productWeight.Value+ "' where product_id=" + productId.Text + "");
            GetProductsList();
        }

        private void deleteProduct_Click(object sender, EventArgs e)
        {
            ExecuteCommand("delete from products where product_id=" + productId.Text + "");
            GetProductsList();
        }

        private void insertOrder_Click(object sender, EventArgs e)
        {
            ExecuteCommand("insert into orders(client_id, product_id, order_date) values ('" + orderClient.Text + "','" + orderProduct.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')");
            GetOrdersList();
        }

        private void updateOrder_Click(object sender, EventArgs e)
        {
            ExecuteCommand("update orders set client_id='" + orderClient.Text + "',product_id='" + orderProduct.Text +  "' where order_id=" + orderId.Text + "");
            GetOrdersList();
        }

        private void deleteOrder_Click(object sender, EventArgs e)
        {
            ExecuteCommand("delete from orders where order_id=" + orderId.Text + "");
            GetOrdersList();
        }

        private void insertClient_Click(object sender, EventArgs e)
        {
            ExecuteCommand("insert into clients(surname, name, phone) values ('" + clientSurname.Text + "','" + clientName.Text + "','" + clientPhone.Text + "')");
            GetClientsList();
        }

        private void updateClient_Click(object sender, EventArgs e)
        {
            ExecuteCommand("update clients set surname='" + clientSurname.Text + "',name='" + clientName.Text + "',phone='" + clientPhone.Text + "' where client_id=" + clientId.Text + "");
            GetClientsList();
        }

        private void deleteClient_Click(object sender, EventArgs e)
        {
            ExecuteCommand("delete from clients where client_id=" + clientId.Text + "");
            GetClientsList();
        }
    }
}
