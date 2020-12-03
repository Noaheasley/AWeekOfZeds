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
        public Bullet _bullet;
        private float _durability = 200;
        private float _timer = 0;
        private float _coolDown = 1;
        private bool _coolingDown = false;
        
        
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

        public Player(float x, float y, string nameVal, float healthVal, float damageVal, float moneyVal, float speed, Color raycolor, char icon = 'P', ConsoleColor color = ConsoleColor.White)
            : base(x, y, nameVal, healthVal, damageVal, moneyVal, speed, raycolor, icon, color)
        {
            
            //_sprite = new Sprite("AWZ_Sprites/PlayerPlaceHolder.png");
            
            _points = moneyVal;
           
        }
        
        public override void Update(float deltaTime)
        {
            

            if (_coolingDown == true)
            {
                _timer += deltaTime;
                if (_timer >= _coolDown)
                {
                    RemoveBullet(_bullet);
                    _coolingDown = false;
                    _timer = 0;
                }

            }
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
            }

            if (Game.GetKeyDown((int)KeyboardKey.KEY_UP) && !_coolingDown)
            {
                Bullet bullet = new Bullet(WorldPosition + Forward, Forward, "deathmetal", 1, 1, 0, _sprite, Color.BLUE, 'B', 10, ConsoleColor.Red);
                CreateBullet(bullet);
                _coolingDown = true;
                
            }


           
            
            
            

            Acceleration = new Vector2(xVelocity, yVelocity);
            base.Update(deltaTime);
        }
        
        public void CreateBullet(Bullet bullet)
        {
            _bullet = bullet;
            Scene scene = Game.GetScenes(Game.CurrentSceneIndex);
            scene.AddActor(_bullet);
            bullet.Velocity = Forward * _bullet.Speed;
        }
        public void RemoveBullet(Bullet bullet)
        {
            bullet = _bullet;
            Scene scene = Game.GetScenes(Game.CurrentSceneIndex);
            scene.RemoveActor(_bullet);
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
