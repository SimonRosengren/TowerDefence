using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    class actionBar
    {
        Rectangle lvlUpButton;
        Rectangle deleteButton;

        Texture2D barBackgroundTex;
        Texture2D buttonTex;

        public actionBar(Texture2D bg, Texture2D b)
        {
            this.barBackgroundTex = bg;
            this.buttonTex = b;
            this.lvlUpButton = new Rectangle(100, 720, 100, 50);
            this.deleteButton = new Rectangle(300, 720, 100, 50);
        }
        public int getButtonPressed(Vector2 mousePos)
        {
            if (lvlUpButton.Contains(mousePos))
            {
                return 1;
            }
            if (deleteButton.Contains(mousePos))
            {
                return 2;
            }
            else return 0;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(barBackgroundTex, new Vector2(0, 700), Color.White);
            sb.Draw(barBackgroundTex, lvlUpButton, Color.Black);
            sb.Draw(barBackgroundTex, deleteButton, Color.Red);
        }
    }
}
