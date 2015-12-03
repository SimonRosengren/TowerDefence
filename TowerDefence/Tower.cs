using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    abstract class Tower
    {
        Rectangle rangeBox;
        Rectangle hitBox;
        Vector2 pos;
        protected List<Bullet> bullets;
        Texture2D tex;

        public Tower(Vector2 pos, Texture2D tex)
        {
            this.pos = pos;
            bullets = new List<Bullet>();
        }
        public abstract void Update(Vector2 target, float t) { }
        public abstract void shoot(Vector2 target, float t) { }
        public abstract void reload(float t) { }
        public abstract void Draw(SpriteBatch sb) { }

    }
}
