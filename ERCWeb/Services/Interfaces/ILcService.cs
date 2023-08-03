using System.Collections.Generic;
using System.Threading.Tasks;
using ERCWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERCWeb.Services.Interfaces
{
    public interface ILcService
    {
        Task<IEnumerable<LcModel>> ShowAll();

        Task<LcModel> ShowId(int id);

        Task<LcModel> DeleteId(int id);

        Task<LcModel> EditId(int id, LcModel model);

        Task<LcModel> CreateNew(LcModel lc);

        

        //Task<IEnumerable<LcModel>> FindWithResident();
    }
}
