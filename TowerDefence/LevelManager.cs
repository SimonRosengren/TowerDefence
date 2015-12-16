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
        KeyMouseReader kmReader;
        actionBar menuBar;
        int? selectedTower;
        String[] blocklist = new String[100];
        int currentWaveSize;
        int nrOfMonstersSpawned;
        int currentWave;
        float waveTimer = 0;

        enum towerBuildSelection { none, NormalTower, SlowTower}
        towerBuildSelection currentTowerBuildSelection = towerBuildSelection.none;

        public LevelManager(GraphicsDevice graphicDevice, Texture2D monsterTex, Texture2D towerTex, Texture2D bulletTex, Texture2D bottomBarBG)
        {
            menuBar = new actionBar(bottomBarBG, bulletTex); //ändra tex
            kmReader = new KeyMouseReader();
            selectedTower = null;
            path = new SimplePath(graphicDevice);
            path.generateDefaultPath();
            this.monsterManager = new MonsterManager(monsterTex);
            this.towerManager = new TowerManager(towerTex, bulletTex);
            this.currentWave = 0;
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
            using (StreamReader sr = new StreamReader("Level.txt"))
            {
                while (!sr.EndOfStream)
                {
                    blocklist = sr.ReadLine().Split(',');
                }                 
            } 
        }
        public void Update(float t)
        {
            kmReader.Update();
            checkForMouseActivity();
            for (int i = 0; i < monsterManager.monsters.Count; i++)
            {
                towerManager.checkForTarget(monsterManager.monsters[i].hitBox, i, t);
            }

            updateBullets();



            //Laddar in och spawnar från fil. Bör läggas någon annan stans senare
            waveTimer += t;
            currentWaveSize = int.Parse(blocklist[currentWave + 1]);
            if (waveTimer > int.Parse(blocklist[currentWave * 2]) && nrOfMonstersSpawned < int.Parse(blocklist[currentWave * 2 + 1]))
            {
                waveTimer = 0;
                monsterManager.addMonster(path.GetPos(path.beginT + 300));
                nrOfMonstersSpawned++;
            }
            if (nrOfMonstersSpawned >= int.Parse(blocklist[currentWave * 2 + 1]))
            {
                //Level cleared
                currentWave++;
                nrOfMonstersSpawned = 0;
                Console.Write("" + int.Parse(blocklist[1]));
            }
            
            

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
            menuBar.Draw(sb);
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
        public void checkForMouseActivity()
        {
            //För lvlEditor
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                int ? point = path.GetNearestPoint(Mouse.GetState().Position.ToVector2(), 20f);
                if (point != null)
                {
                    path.SetPos((int)point, Mouse.GetState().Position.ToVector2());
                }
            }
            //Tower Selection
            if (kmReader.LeftClick())
            {
                for (int i = 0; i < towerManager.towers.Count; i++)
                {
                    if (towerManager.towers[i].hitBox.Contains(Mouse.GetState().Position.ToVector2()))
                    {
                        selectedTower = i;
                        towerManager.towers[i].isSelected = true;
                    }
                }
                if (menuBar.getButtonPressed(Mouse.GetState().Position.ToVector2()) == 1)
                {
                    foreach (Tower t in towerManager.towers)
                    {
                        if (t.isSelected)
                        {
                            t.levelUp();
                        }

                    }
                }
                if (currentTowerBuildSelection == towerBuildSelection.NormalTower)
                {
                    towerManager.addNormalTower(Mouse.GetState().Position.ToVector2());
                }
                if (currentTowerBuildSelection == towerBuildSelection.SlowTower)
                {
                    towerManager.addSlowTower(Mouse.GetState().Position.ToVector2());
                }



                if (menuBar.getButtonPressed(Mouse.GetState().Position.ToVector2()) == 2)
                {
                    currentTowerBuildSelection = towerBuildSelection.NormalTower;
                }

            }
            if (kmReader.keyState.IsKeyDown(Keys.Escape))
            {
                foreach (Tower t in towerManager.towers)
                {
                    t.isSelected = false;
                }
            }

        }

        
    }
}
