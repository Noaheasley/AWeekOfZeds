using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Item : Actor
    {
        public int _statBoost;
        public int _cost;
        public string _name;
        private Player _player;

        Item(Sprite sprite, float x, float y, string nameVal, float healthVal, float damageVal, float moneyVal, Color raycolor, char icon = ' ',  ConsoleColor color = ConsoleColor.White)
            : base(sprite, x, y, nameVal, healthVal, damageVal, moneyVal, Color.GOLD, 'S', ConsoleColor.White)
        {
            sprite = new Sprite("AWZ_Sprites");
            _collisionRadius = 1;
        }

        public bool CheckBalance()
        {
            if(_player._money != _cost)
            {
                return false;
            }
            else if(_player._money == _cost)
            {
                return true;
            }
            return false;
        }
    }
}
