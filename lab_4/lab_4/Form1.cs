using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_4
{
    public partial class Form1 : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public Form1()
        {
            InitializeComponent();

            string sql = "SELECT * FROM BLR WHERE ID in (SELECT ID FROM BLR INTERSECT SELECT location_id FROM orders)";
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        cities.Text += $"{reader.GetValue(0)} -- {reader.GetValue(3)} -- {reader.GetValue(5)} -- {reader.GetValue(11)}\n";
                    }
                }
                reader.Close();
            }
        }

        private void union_Click(object sender, EventArgs e)
        {
            string sql = "orders_union";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cities.Text += reader.GetValue(0).ToString();
                    }
                }
                reader.Close();
            }
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            string sql = "GetDistance";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parm = new SqlParameter
                {
                    ParameterName = "@FirstOrder",
                    Value = firstCity.Text
                };
                command.Parameters.Add(parm);
                parm = new SqlParameter
                {
                    ParameterName = "@SecondOrder",
                    Value = secondCity.Text
                };
                command.Parameters.Add(parm);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        distance.Text = reader.GetValue(0).ToString();
                    }
                }
                reader.Close();
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            string sql = "AddPoint";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parm = new SqlParameter
                {
                    ParameterName = "@values",
                    Value = point.Text
                };
                command.Parameters.Add(parm);
                parm = new SqlParameter
                {
                    ParameterName = "@orderId",
                    Value = cityId.Value
                };
                command.Parameters.Add(parm);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        points.Text = "Всего точек: " + reader.GetValue(0).ToString();
                    }
                }
                reader.Close();
            }
        }
    }
}
