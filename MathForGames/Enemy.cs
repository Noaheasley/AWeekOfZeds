using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Enemy : Actor
    {
        private Actor _target;
        private Color _alertColor;
        private Vector2 _x;
        private Vector2 _y;
        private float _money;
        private float _targetDistance;
        private float _speed = 1;
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

        public Enemy(float x, float y, string nameVal, float healthVal, float damageVal, float moneyVal, Color raycolor, char icon = 'Z', ConsoleColor color = ConsoleColor.White)
            : base(x, y, nameVal,healthVal,damageVal,moneyVal, raycolor, icon, color)
        {
            //_sprite = new Sprite("AWZ_Sprites/Zed.png");
            _alertColor = Color.RED;
            _collisionRadius = 1;
        }

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

            Velocity = position - WorldPosition;
        }

        
        public override void OnCollision(Actor other)
        {
            if(other is Player)
            {
                _isDead = true;
            }
            else if (other is Item)
            {
                _isDead = true;
                
            }
            base.OnCollision(other);
        }

        
        public override void Update(float deltaTime)
        {
            
            if (GetTargetInSight(1.5f, 5) == true)
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