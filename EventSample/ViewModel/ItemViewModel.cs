using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSample.ViewModel
{
    public class ItemViewModel:ViewModelBase
    {
        private ItemRepository IR;

        public string TextString { get { return GetProperty(() => TextString); } set { SetProperty(() => TextString, value); } }

        public ItemViewModel()
        {
            IR = ItemRepository.Instance;

            IR.IM.AddedItem += IM_AddedItem;
            IR.IM.DeletedItem += IM_DeletedItem;
        }

        private void IM_DeletedItem(object sender, Event.ItemEventArgs e)
        {
            TextString = $"삭제 이벤트 발생 ItemNumber: {e.itemNum}, ItemDescription{e.itemDescription}";            
        }

        private void IM_AddedItem(object sender, Event.ItemEventArgs e)
        {
            TextString = $"추가 이벤트 발생 ItemNumber: {e.itemNum}, ItemDescription{e.itemDescription}";
        }
    }
}
