using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    class Particle
    {
        public Rectangle hitBox;
        Vector2 dir;
        Vector2 pos;
        Texture2D tex;
        int speed;
        public float timeToLive;
        public bool isAlive;
        public Particle(Texture2D tex, Vector2 pos, Vector2 dir, int speed)
        {
            this.tex = tex;
            this.pos = pos;
            this.dir = dir;
            this.speed = speed;
            this.timeToLive = 1f;
            this.isAlive = true;
        }
        public void update(float t)
        {
            timeToLive -= t;
            if (timeToLive < 0)
            {
                this.isAlive = false;
            }
            pos += dir * t * speed;
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }
 
    }
}
