using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Interactable : Actor
    {
        

        public Interactable(Vector2 position, Vector2 direction, Sprite sprite, float speed = 10) 
            : base()
        {

        }
        public override void OnCollision(Actor other)
        {
            if(other is Player)
            {
                _interacted = true;
            }
            else if(other is Enemy)
            {
                _interacted = true;
            }
            base.OnCollision(other);
        }
    }
}
