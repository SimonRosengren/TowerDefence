using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    class Tower
    {
        Vector2 pos;
        Texture2D tex;
        Texture2D bulletTex;
        bool reloading;
        float reloadTimer;
        List<Bullet> bullets = new List<Bullet>();
        public Rectangle hitBox;
        public Tower(Vector2 pos, Texture2D tex, Texture2D bulletTex)
        {
            this.tex = tex;
            this.pos = pos;
            this.bulletTex = bulletTex;
            hitBox = new Rectangle((int)pos.X - 200, (int)pos.Y - 200, tex.Width + 400, tex.Height + 400);
        }
        public void Update(Vector2 target, float t)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].update(target);


            }
          
        }
        public void shoot(Vector2 target, float t)
        {
            Bullet bullet = new Bullet(pos, target, bulletTex);
            if (reloadTimer < 0.1f && !reloading)
            {
                reloading = true;
                bullets.Add(new Bullet(this.pos, target, bulletTex));
            }
            updateTimer(t);
        }
        public void updateTimer(float t)
        {

            reloadTimer += t;
            if (reloadTimer > 0.5f)                                         // minska för att öka speed på reloaden
            {
                reloading = false; 
                reloadTimer = 0;
            }
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, Color.White);
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw(sb);
            }
        }
    }
}
