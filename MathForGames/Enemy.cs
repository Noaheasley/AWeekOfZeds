using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Enemy : Actor
    {
        public bool _deadZombie;
        public bool _approveRespawn;
        private Actor _target;
        private Color _alertColor;
        

        public Actor Target
        {
            get { return _target; }
            set { _target = value; }
        }
        public Enemy(float x, float y, string nameVal, float healthVal, float damageVal ,float moneyVal, char icon = 'Z', ConsoleColor color = ConsoleColor.White)
            : base(x, y,nameVal , healthVal, damageVal, moneyVal, icon, color)
        {
            //_sprite = new Sprite("AWZ_Sprites/Zed.png");
            _collisionRadius = 1;
        }

        public Enemy(float x, float y, string nameVal, float healthVal, float damageVal, float moneyVal, float speed, Color raycolor, char icon = 'Z', ConsoleColor color = ConsoleColor.White)
            : base(x, y, nameVal,healthVal,damageVal,moneyVal, speed, raycolor, icon, color)
        {
            //_sprite = new Sprite("AWZ_Sprites/Zed.png");
            _alertColor = Color.RED;
            _collisionRadius = 1;
        }
        //allows the enemy to detect a target
        public bool GetTargetInSight(float maxAngle, float maxDistance)
        {
            if (Target == null)
                return false;

            Vector2 direction = Target.LocalPosition - LocalPosition;
            float distance = (Target.LocalPosition - LocalPosition).Magnitude;
            float angle = (float)Math.Acos(Vector2.DotProduct(Forward, direction.Normalized));

            if (angle <= maxAngle && distance <= maxDistance)
                return true;


            return false;
        }
         //Find Angle function

        public void TrackTargetInSight(Vector2 position)
        {
            Vector2 direction = (position - WorldPosition).Normalized;

            float angle = Vector2.FindAngle(Forward, direction);

            Rotate(-angle);

            Velocity = (position - WorldPosition).Normalized * Speed * 2;
        }

        
        public override void OnCollision(Actor other)
        {
            if(other is Player)
            {
                _isDead = true;
            }
            else if (other is Bullet)
            {
                _deadZombie = true;
                
            }
            base.OnCollision(other);
        }

        public void RespawnZombie(Enemy enemy)
        {
            if(_approveRespawn == false)
            {
                _deadZombie = true;
                _approveRespawn = true;
                
                
                
                return;
            }
            return;
        }
        public override void Update(float deltaTime)
        {
            //if(_deadZombie == true)
            //{
                 
            //    Scene scene = Game.GetScenes(Game.CurrentSceneIndex);
            //    scene.RemoveActor(enemy);
            //}

            if (GetTargetInSight(5f, 20) == true)
            {
                _rayColor = Color.RED;
                TrackTargetInSight(Target.LocalPosition);
                
            }
            else
            {
                int x = 1;
                int y = 0;
                Velocity = new Vector2(x, y);
                Velocity = Velocity.Normalized * Speed;
                _rayColor = Color.GREEN;
                
            }
            base.Update(deltaTime);
        }

        public override void Draw()
        {
            _sprite.Draw(_globalTransform);
            base.Draw();
        }
    }
}