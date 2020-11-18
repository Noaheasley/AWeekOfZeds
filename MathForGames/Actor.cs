using MathLibrary;
using System;
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
        protected Actor[] _children = new Actor[0];
        //protected float _rotationAngle;
        private float _collisionRadius;

        public bool Started { get; private set; }

        public Vector2 Forward
        {
            get { return new Vector2(_localTransform.m11, _localTransform.m21); }
            //set
            //{
            //    _transform.m11 = value.X;
            //    _transform.m21 = value.Y;
            //}
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


        public Actor(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _rayColor = Color.WHITE;
            _icon = icon;
            _localTransform = new Matrix3();
            LocalPosition = new Vector2(x, y);
            _velocity = new Vector2();
            _color = color;
            _sprite = new Sprite("AWZ_Sprites");
        }
        public Actor(float x, float y, Color raycolor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
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
            if(other.LocalPosition == other.LocalPosition)
            {
                return true;
            }
            return false;
        }
        public virtual void OnCollision(Actor other)
        {
            if(CheckCollision(other) == true)
            {
                
            }
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
