using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Models;
using StockManagementSystem.Repository;
namespace StockManagementSystem.BLL
{
    public class ItemManager
    {
        ItemRepository _itemRepository;
        public ItemManager()
        {
            _itemRepository = new ItemRepository();
        }
        public int Insert(Item item)
        {
            return _itemRepository.Insert(item);
        }

    }
}
