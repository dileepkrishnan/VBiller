#region

using System.Collections.Generic;
using VenusBiller.Entities;
using VenusBiller.Services.Dao;

#endregion

namespace VenusBiller.Services
{
    public class ItemService
    {
        public List<Item> GetAllItems()
        {
            return ItemDao.GetAll();
        }

        public Item GetItemByCode(string code)
        {
            return ItemDao.GetOneByCode(code);
        }
    }
}