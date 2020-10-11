using System;
using System.Collections.Generic;
using System.Text;

namespace Items
{
    class Mythic : Item
    {
        public int tier;

        public Mythic()
        {
            tier = ItemTier.Mythic;
        }
    }
}
