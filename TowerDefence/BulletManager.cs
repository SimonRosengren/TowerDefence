using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    class BulletManager
    {
        Texture2D tex;
        public List<Bullet> bullets;
        public BulletManager(Texture2D tex)
        {
            this.tex = tex;
            this.bullets = new List<Bullet>();
        }
        public void Update(float t)
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.update();
            }
        }
        public void addBullet(Vector2 towerPos, Vector2 monsterPos, Texture2D tex, int targetIndex)
        {
            bullets.Add(new Bullet(towerPos, monsterPos, tex, targetIndex));
        }
        public void Draw(SpriteBatch sb)
        {
            foreach (Bullet b in bullets)
            {
                b.Draw(sb);
            }
        }
    }
}
