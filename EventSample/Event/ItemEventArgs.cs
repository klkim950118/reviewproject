using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSample.Event
{
    public delegate void ItemEventHandler(object sender, ItemEventArgs e);
    public class ItemEventArgs
    {
        public Item item { get; private set; }

        public int itemNum { get{ return item.ItemNumber; } }
        public string itemDescription { get { return item.ItemDescription; } }
        public ItemEventArgs(Item item)
        {
            this.item = item;
        }
    }
}
