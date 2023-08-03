using ERCWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERCWeb.Services.Interfaces
{
    public interface IResidentService
    {
        Task<IEnumerable<ResidentModel>> ShowAll();

        Task<ResidentModel> CreateNew(ResidentModel resident);
    }
}
