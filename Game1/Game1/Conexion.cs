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
            //"Data Source=10.22.0.61,1433;Initial Catalog=BD_Incidentes;Integrated Security=False;User ID=sa;Password=Odebrecht2015;Connect Timeout=15;Encrypt=False;Packet Size=4096";

            return cn;
        }
    }
}
