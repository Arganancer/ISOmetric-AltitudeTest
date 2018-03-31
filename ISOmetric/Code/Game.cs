using System;
using System.Collections.Generic;
using ISOmetric.Code;
using ISOmetric.Code.Drawables;
using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace ISOmetric
{
    class Game
    {
        #region Game Variables
        public const int GAME_WIDTH = 1920;
        public const int GAME_HEIGHT = 1080;
        public const int VIEW_WIDTH = 1920;
        public const int VIEW_HEIGHT = 1080;
        public const uint FRAME_LIMIT = 60;

        private View view;
        private float viewPosX = 0;
        private float viewPosY = 0;

        public Cube[,,] cubes;
        #endregion

        #region Window events
        private RenderWindow window = null;
        private Color backgroundColor = Color.Black;

        /// <summary>
        /// Events when the window is closed (ends the execution of the program).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        /// <summary>
        /// Events when a key is a pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnKeyPressed(object sender, KeyEventArgs e)
        {
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="windowTitle"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Game(string windowTitle)
        {
            window = new RenderWindow(new SFML.Window.VideoMode(GAME_WIDTH, GAME_HEIGHT), windowTitle);
            window.Closed += new EventHandler(OnClose);
            window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            window.SetKeyRepeatEnabled(false);
            window.SetFramerateLimit(FRAME_LIMIT);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            InitGame();
            window.SetActive();
            while (window.IsOpen)
            {
                window.Clear(backgroundColor);
                window.DispatchEvents();
                Update();
                Draw();
                window.Display();
            }
        }

        /// <summary>
        /// Initialize game (called once when program is first launched).
        /// </summary>
        public void InitGame()
        {
            viewPosX = 0;
            viewPosY = 0;
            view = new View(new Vector2f(viewPosX, viewPosY), new Vector2f(VIEW_WIDTH, VIEW_HEIGHT));
            window.SetView(view);
            Level.CreateLevel(gameWidth, gameHeight, gameLength);
            cubes = new Cube[gameWidth, gameHeight, gameLength];
            for (int i = 0; i < gameWidth; i++)
            {
                for (int j = 0; j < gameHeight; j++)
                {
                    for (int k = 0; k < gameLength; k++)
                    {
                        if (Level.level[i, j, k] == 1)
                        {
                            cubes[i, j, k] = new Cube(i, j, k);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Update()
        {
            // Camera Update
            int cameraIncrementalValue = 3;
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                viewPosY -= cameraIncrementalValue;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                viewPosY += cameraIncrementalValue;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                viewPosX -= cameraIncrementalValue;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                viewPosX += cameraIncrementalValue;
            }
            view.Center = new Vector2f(viewPosX, viewPosY);
            window.SetView(view);
        }

        private int framesBeforeAdd = 120;
        private int framesSinceLastAdd = 0;
        int gameWidth = 5;
        int gameHeight = 5;
        int gameLength = 1;

        /// <summary>
        /// 
        /// </summary>
        public void Draw()
        {
            for (int i = 0; i < cubes.GetLength(0); i++)
            {
                for (int j = 0; j < cubes.GetLength(1); j++)
                {
                    for (int k = 0; k < cubes.GetLength(2); k++)
                    {
                        if (cubes[i, j, k] != null)
                        {
                            cubes[i, j, k].Draw(window);
                        }
                    }
                }
            }
            // Code to generate random new cubes.
            framesSinceLastAdd++;
            if (framesSinceLastAdd >= framesBeforeAdd)
            {
                framesSinceLastAdd = 0;
                gameLength++;
                Level.CreateLevel(5, 5, gameLength);
                cubes = new Cube[gameWidth, gameHeight, gameLength];
                for (int i = 0; i < gameWidth; i++)
                {
                    for (int j = 0; j < gameHeight; j++)
                    {
                        for (int k = 0; k < gameLength; k++)
                        {
                            if (Level.level[i, j, k] == 1)
                            {
                                cubes[i, j, k] = new Cube(i, j, k);
                            }
                        }
                    }
                }
            }
        }
    }
}
