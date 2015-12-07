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
    class Monster : GameObject
    {
        public Rectangle hitBox;
        public float velocity;
        public Monster(Texture2D tex, Vector2 startPos) : base(startPos, tex)
        {
            this.pos = startPos;
            this.tex = tex;
            this.velocity = 0;
            this.hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }
        public void update(Vector2 dest, float t)            //Skicka med coordinates från splineklassen
        {
            this.pos = dest;
            this.hitBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, tex.Width, tex.Height);
            velocity += t * 100;
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, Color.White);
        }
    }
}
