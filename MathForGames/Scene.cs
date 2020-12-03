using MathLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Scene
    {
        private Actor[] _actors;
        private Matrix3 _transform = new Matrix3();
        public bool Started { get; private set; }

        public Matrix3 World
        {
            get { return _transform; }
        }
        public Scene()
        {
            _actors = new Actor[0];
        }

        private void CheckCollision()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                for (int j = 0; j < _actors.Length; j++)
                {
                    if (i >= _actors.Length)
                        break;

                    if (_actors[i].CheckCollision(_actors[j]) && i != j)
                        _actors[i].OnCollision(_actors[j]);
                }
            }
        }
        public void AddActor(Actor actor)
        {
            //creating a new array with a size one greater than our old array
            Actor[] appendedArray = new Actor[_actors.Length + 1];
            //copy values from the old array to the new array
            for (int i = 0; i < _actors.Length; i++)
            {
                appendedArray[i] = _actors[i];
            }
            //set the last value in the new array to be the actor we want to add
            appendedArray[_actors.Length] = actor;
            //Set old array to hold values of the new arrat
            _actors = appendedArray;
        }

        public bool RemoveActor(int index)
        {
            //checks if the index is outside the range of the array
            if (index >= 0 || index >= _actors.Length)
            {
                return false;
            }
            bool actorRemoved = false;
            //creates a new array with a size one less than the old array
            Actor[] tempArray = new Actor[_actors.Length - 1];
            //creates variable to access tempArray index
            int j = 0;
            //copy values from tthe old array to the new one
            for (int i = 0; i < _actors.Length; i++)
            {
                //if the current index is not the index that needs to be removed
                //add the value into the old array and increment j
                if (i != index)
                {
                    tempArray[j] = _actors[i];
                    j++;
                }
                else
                {
                    actorRemoved = true;
                    if (_actors[i].Started)
                        _actors[i].End();
                }
            }
            //set the old array to be the tempArray
            _actors = tempArray;
            return false;
        }

        public bool RemoveActor(Actor actor)
        {
            //checks to see if the actor was null
            if (actor == null)
            {
                return false;
            }
            bool actorRemoved = false;

            Actor[] newArray = new Actor[_actors.Length - 1];

            int j = 0;
            for (int i = 0; i < _actors.Length; i++)
            {
                if (actor != _actors[i])
                {

                    if (j < newArray.Length)
                    {

                        newArray[j] = _actors[i];
                        j++;
                    }
                    else
                    {
                        actorRemoved = true;
                        if (actor.Started)
                            actor.End();

                    }
                }
            }
            _actors = newArray;
            return actorRemoved;
        }
        public virtual void Start()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Start();
            }

            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                if (!_actors[i].Started)
                {
                    _actors[i].Start();
                }
                

                    

                _actors[i].Update(deltaTime);
            }
        }

        public virtual void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            { 
                _actors[i].Draw();
            }
            CheckCollision();
        }

        public virtual void End()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                if (_actors[i].Started)
                    _actors[i].End();
                _actors[i].Draw();
            }

            Started = false;
        }
    }
}