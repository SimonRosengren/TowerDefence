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
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;  
        SimplePath path;
        Texture2D tex;
        Texture2D bulletTex;
        Texture2D towerTex;
        Tower tower;
        Monster monster;
        List<Monster> monsters = new List<Monster>();
        float x;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
     
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();
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
            path = new SimplePath(GraphicsDevice);
            path.SetPos(5, new Vector2(10, 100));

            tex = Content.Load<Texture2D>(@"Jump_Monster_Sprite");
            bulletTex = Content.Load<Texture2D>(@"bullet");
            towerTex = Content.Load<Texture2D>(@"Finishflag_sprite");
            monster = new Monster(tex, new Vector2(0, 0));
            tower = new Tower(new Vector2(100, 100), towerTex, bulletTex);
            


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            x += 1.5f;
            monster.update(path.GetPos(path.beginT + x));
            if (tower.hitBox.Intersects(monster.hitBox))
            {
                tower.shoot(monster.pos, (float)gameTime.ElapsedGameTime.TotalSeconds);
                
            }
            tower.Update(monster.pos, (float)gameTime.ElapsedGameTime.TotalSeconds);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            path.Draw(spriteBatch);
            monster.Draw(spriteBatch);
            tower.Draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here
            
            base.Draw(gameTime);
        }
    }
}
