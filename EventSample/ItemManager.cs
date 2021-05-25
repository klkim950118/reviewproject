using EventSample.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSample
{

    public class ItemManager
    {
        public List<Item> items { get; set; }

        private int count;

        public event ItemEventHandler AddedItem = null;
        public event ItemEventHandler DeletedItem = null;
        public ItemManager()
        {
            items = new List<Item>();
            count = 0;
        }

        public void Additem()
        {
            Item it = new Item { ItemNumber = ++count, ItemDescription = "Test" + count };
            items.Add(it);
            AddedItem?.Invoke(this, new ItemEventArgs(it));
        }

        public void Delitem(int num)
        {
            Item it =  items.Find(x => x.ItemNumber == num);

            if(it != null)
            {
                items.Remove(it);
                DeletedItem?.Invoke(this, new ItemEventArgs(it));
            }
        }
    }
}
