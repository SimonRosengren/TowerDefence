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
    class LevelManager
    {
        SimplePath path;
        TowerManager towerManager;
        MonsterManager monsterManager;

        float testTimer = 0;



        public LevelManager(GraphicsDevice graphicDevice, Texture2D monsterTex, Texture2D towerTex, Texture2D bulletTex)
        {
            path = new SimplePath(graphicDevice);
            path.generateDefaultPath();
            this.monsterManager = new MonsterManager(monsterTex);
            this.towerManager = new TowerManager(towerTex, bulletTex);


            //För test
            monsterManager.addMonster(path.GetPos(path.beginT + 300));
            towerManager.addTower(new Vector2(120, 120));




        }
        public void Update(float t)
        {
            this.monsterManager.Update(path.GetPos(path.beginT), t, path);
            this.towerManager.Update(t);
            for (int i = 0; i < monsterManager.monsters.Count; i++)
            {
                towerManager.checkForTarget(monsterManager.monsters[i].hitBox, i, t);
            }
            updateBullets();

            //för test
            testTimer += t;
            if (testTimer > 1)
            {
                monsterManager.addMonster(path.GetPos(path.beginT + 300));
                testTimer = 0;
            }
        }
        public void Draw(SpriteBatch sb)
        {
            path.Draw(sb);
            towerManager.Draw(sb);
            monsterManager.Draw(sb);         
        }
        public void updateBullets()
        {
            for (int i = 0; i < towerManager.bulletManager.bullets.Count; i++)
            {
                for (int k = 0; k < monsterManager.monsters.Count; k++)
                {
                    if ( k == towerManager.bulletManager.bullets[i].targetIndex)
                    {
                        towerManager.bulletManager.bullets[i].updateTargetPos(monsterManager.monsters[k].getPos());
                    }
                }
            }
        }
    }
}
