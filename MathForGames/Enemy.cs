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
        public static float FindAngle(Vector2 lhs, Vector2 rhs)
        {
            lhs = lhs.Normalized;
            rhs = rhs.Normalized;

            float dotProd = Vector2.DotProduct(lhs, rhs);

            if (Math.Abs(dotProd) > 1)
                return 0;

            float angle = (float)Math.Acos(dotProd);

            Vector2 perp = new Vector2(rhs.Y, -rhs.X);

            float perpDot = Vector2.DotProduct(perp, lhs);

            if (perpDot != 0)
                angle *= perpDot / Math.Abs(perpDot);

            return angle;
        } //Find Angle function

        public void TrackTargetInSight(Vector2 position)
        {
            Vector2 direction = (position - WorldPosition).Normalized;

            float angle = FindAngle(Forward, direction);

            Rotate(-angle);
        }

        public override void OnCollision(Actor other)
        {
            if(other is Player)
            {
                _isDead = true;
            }
            else if (other is Interactable)
            {
                _interacted = true;
                
            }
            base.OnCollision(other);
        }

        
        public override void Update(float deltaTime)
        {
            if (GetTargetInSight(1.5f, 5) == true)
            {
                _rayColor = Color.RED;
                TrackTargetInSight(Target.LocalPosition);

                int x = 1;
                int y = 1;
                Velocity = new Vector2(x, y);
                Velocity = Velocity.Normalized * Speed;
            }
            else
            {
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