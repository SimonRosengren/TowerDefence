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
        Vector2 startPos;
        Texture2D tex;
        public float speed;
        public double timeToLive;
        public bool isAlive;
        public Particle(Texture2D tex, Vector2 pos, Vector2 dir, int speed, double timeToLive)
        {
            this.tex = tex;
            this.pos = pos;
            this.dir = dir;
            this.speed = speed;
            this.timeToLive = timeToLive;
            this.isAlive = true;
            startPos = pos;
        }
        public void update(float t)
        {
            timeToLive -= t;
            if (timeToLive <= 0)
            {
                this.isAlive = false;
            }
            if (Vector2.Distance(startPos, pos) > 200)
            {
                timeToLive = 0;
            }
            pos += dir * speed;
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }
 
    }
}
