using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    abstract class Tower : GameObject
    {
        public Rectangle rangeBox;
        protected Rectangle hitBox;
        protected Texture2D bulletTex;
        public int ? target;
        public bool hasTarget;

        public Tower(Vector2 pos, Texture2D tex, Texture2D bulletTex) : base(pos, tex)
        {
            this.bulletTex = bulletTex;
            this.hasTarget = false;
            target = null;
        }
        public abstract void Update(Vector2 target, float t);
        public abstract void shoot(Vector2 target, float t);
        public abstract void reload(float t);
        public override void Draw(SpriteBatch sb) { }

    }
}
