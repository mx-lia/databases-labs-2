using Microsoft.SqlServer.Server;
using System;
using System.Data;
using System.Data.SqlClient;

namespace lab_3
{
    public class StoredProcedure
    {
        [SqlProcedure]
        public static void OrdersPIVOT(DateTime begin_date, DateTime end_date)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection("Context connection = true");
            command.Connection.Open();
            command.CommandText = @"SELECT [count_of_orders], [active], [finished] FROM (SELECT 'count of orders' AS 'count_of_orders', mark_of_delivery FROM
                            orders WHERE order_date >= convert(datetime,@begin_date,120) AND order_date <= convert(datetime,@end_date,120)) x PIVOT (count(mark_of_delivery) 
                            for mark_of_delivery in([active], [finished])) pvt;";
            SqlParameter parameter = command.Parameters.Add("@begin_date", SqlDbType.DateTime);
            parameter.Value = begin_date;
            parameter = command.Parameters.Add("@end_date", SqlDbType.DateTime);
            parameter.Value = end_date;
            SqlContext.Pipe.ExecuteAndSend(command);
            command.Connection.Close();
        }
    }
}
