using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Game1
{
    class Conexion
    {
        public SqlConnection conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString =
                "Data Source=.;Initial Catalog=NumberLand;Integrated Security=True";
           // "Data Source=10.144.161.137,1433;Initial Catalog=NumberLand;Integrated Security=False;User ID=xd;Password=G!4ncarlo;Connect Timeout=15;Encrypt=False;Packet Size=4096";
                //"Server=tcp:numberlandazure.database.windows.net,1433;Database=NumberLand;User ID=ad@numberlandazure;Password=G!4ncarlo;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return cn;
        }
    }
}
