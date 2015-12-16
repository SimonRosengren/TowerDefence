using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    abstract class GameObject
    {
        public Texture2D tex;
        protected Vector2 pos;
        public GameObject(Vector2 pos, Texture2D tex)
        {
            this.pos = pos;
            this.tex = tex;
        }
        public Vector2 getPos()
        {
            return this.pos;
        }
        public abstract void Draw(SpriteBatch sb);
    }
}
