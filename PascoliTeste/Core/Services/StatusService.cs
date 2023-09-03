using Core.Model;
using Core.Services.Interfaces;

namespace Core.Services
{
    public class StatusService : IStatusService
    {

        public List<Status> GetAllStatus()
        {
            return new List<Status>
            {
                new Status { Title = "Pendente",Value =1 },
                new Status { Title = "Andamento",Value =2 },
                new Status { Title = "Concluída",Value =3 }
            };
        }
    }
}
