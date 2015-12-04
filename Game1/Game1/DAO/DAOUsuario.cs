using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Game1.DAO
{
    public class DAO_Usuario
    {
          //Singleton
        public static DAO_Usuario instancia=null;
        protected DAO_Usuario() { }
        public static DAO_Usuario Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new DAO_Usuario();

                return instancia;
            }
        }
        // fin singleton



        public int Buscar_Usuario(String _user,String _pass)
        {
            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = cn.conectar();
            SqlDataReader dr = null;
            int filas=0;

            try
            {
                cnx.Open();
                cmd = new SqlCommand("sp_BuscarUsuario", cnx);
                cmd.Parameters.AddWithValue("@usuario", _user);
                cmd.Parameters.AddWithValue("@pass", _pass);
                cmd.CommandType = CommandType.StoredProcedure;
                
                dr = cmd.ExecuteReader();
               

                if (dr.Read())
                {
                    
                    filas = 1;
                    
                    Global_Usuario.Instance.setId(Convert.ToInt32(dr["id"]));
                   
                    Global_Usuario.Instance.setUsuario( dr["Usuario"].ToString());
                    Global_Usuario.Instance.setContrasena(dr["Contrasena"].ToString());

                    
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnx.Close();
                cnx.Dispose();
            }
            return filas;
        }
    }
}
