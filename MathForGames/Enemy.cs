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

        public Actor Target
        {
            get { return _target; }
            set { _target = value; }
        }
        public Enemy(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, icon, color)
        {
            _sprite = new Sprite("AWZ_Sprites/Zed.png");
        }

        public Enemy(float x, float y, Color raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, raycolor, icon, color)
        {
            _sprite = new Sprite("AWZ_Sprites/Zed.png");
            _alertColor = Color.RED;
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

        public override void Update(float deltaTime)
        {
            if (GetTargetInSight(1.5f, 5) == true)
            {
                _rayColor = Color.RED;
            }
            else
            {
                _rayColor = Color.BLUE;
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