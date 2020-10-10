using System;
using System.Collections.Generic;
using System.Text;

namespace Items
{
    class Mythic : Item
    {
        public ItemTier tier = ItemTier.Mythic;

        public Mythic()
        {
            tier = new ItemTier();
        }
    }
}
