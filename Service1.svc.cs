using System.Collections.Generic;
using System.Linq;

namespace EjemploWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void EliminarUsuario(string user)
        {
            contextoDatosDataContext contexto = new contextoDatosDataContext();
            List<Usuario> datos = (from r in contexto.Usuarios where r.NombreUsuario.Equals(user) select r).ToList();
            if (datos.Count > 0)
            {
                contexto.Usuarios.DeleteOnSubmit(datos.FirstOrDefault());
                contexto.SubmitChanges();
            }
        }

        public void InsertarUsuario(string user, string pass)
        {
            contextoDatosDataContext contexto = new contextoDatosDataContext();
            Usuario add_user = new Usuario();
            add_user.NombreUsuario = user;
            add_user.Pass = pass;
            contexto.Usuarios.InsertOnSubmit(add_user);
            contexto.SubmitChanges();
        }

        public List<Usuario> obtenerUsuarios()
        {
            contextoDatosDataContext contexto = new contextoDatosDataContext();
            return (from r in contexto.Usuarios select r).ToList();
        }

        public bool VerificarAcceso(string user, string pass)
        {
            contextoDatosDataContext contexto = new contextoDatosDataContext();
            List<Usuario> datos = (from r in contexto.Usuarios where r.NombreUsuario.Equals(user) && r.Pass.Equals(pass) select r).ToList();
            return datos.Count > 0 ? true : false;

        }
    }
}
