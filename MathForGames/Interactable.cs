using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGames
{
    class Interactable : Actor
    {
        

        public Interactable(float x, float y, string nameVal, float healthVal, float damageVal, float moneyVal, Color raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.White) 
            : base(x, y, nameVal, healthVal, damageVal, moneyVal, Color.GOLD, 'S', ConsoleColor.White)
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
