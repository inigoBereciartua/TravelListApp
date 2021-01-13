using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Models
{
    public class TravelItem
    {
        private Travel _travel;
        private Item _item;
        private int _count;
        private bool _checked;

        public int Id { get; set; }

        public Travel Travel { get => _travel; set => _travel = value; }
        public Item Item { get => _item; set => _item = value; }
        public int Count { get => _count; set => _count = value; }
        public bool Checked { get => _checked; set => _checked = value; }

        public TravelItem(Travel travel,Item item, int count){

            Travel = travel;
            Item = item;
            Count = count;
            Checked = false;
        }

        public TravelItem() { }
       
    }
}
