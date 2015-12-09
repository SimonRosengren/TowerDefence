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
        public float slowEffect;
        //public bool reloading;
        protected float timeToReload;
        public float reloadTimer;
        public bool isReloading;
        public float dmg;

        public Tower(Vector2 pos, Texture2D tex, Texture2D bulletTex) : base(pos, tex)
        {
            reloadTimer = 10;
            this.bulletTex = bulletTex;
            this.hasTarget = false;
            target = null;
            this.isReloading = false;
            this.slowEffect = 1.0f;
            //this.reloading = false;
            this.timeToReload = 0.7f;
            this.dmg = 100;//determines how fast the tower shoots
        }
        public abstract void Update(Vector2 target, float t);
        public abstract void shoot(Vector2 target, float t);
        public void reload(float t)
        {
            
            if (isReloading)
            {
                reloadTimer += t;
            }
            if (reloadTimer > timeToReload)
            {
                reloadTimer = 0;
                isReloading = false;
            }
            

           
        }
        public override void Draw(SpriteBatch sb) { }

    }
}
