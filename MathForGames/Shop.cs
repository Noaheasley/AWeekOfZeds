using System;
using Raylib_cs;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Shop
    {
        private int _money;
        private Item[] _inv;

        public Shop()
        {
            _money = 100;
            _inv = new Item[3]; 
        }

        public Shop(Item[] items)
        {
            _money = 100;
            _inv = items;
        }

        public bool Sell(Player player, int itemIndex, int playerIndex)
        {
            Item itemToBuy = _inv[itemIndex];
            if(player.Buy(_inv[itemIndex], playerIndex))
            {
                _money += itemToBuy._cost;
                return true;
            }
            return false;
        }

        public void Draw()
        {
            Raylib.DrawText("Welcome to my shop", 100, 100, 100, Color.WHITE);
        }
    }
}
