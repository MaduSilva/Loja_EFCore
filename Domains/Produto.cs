namespace EFCore.Domains

//Domains - "Classes" das coisas
//Guid - código único de incrementação, segurança do ID, é interessante utilizar na Primary Key
{
    /// <summary>
    /// Classe Produto
    /// </summary>
    public class Produto : BaseDomain
    {
       
        public string Nome { get; set; }

        public float Preco { get; set; }

       
    }
}