using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Game1.DAO
{
    public class DAO_Pregunta
    {
  //Singleton
        public static DAO_Pregunta instancia=null;
        protected DAO_Pregunta() { }
        public static DAO_Pregunta Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new DAO_Pregunta();

                return instancia;
            }
        }
        // fin singleton



        public int enviar_pregunta(String _respuesta,String cod_puzzle, int id_Puzzle,int id_Usuario)
        {
            SqlCommand cmd = null;
            Conexion cn = new Conexion();
            SqlConnection cnx = cn.conectar();
            SqlDataReader dr = null;
            int filas=0;


            try
            {
                cnx.Open();
                cmd = new SqlCommand("Validar_Respuesta", cnx);
                cmd.Parameters.AddWithValue("@respuesta", _respuesta);
                cmd.Parameters.AddWithValue("@codpuzzle", cod_puzzle);
                cmd.Parameters.AddWithValue("@idpuzzle", id_Puzzle);
                cmd.Parameters.AddWithValue("@idusuario", id_Usuario);
                cmd.CommandType = CommandType.StoredProcedure;
                
                filas = cmd.ExecuteNonQuery();//devuelve numero de filas insertadas  :v
               


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
