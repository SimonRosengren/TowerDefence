using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spline;
using System.IO;

namespace TowerDefence
{
    class LevelManager
    {
        SimplePath path;
        TowerManager towerManager;
        MonsterManager monsterManager;
        ParticleHandler particleHandler;

        String[] blocklist = new String[100];

        int currentWaveSize;
        int nrOfMonstersSpawned;
        int currentWave;



        float waveTimer = 0;





        public LevelManager(GraphicsDevice graphicDevice, Texture2D monsterTex, Texture2D towerTex, Texture2D bulletTex)
        {
            path = new SimplePath(graphicDevice);
            path.generateDefaultPath();
            this.monsterManager = new MonsterManager(monsterTex);
            this.towerManager = new TowerManager(towerTex, bulletTex);
            particleHandler = new ParticleHandler(bulletTex);
            


            //För test
           
            towerManager.addNormalTower(new Vector2(120, 120));
            towerManager.addSlowTower(new Vector2(650, 120));
            towerManager.addSlowTower(new Vector2(650, 420));
            towerManager.addSlowTower(new Vector2(650, 620));
            loadLevel();



        }
        public void loadLevel()
        {
            
            int loopCounter;

            using (StreamReader sr = new StreamReader("Level.txt"))
            {
              

       
                
                   
                
                loopCounter = int.Parse(sr.ReadLine());
                for (int i = 0; i < loopCounter; i++)
                {
                    blocklist = sr.ReadLine().Split(',');
                }
                 
            } 
        }
        public void Update(float t)
        {
            for (int i = 0; i < monsterManager.monsters.Count; i++)
            {
                towerManager.checkForTarget(monsterManager.monsters[i].hitBox, i, t);
            }

            updateBullets();



            //Laddar in och spawnar från fil. Bör läggas någon annan stans senare
            waveTimer += t;
            currentWaveSize = int.Parse(blocklist[1 + currentWave]);
            if (waveTimer > int.Parse(blocklist[0 + currentWave]))
            {
                waveTimer = 0;
                monsterManager.addMonster(path.GetPos(path.beginT + 300));
                nrOfMonstersSpawned++;
            }
            

            
            
            

            //för test
            /*testTimer += t;
            if (testTimer > 1)
            {
                monsterManager.addMonster(path.GetPos(path.beginT + 300));
                testTimer = 0;
            }*/

            handleBulletCollision();
            particleHandler.Update(t);
            this.towerManager.Update(t);
            this.monsterManager.Update(path.GetPos(path.beginT), t, path);
        }
        public void Draw(SpriteBatch sb)
        {
            path.Draw(sb);
            path.DrawPoints(sb);
            towerManager.Draw(sb);
            monsterManager.Draw(sb);
            particleHandler.Draw(sb);
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
        public void handleBulletCollision()
        {           
            for (int i = 0; i < towerManager.bulletManager.bullets.Count; i++)
            {
                for (int k = 0; k < monsterManager.monsters.Count; k++)
                {
                    if (monsterManager.monsters[k].hitBox.Intersects(towerManager.bulletManager.bullets[i].hitBox))
                    {   
                        
                        monsterManager.monsters[k].health -= towerManager.bulletManager.bullets[i].dmg;
                        if (!monsterManager.monsters[k].slowEffect)
                        {
                            monsterManager.monsters[k].slowEffect = true;
                            monsterManager.monsters[k].speed *= towerManager.bulletManager.bullets[i].slowEffect;
                            particleHandler.addNewParticleExplosion(monsterManager.monsters[k].getPos());
                        }                      
                        towerManager.bulletManager.bullets.RemoveAt(i);
                        break; //Plockar annars bort skott och förstör sedan loopen då antalet skott ändras under loopens gång
                    }
                }
            }
        }
        
    }
}
