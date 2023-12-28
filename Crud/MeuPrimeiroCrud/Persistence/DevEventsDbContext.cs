using MeuPrimeiroCrud.Entities;

namespace MeuPrimeiroCrud.Persistence
{
    public class DevEventsDbContext
    {

        public List<DevEvents> DevEvents { get; set; }

        public DevEventsDbContext()
        {
                DevEvents = new List<DevEvents>();       // com isso nao precisamos nos conectar ao banco de dados, ele simula um banco de dados e fica instanciado no program.cs
        }
    }
}
