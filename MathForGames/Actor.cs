using MathLibrary;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace MathForGames
{
    class Actor
    {
        protected char _icon = 'a';
        protected Vector2 _velocity;
        protected Sprite _sprite;
        protected Matrix3 _globalTransform = new Matrix3();
        protected Matrix3 _localTransform = new Matrix3();
        protected Matrix3 _translation = new Matrix3();
        protected Matrix3 _rotation = new Matrix3();
        protected Matrix3 _scale = new Matrix3();
        protected ConsoleColor _color;
        protected Color _rayColor;
        protected Actor _parent;
        public bool _isDead = false;
        protected Actor[] _children = new Actor[0];
        private float _health = 1;
        private string _name = "no_name";
        protected float _damage = 1;
        public float _money = 10;
        public float _collisionRadius;

        public bool Started { get; private set; }

        public Vector2 Forward
        {
            get { return new Vector2(_localTransform.m11, _localTransform.m21); }
        }

        public Vector2 WorldPosition
        {
            get
            {
                return new Vector2(_globalTransform.m13, _globalTransform.m23);
            }
            set
            {
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
            }
        }
        public Vector2 LocalPosition
        {
            get
            {
                return new Vector2(_localTransform.m13, _localTransform.m23);
            }
            set
            {
                _translation.m13 = value.X;
                _translation.m23 = value.Y;
            }
        }
        public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }


        public Actor(float x, float y, string nameVal, float healthVal, float damageVal, float moneyVal, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _name = nameVal;
            _health = healthVal;
            _damage = damageVal;
            _money = moneyVal;
            _rayColor = Color.WHITE;
            _icon = icon;
            _localTransform = new Matrix3();
            LocalPosition = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
            _sprite = new Sprite("AWZ_Sprites");
        }
        public Actor(float x, float y, string nameVal, float healthVal, float damageVal, float moneyVal, Color raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _name = nameVal;
            _health = healthVal;
            _damage = damageVal;
            _money = moneyVal;
            _rayColor = raycolor;
            _icon = icon;
            _localTransform = new Matrix3();
            LocalPosition = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
            _sprite = new Sprite("AWZ_Sprites");
        }

        public void AddChild(Actor child, Actor parent)
        {
            Actor[] tempArray = new Actor[_children.Length + 1];

            for (int i = 0; i < _children.Length; i++)
            {
                tempArray[i] = _children[i];
            }

            tempArray[_children.Length] = child;

            _children = tempArray;

            child._parent = parent;

            child.Velocity = parent.Velocity;
        }

        public bool RemoveChild(Actor child)
        {
            bool childRemoved = false;
            if (child == null)
                return false;

            Actor[] tempArry = new Actor[_children.Length - 1];

            int j = 0;
            for (int i = 0; i < _children.Length; i++)
            {
                if (child != _children[i])
                {
                    tempArry[j] = _children[i];
                    j++;
                }
                else
                {
                    childRemoved = true;
                }
            }

            _children = tempArry;
            child._parent = null;
            return childRemoved;
        }

        public string GetName()
        {
            return _name;
        }
        public float GetDamage()
        {
            return _damage;
        }

        public virtual float TakeDamage(float damageVal)
        {
            _health -= damageVal;
            if(_health < 0)
            {
                _health = 0;
            }
            return damageVal;
        }

        public virtual float Attack(Actor actor)
        {
            return actor.TakeDamage(_damage);
        }
        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine(_name);
            writer.WriteLine(_health);
            writer.WriteLine(_damage);
            writer.WriteLine(_money);
        }

        public virtual bool Load(StreamReader reader)
        {
            if(File.Exists("SavedData.txt") == false)
            {
                return false;
            }
            string name = reader.ReadLine();
            float health = 0;
            float damage = 0;

            if(float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            if(float.TryParse(reader.ReadLine(), out damage) == false)
            {
                return false;
            }

            _name = name;
            _damage = damage;
            _health = health;
            return true;
        }

        public bool GetIsAlive()
        {
            return _health > 0;
        }

        public bool GetIsAlive(bool Alive = false)
        {
            return _health <= 0;
        }


        public void SetTranslate(Vector2 position)
        {
            _translation = Matrix3.CreateTranslation(position);
        }

        public void SetRotation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        
        public void Rotate(float radians)
        {
            _rotation *= Matrix3.CreateRotation(radians);
        }


        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(new Vector2(x, y));
        }

        public void UpdateTransform()
        {
            _localTransform = _translation * _rotation * _scale;
        }


        private void UpdateTransforms()
        {
            _localTransform = _translation * _rotation * _scale;

            if (_parent != null)
                _globalTransform = _parent._globalTransform * _localTransform;
            else
                _globalTransform = Game.GetCurrentScene().World * _localTransform;
        }

        public virtual void Start()
        {
            Started = true;
        }

        public bool CheckCollision(Actor other)
        {
            float distance = (other.WorldPosition - WorldPosition).Magnitude;
            return distance <= other._collisionRadius + _collisionRadius;
        }
        public virtual void OnCollision(Actor other)
        {
           
        }
        public virtual void Update(float deltaTime)
        {
            UpdateTransforms();
            WorldPosition += _velocity * deltaTime;
            WorldPosition.X = Math.Clamp(WorldPosition.X, 0, Console.WindowWidth - 1);
            WorldPosition.Y = Math.Clamp(WorldPosition.Y, 0, Console.WindowHeight - 1);
        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.ToString(), (int)(WorldPosition.X * 32), (int)(WorldPosition.Y * 32), 20, _rayColor);
            Raylib.DrawLine(
                (int)(WorldPosition.X * 32),
                (int)(WorldPosition.Y * 32),
                (int)((WorldPosition.X + Forward.X) * 32),
                (int)((WorldPosition.Y + Forward.Y) * 32),
                _rayColor);


            Console.ForegroundColor = _color;

            if (WorldPosition.X >= 0 && WorldPosition.X < Console.WindowWidth
                && WorldPosition.Y >= 0 && WorldPosition.Y < Console.WindowHeight)
            {
                Console.SetCursorPosition((int)WorldPosition.X, (int)WorldPosition.Y);
                Console.Write(_icon);
            }
            Console.ForegroundColor = Game.DefaultColor;

        }

        public virtual void End()
        {
            Started = false;
        }
    }
}
