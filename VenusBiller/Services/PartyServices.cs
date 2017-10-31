#region

using System.Collections.Generic;
using VenusBiller.Entities;
using VenusBiller.Services.Dao;

#endregion

namespace VenusBiller.Services
{
    public class PartyService
    {
        public List<Party> GetPartiesByName(string name)
        {
            return PartyDao.GetManyByName(name);
        }

        public List<Party> GetAllParties()
        {
            return PartyDao.GetAll();
        }

        public Party GetPartyByCode(string code)
        {
            return PartyDao.GetOneByCode(code);
        }
    }
}