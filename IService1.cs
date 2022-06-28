using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace EjemploWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Usuario> obtenerUsuarios();

        [OperationContract]
        bool VerificarAcceso(string user, string pass);

        [OperationContract]
        void InsertarUsuario(string user, string pass);


    }



    // Use a data contract as illustrated in the sample below to add composite types to service operations.

}
