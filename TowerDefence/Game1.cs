using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spline;

namespace TowerDefence
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;


        SpriteBatch spriteBatch;  

        Texture2D monsterTex;
        Texture2D bulletTex;
        Texture2D towerTex;
        Texture2D bottomBarBG;
        SpriteFont HUDfont;



        LevelManager levelManager;

        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
     
            
        }
        protected override void Initialize()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);


            monsterTex = Content.Load<Texture2D>(@"Jump_Monster_Sprite");
            bulletTex = Content.Load<Texture2D>(@"bullet");
            towerTex = Content.Load<Texture2D>(@"Finishflag_sprite");
            bottomBarBG = Content.Load<Texture2D>(@"barBG");
            HUDfont = Content.Load<SpriteFont>(@"HUDfont");


            levelManager = new LevelManager(GraphicsDevice, monsterTex, towerTex, bulletTex, bottomBarBG, Window.ClientBounds.Width, Window.ClientBounds.Height, spriteBatch, HUDfont);
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            levelManager.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            levelManager.Draw(spriteBatch);
            spriteBatch.End();

            
            base.Draw(gameTime);
        }
    }
}
