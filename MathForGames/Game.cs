﻿using System;
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
        private static System.Timers.Timer aTimer;

        private Enemy _enemy1 = new Enemy(1, 1, "ZED", 1, 1, 5, Color.GREEN, 'Z', ConsoleColor.Green);
        private Enemy _enemy2 = new Enemy(1, 1, "ZED", 1, 1, 5, Color.GREEN, 'Z', ConsoleColor.Green);
        private Player _player = new Player(5, 5,"Player",1,1,10, Color.PURPLE, 'P', ConsoleColor.Red);
        private Scene _scene;
        private Item KillZed = new Item(10, 10, "kill", 1, 1, 1, Color.YELLOW, 'K', ConsoleColor.Yellow);

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

        public static bool GetKeyDown(int key)
        {
            bool testbool = true;
            int test = Convert.ToInt32(testbool);
            return Raylib.IsKeyDown((KeyboardKey)key);
        }

        public static bool GetKeyPressed(int key)
        {

            return Raylib.IsKeyPressed((KeyboardKey)key);
        }

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

        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public Game()
        {
            _scenes = new Scene[0];
        }
        
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

            _player.SetTranslate(new Vector2(10, 10));

            _enemy1.Target = _player;
            _enemy2.Target = _player;

            
            _scene.AddActor(_enemy1,1,5);
            _scene.AddActor(_enemy2,5,1);
            _scene.AddActor(_player,10,15);

            
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

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            if (Game.GetKeyDown((int)KeyboardKey.KEY_UP))
            {
                _scene.AddActor(KillZed, _player.LocalPosition.X, _player.LocalPosition.Y);

                KillZed.SetRotation(_player.GetAngle());

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
                    SetGameOver(true);
                    break;
                }
                
                while (Console.KeyAvailable)
                    Console.ReadKey(true);

            }

            End();
        }
    }
}