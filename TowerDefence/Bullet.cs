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
    class Bullet
    {
        public Vector2 pos;
        public Rectangle hitBox;
        Vector2 startPos;
       // Vector2 endPos;
        Texture2D tex;
        public Bullet(Vector2 startPos, Vector2 endPos, Texture2D tex)
        {
            this.startPos = startPos;
            this.pos = startPos;
            //this.endPos = endPos;
            this.tex = tex;
            this.hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }
        public void update(Vector2 target)
        {
            Vector2 dest = Vector2.Normalize(target - this.pos);        //- startpos om skottet ska fortsätta
            pos += dest * 20;
            
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, Color.White);
        }
    }
}
