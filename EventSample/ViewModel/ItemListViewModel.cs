using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSample.ViewModel
{
    public class ItemListViewModel:ViewModelBase
    {
        ItemRepository IR;
        public ObservableCollection<Item> Itemlist { get; }
        public DelegateCommand Add { get; private set;}
        public DelegateCommand Del { get; private set; }
        public Item SelectItem { get { return GetProperty(() => SelectItem); } set { SetProperty(() => SelectItem,value); }  }
        public ItemListViewModel()
        {
            IR = ItemRepository.Instance;
            Itemlist = new ObservableCollection<Item>();
            Add = new DelegateCommand(AddItem);
            Del = new DelegateCommand(DelItem, CheckCount);

            IR.IM.AddedItem += IM_AddedItem;
            IR.IM.DeletedItem += IM_DeletedItem;
        }

        private void IM_DeletedItem(object sender, Event.ItemEventArgs e)
        {
            Item it = e.item;

            it=  Itemlist.FirstOrDefault(x => x.ItemNumber == it.ItemNumber);

            if(it != null)
            {
                Itemlist.Remove(it);
            }
        }

        private void IM_AddedItem(object sender, Event.ItemEventArgs e)
        {
            Item item = e.item;
            Itemlist.Add(item);
        }

        private bool CheckCount()
        {
            if(Itemlist == null)
            {
                return false;
            }
            if (Itemlist.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DelItem()
        {
            if(SelectItem != null)
            {
                IR.IM.Delitem(SelectItem.ItemNumber);
            }
        }

        private void AddItem()
        {
            IR.IM.Additem();
        }
    }
}
