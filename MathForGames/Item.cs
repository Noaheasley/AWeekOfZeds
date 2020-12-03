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
        

        public Item(float x, float y, string nameVal, float healthVal, float damageVal, float moneyVal, float speed, Color raycolor, char icon = ' ',  ConsoleColor color = ConsoleColor.White)
            : base( x, y, nameVal, healthVal, damageVal, moneyVal, speed, Color.GOLD, 'S', ConsoleColor.White)
        {
            _collisionRadius = 1;
        }

        public bool CheckBalance()
        {
            if(_player._points != _cost)
            {
                return false;
            }
            else if(_player._points == _cost)
            {
                return true;
            }
            return false;
        }
        public override void OnCollision(Actor other)
        {
            if(other is Enemy)
            {
                _isDead = true;
            }
            if(other is Player)
            {
                _interacted = true;
            }
            base.OnCollision(other);
        }
    }
}
