using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Tesis_02.Core;
using System.Diagnostics;
using Game1;

namespace Tesis_02
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Song musica1;
        //TileMap escenario;
        public PersonajePrincipal personaje { get; set; }
        //public Texture2D fondo { get; set; }

        Pregunta pregunta = new Pregunta();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //Components.Add(new GamerServicesComponent(this));
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.Window.AllowUserResizing = true;
            //this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            this.IsMouseVisible = true;
            personaje = new PersonajePrincipal(this);
            Texture2D fondo = Content.Load<Texture2D>("Backgrounds/fondoisometrico");
            TileMap.Instance(this, "Content/Mapas/mapa_menu-elegir01.csv", personaje, 3, 5);
            TileMap.GetInstance.spriteFactory = new Menu_elegir01_SpriteFatory(this);
            //.spriteFactory = new RazonamientoSpriteFactory(this);
            //escenario.regenerarMapa();

            TileMap.GetInstance.HorizontalScrolling = TileMap.Scrolling.Sprite;
            TileMap.GetInstance.VerticalScrolling = TileMap.Scrolling.Sprite;
            TileMap.GetInstance.ParallaxBackground = fondo;

            TileMap.GetInstance.regenerarMapa();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pregunta.Cargar(Content);
            musica1 = Content.Load<Song>("Musica/musica01");
            MediaPlayer.Play(musica1);
            MediaPlayer.IsRepeating = true;
            Global_Resolviendo.Instance.setEstado(0);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        //KeyboardState prevKeyState; 
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard1.Instance.getkeyboardStateActual.IsKeyDown(Keys.Escape))
             this.Exit();

            //pregunta.Update();

            Keyboard1.Instance.setkeyboardStatePrevio(Keyboard1.Instance.getkeyboardStateActual);
            // Almacena el estado previo en variables distintas
            Keyboard1.Instance.setkeyboardStateActual(Keyboard.GetState());
            // Leer el estado actual del teclado y almacenarlo

            if (Global_Resolviendo.Instance.getestado()==1)
            {
               
            }
            else
            {
                personaje.parar_personaje();
                personaje.actualizar_teclas();
                TileMap.GetInstance.actualizar((long)gameTime.ElapsedGameTime.TotalMilliseconds);
            }

            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            TileMap.GetInstance.dibujar(spriteBatch, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
