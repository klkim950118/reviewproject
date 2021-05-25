using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSample
{
    public sealed class ItemRepository
    {
        #region Singalton
        private static readonly Lazy<ItemRepository> _instance = new Lazy<ItemRepository>(() => new ItemRepository());
        public static ItemRepository Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        #endregion Singalton

        public ItemManager IM { get; }

        private ItemRepository()
        {
            IM = new ItemManager();
        }
    }
}
