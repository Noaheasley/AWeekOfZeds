using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Player : Actor
    {
        private float _money;
        private Item[] _inv;
        private Item _currentWeapon;
        private Item _hands;

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
        public Player(float x, float y, string nameVal, float healthVal, float damageVal, float moneyVal, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, nameVal, healthVal, damageVal, moneyVal, icon, color)
        {
            _sprite = new Sprite("AWZ_Sprites/PlayerPlaceHolder.png");
            _inv = new Item[3];
            _money = moneyVal;
            _hands._name = "Fist";
            _hands._statBoost = 0;
            
        }

        public Player(float x, float y, string nameVal, float healthVal, float damageVal, float moneyVal, Color raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : base(x, y, nameVal, healthVal, damageVal, moneyVal, raycolor, icon, color)
        {
            
            _sprite = new Sprite("AWZ_Sprites/PlayerPlaceHolder.png");
            _inv = new Item[3];
            _money = moneyVal;
            _hands._name = "Fist";
            _hands._statBoost = 0;
        }
        public override void Update(float deltaTime)
        {
            int xVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_A))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_D));
            int yVelocity = -Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_W))
                + Convert.ToInt32(Game.GetKeyDown((int)KeyboardKey.KEY_S));



            Velocity = new Vector2(xVelocity, yVelocity);
            Velocity = Velocity.Normalized * Speed;


            base.Update(deltaTime);
        }

        public bool Buy(Item item, int inventoryIndex)
        {
            if(_money >= item._cost)
            {
                _money -= item._cost;
                _inv[inventoryIndex] = item;
                return true;
            }
            return false;
        }

        public void MoneyGain(Player player, Enemy enemy)
        {
            player._money += enemy._money;
        }

        public bool Contains(int itemIndex)
        {
            if(itemIndex > 0 && itemIndex < _inv.Length)
            {
                return true;
            }
            return false;
        }

        public void AddItemToInv(Item item, int index)
        {
            _inv[index] = item;
        }
        public void EquipItem(int itemIndex)
        {
            if(Contains(itemIndex))
            {
                _currentWeapon = _inv[itemIndex];
            }
        }
        public void UnequipItem()
        {
            _currentWeapon = _hands;
        }
        public Item[] GetInv()
        {
            return _inv;
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
            base.OnCollision(other);
        }
    }
}
