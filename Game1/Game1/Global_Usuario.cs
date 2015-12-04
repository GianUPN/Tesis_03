using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    public class Global_Usuario
    {
        private int id;
     
        private String usuario;
        private String contrasena;
        private bool estado;

        private static Global_Usuario instance;

        private Global_Usuario() { }

        public static Global_Usuario Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Global_Usuario();
                }
                return instance;
            }
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getid()
        {
            return id;
        }

       

        public void setUsuario(String usuario)
        {
            this.usuario = usuario;
        }

        public String getUsuario()
        {
            return usuario;
        }

        public void setContrasena(String contrasena)
        {
            this.contrasena = contrasena;
        }

        public String getContrasena()
        {
            return contrasena;
        }

        public void setEstado(bool estado)
        {
            this.estado = estado;
        }

        public bool getEstado()
        {
            return estado;
        }


    }

}
