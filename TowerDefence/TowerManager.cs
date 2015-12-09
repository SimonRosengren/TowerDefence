using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    class TowerManager
    {
        Texture2D tex;
        Texture2D bulletTex;
        public List<Tower> towers;
        public BulletManager bulletManager;
        public TowerManager(Texture2D tex, Texture2D bulletTex)
        {
            this.tex = tex;
            this.bulletTex = bulletTex;
            towers = new List<Tower>();
            this.bulletManager = new BulletManager(bulletTex);
        }
        public void Update(float time)
        {
            bulletManager.Update(time);
            foreach (Tower tower in towers)
            {
                tower.reload(time);
            }
        }
        public void Draw(SpriteBatch sb)
        {
            foreach (Tower t in towers)
            {
                t.Draw(sb);
            }
            bulletManager.Draw(sb);
        }
        public void addNormalTower(Vector2 pos)
        {
            towers.Add(new TowerNormal(pos, this.tex, this.bulletTex));
        }
        public void addSlowTower(Vector2 pos)
        {
            towers.Add(new TowerSlow(pos, this.tex, this.bulletTex));
        }
        public void checkForTarget(Rectangle monsterHitBox, int monsterIndex, float time) //gör det här för varje monster 
        {
            foreach (Tower t in towers)
            {
                
                if (monsterHitBox.Intersects(t.rangeBox) && !t.hasTarget)
                {
                    //Locking target

                    t.target = monsterIndex;
                    t.hasTarget = true;
                }
                if (t.hasTarget && t.target == monsterIndex && monsterHitBox.Intersects(t.rangeBox) && t.target != null && !t.isReloading)
                {
                    //shooting
                    t.isReloading = true;
                    Bullet b = new Bullet(t.getPos(), new Vector2(monsterHitBox.X, monsterHitBox.Y), bulletTex, monsterIndex, t.dmg);
                    b.slowEffect = t.slowEffect;
                    bulletManager.addBullet(b);
                }
                else if (t.target != null && t.target == monsterIndex && !monsterHitBox.Intersects(t.rangeBox))
                {
                    //loosing target
                    t.hasTarget = false;
                    t.target = null;
                }
  

            }
        }
        public void updateBulletTargets()
        {

        }


    }
}
