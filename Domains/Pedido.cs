using System;

namespace EFCore.Domains
{
    /// <summary>
    /// Classe Pedido
    /// </summary>
    public class Pedido : BaseDomain
    //Guid - código único de incrementação, segurança do ID, é interessante utilizar na Primary Key
    //Domains - "Classes" das coisas
    {
       

        public string status { get; set; }

        public DateTime OrderDate { get; set; }

        
       

    }
}
