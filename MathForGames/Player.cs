using System;
using System.Timers;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Player : Actor
    {
        

        private float _speed = 5;
        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }
        public Player(float x, float y, string nameVal, float healthVal, float damageVal, float moneyVal, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, nameVal, healthVal, damageVal, moneyVal, icon, color)
        {
            _sprite = new Sprite("AWZ_Sprites/PlayerPlaceHolder.png");
            
            _points = moneyVal;
            
            
        }
        public Player() : base()
        {
          
            _points = 0;
            
        }

        public Player(float x, float y, string nameVal, float healthVal, float damageVal, float moneyVal, Color raycolor, char icon = 'P', ConsoleColor color = ConsoleColor.White)
            : base(x, y, nameVal, healthVal, damageVal, moneyVal, raycolor, icon, color)
        {
            
            //_sprite = new Sprite("AWZ_Sprites/PlayerPlaceHolder.png");
            
            _points = moneyVal;
           
        }
        
        public override void Update(float deltaTime)
        {
            int xVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));
            int yVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));

            if(Game.GetKeyDown((int)KeyboardKey.KEY_LEFT))
            {
                Rotate(.5f);

                Vector2 direction = (LocalPosition - WorldPosition).Normalized;

                float angle = Vector2.FindAngle(Forward, direction);

                _angle = angle;
            }
            if (Game.GetKeyDown((int)KeyboardKey.KEY_RIGHT))
            {
                Rotate(-.5f);

                Vector2 direction = (LocalPosition - WorldPosition).Normalized;

                float angle = Vector2.FindAngle(Forward, direction);

                _angle = angle;
            }

            Acceleration = new Vector2(xVelocity, yVelocity);
            

            base.Update(deltaTime);
        }
        
        public bool Buy(Item item)
        {
            if(_points >= item._cost)
            {
                _points -= item._cost;
                return true;
            }
            return false;
        }

        public void MoneyGain(Player player, Enemy enemy)
        {
            player._points += enemy._points;
        }

        public float GetMoney()
        {
            return _points;
        }

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            
            base.Draw();
        }
        
        public override void OnCollision(Actor other)
        {
            if (other is Enemy)
            {
                _isDead = true;
            }
            else if(other is Item)
            {
                _interacted = true;
            }
            base.OnCollision(other);
        }
    }
}
