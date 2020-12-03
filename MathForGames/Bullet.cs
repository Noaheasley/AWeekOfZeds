using System;
using System.Timers;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Bullet : Actor
    {
        
        private Vector2 _position = new Vector2();
        private Vector2 _direction = new Vector2();

        public Bullet(Vector2 position, Vector2 direction,string nameVal,float healthVal,float damageVal,float moneyVal, Sprite sprite, Color raycolor, char icon = 'B', float speed = 10, ConsoleColor color = ConsoleColor.White)
            :base(position.X, position.Y, nameVal, healthVal, damageVal, moneyVal, speed, raycolor, icon, color)
        {
            Velocity = new Vector2(position.X, position.Y);
            _position = position;
            _direction = direction;
            _sprite = sprite;
            _speed = speed;
            
        }
        public override void OnCollision(Actor other)
        {
            if(other is Enemy)
            {
                _isDead = true;
            }
            base.OnCollision(other);
        }
    }
}
