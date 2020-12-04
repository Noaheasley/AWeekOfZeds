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
        

        public Item(float x, float y, string nameVal, float healthVal, float damageVal, float moneyVal, float speed, Color raycolor, char icon = ' ',  ConsoleColor color = ConsoleColor.White)
            : base( x, y, nameVal, healthVal, damageVal, moneyVal, speed, Color.GRAY, 'G', ConsoleColor.White)
        {
            _collisionRadius = 1;
        }

        
        
    }
}
