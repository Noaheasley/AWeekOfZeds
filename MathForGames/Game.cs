using System;
using System.Timers;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MathLibrary;
using System.Threading;
using Raylib_cs;
namespace MathForGames
{
   
    class Game
    {
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;

        private Enemy _enemy1 = new Enemy(1, 5, "ZED", 1, 1, 5,5, Color.GREEN, 'Z', ConsoleColor.Green);
        private Enemy _enemy2 = new Enemy(1, 1, "ZED", 1, 1, 5,5, Color.GREEN, 'Z', ConsoleColor.Green);
        private Enemy _enemy3 = new Enemy(1, 5, "ZED", 1, 1, 5, 5, Color.GREEN, 'Z', ConsoleColor.Green);
        private Enemy _enemy4 = new Enemy(1, 7, "ZED", 1, 1, 5, 5, Color.GREEN, 'Z', ConsoleColor.Green);
        private Enemy _enemy5 = new Enemy(1, 11, "ZED", 1, 1, 5, 5, Color.GREEN, 'Z', ConsoleColor.Green);
        private Enemy _enemy6 = new Enemy(1, 14, "ZED", 1, 1, 5, 5, Color.GREEN, 'Z', ConsoleColor.Green);
        private Player _player = new Player(1, 1,"Player",1,1,10, 5, Color.PURPLE, 'P', ConsoleColor.Red);
        private Item _gun = new Item(5, 5, "Gun", 7, 1, 1, 1, Color.WHITE, 'G', ConsoleColor.White);
        private Scene _scene;
        private int _score = 0;


        public static int CurrentSceneIndex
        {
            get
            {
                return _currentSceneIndex;
            }
        }
        

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        public static Scene GetScenes(int index)
        {
            return _scenes[index];
        }

        public static Scene GetCurrentScene()
        {
            return _scenes[_currentSceneIndex];
        }
        //reads if any keys are pressed
        public static bool GetKeyDown(int key)
        {
            bool testbool = true;
            int test = Convert.ToInt32(testbool);
            return Raylib.IsKeyDown((KeyboardKey)key);
        }
        
        //adds a scene into the scene index
        public static int AddScene(Scene scene)
        {
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            for (int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            int index = _scenes.Length;

            tempArray[index] = scene;
            _scenes = tempArray;

            return index;
        }
        //removes any scene from the index
        public static bool RemoveScene(Scene scene)
        {
            if (scene == null)
            {
                return false;
            }

            bool removed = false;

            Scene[] tempArry = new Scene[_scenes.Length - 1];
            int j = 0;
            for (int i = 0; i < _scenes.Length; i++)
            {
                if (tempArry[i] != scene)
                {
                    tempArry[j] = _scenes[i];
                    j++;
                }
                else
                {
                    removed = true;
                }
            }
            if (removed)
                _scenes = tempArry;

            return removed;
        }
        //sets gameover to a value
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public Game()
        {
            _scenes = new Scene[0];
        }
        //sets a new scene to be the current scene displayed
        public static void SetCurrentScene(int index)
        {
            if (index < 0 || index > _scenes.Length)
                return;
            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();
            _currentSceneIndex = index;
        }

        

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            Raylib.InitWindow(1024, 760, "Math for games");
            Raylib.SetTargetFPS(60);

            _scene = new Scene();
            _scene.AddActor(_gun);
            _player.AddChild(_gun);
            _player.SetTranslate(new Vector2(20, 10));
            _gun.SetTranslate(new Vector2(1, 0));

            _enemy1.Target = _player;
            _enemy2.Target = _player;
            _enemy3.Target = _player;
            _enemy4.Target = _player;
            _enemy5.Target = _player;
            _enemy6.Target = _player;


            _scene.AddActor(_enemy1);
            _scene.AddActor(_enemy2);
            _scene.AddActor(_enemy3);
            _scene.AddActor(_enemy4);
            _scene.AddActor(_enemy5);
            _scene.AddActor(_enemy6);
            _scene.AddActor(_player);

            
            int startingSceneIndex = 0;

            startingSceneIndex = AddScene(_scene);
            _player.Speed = 5;
            
            //SetCurrentScene(startingSceneIndex);
        }

        //Called every frame.
        public void Update(float deltaTime)
        {
            
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();
            _scenes[_currentSceneIndex].Update(deltaTime);
        }

        //Used to display objects.
        public void Draw()
        {
            //if a Zombie dies it will increase the score and allow the zombie to respawn
            if (_enemy1._deadZombie == true)
            {
                _score += 1;
                //removes the enemy from the scene
                _scene.RemoveActor(_enemy1);
                //takes away  the dead tag
                _enemy1._deadZombie = false;
                //gives the zombie their respawn tag
                _enemy1.RespawnZombie(_enemy1);
                if(_enemy1._approveRespawn == true)
                {
                    _scene.AddActor(_enemy1,10,1);
                    return;
                }
                return;
            }
            else if (_enemy2._deadZombie == true)
            {
                _score += 1;
                _scene.RemoveActor(_enemy2);
                _enemy2._deadZombie = false;
                _enemy2.RespawnZombie(_enemy2);
                if (_enemy2._approveRespawn == true)
                {
                    _scene.AddActor(_enemy2, 15, 3);
                    return;
                }
                return;
            }
            else if (_enemy3._deadZombie == true)
            {
                _score += 1;
                _scene.RemoveActor(_enemy3);
                _enemy3._deadZombie = false;
                _enemy3.RespawnZombie(_enemy3);
                if (_enemy3._approveRespawn == true)
                {
                    _scene.AddActor(_enemy3, 1, 5);
                    return;
                }
                return;
            }
            else if (_enemy4._deadZombie == true)
            {
                _score += 1;
                _scene.RemoveActor(_enemy4);
                _enemy4._deadZombie = false;
                _enemy4.RespawnZombie(_enemy4);
                if (_enemy4._approveRespawn == true)
                {
                    _scene.AddActor(_enemy4, 1, 7);
                    return;
                }
                return;
            }
            else if (_enemy5._deadZombie == true)
            {
                _score += 1;
                _scene.RemoveActor(_enemy5);
                _enemy5._deadZombie = false;
                _enemy5.RespawnZombie(_enemy5);
                if (_enemy5._approveRespawn == true)
                {
                    _scene.AddActor(_enemy5, 17, 10);
                    return;
                }
                return;
            }
            else if (_enemy6._deadZombie == true)
            {
                _score += 1;
                _scene.RemoveActor(_enemy6);
                _enemy6._deadZombie = false;
                _enemy6.RespawnZombie(_enemy6);
                if (_enemy6._approveRespawn == true)
                {
                    _scene.AddActor(_enemy6, 1, 13);
                    return;
                }
                return;
            }
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();
            
            Raylib.EndDrawing();
        }

        //Called when the game ends.
        public void End()
        {
            
                if (_scenes[_currentSceneIndex].Started)
                    _scenes[_currentSceneIndex].End();
            
        }

        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            
            Start();

            while (_gameOver = false || !Raylib.WindowShouldClose())
            {
                float deltaTime = Raylib.GetFrameTime();
                Update(deltaTime);
                Draw();

                if (_player._isDead == true)
                {
                    
                    Raylib.DrawText("You Died" + "\nYour score was: " + _score + "\nPress L to leave", 20, 20, 20, Color.RED);

                    if (Game.GetKeyDown((int)KeyboardKey.KEY_L))
                    {
                        SetGameOver(true);
                        break;
                    }
                }
                

                    while (Console.KeyAvailable)
                        Console.ReadKey(true);

                

                End();
            }
            
        }
    }
}