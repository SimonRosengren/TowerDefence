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
        public float originalSpeed;
        public float velocity;
        public float health;
        public float speed;
        public bool slowEffect;
        public int value;
        public Monster(Texture2D tex, Vector2 startPos) : base(startPos, tex)
        {
            this.health = 1000;
            this.speed = 100;
            this.originalSpeed = speed;
            this.pos = startPos;
            this.slowEffect = false;
            this.tex = tex;
            this.value = 10;
            this.velocity = 0;
            this.hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }
        public void update(Vector2 dest, float t)            //Skicka med coordinates från splineklassen
        {
     
            this.pos = dest;

            this.hitBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, tex.Width, tex.Height);
            velocity += t * speed;
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, Color.White);
        }
    }
}
