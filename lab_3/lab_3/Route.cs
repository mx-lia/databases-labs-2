using Microsoft.SqlServer.Server;
using System;
using System.Data.SqlTypes;
using System.IO;

namespace lab_3
{
    [Serializable]
    [SqlUserDefinedType(Format.UserDefined, MaxByteSize = 8000)]
    public struct Route : INullable, IBinarySerialize
    {
        string arrival_city;
        string destination_city;

        public override string ToString()
        {
            return $"Route: {arrival_city.ToString()}";
        }

        public bool IsNull
        {
            get
            {
                return _null;
            }
        }

        public static Route Null
        {
            get
            {
                Route route = new Route();
                route._null = true;
                return route;
            }
        }

        public static Route Parse(SqlString str)
        {
            string[] cities = str.Value.Split(',');
            if (str.IsNull)
                return Null;

            Route route = new Route();
            route.arrival_city = Convert.ToString(cities[0]);
            route.destination_city = Convert.ToString(cities[1]);
            return route;
        }

        public string Method1()
        {
            return string.Empty;
        }

        public static SqlString Method2()
        {
            return new SqlString("");
        }

        public void Read(BinaryReader reader)
        {
            arrival_city = reader.ReadString();
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(arrival_city.ToString() + " - " + destination_city.ToString());
        }

        public int _var1;

        private bool _null;
    }
}
