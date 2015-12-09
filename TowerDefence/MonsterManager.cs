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
    class MonsterManager
    {
        Texture2D tex;
        public List<Monster> monsters;
        public MonsterManager(Texture2D tex)
        {
            this.tex = tex;
            this.monsters = new List<Monster>();
        }
        public void Update(Vector2 pathStart, float t, SimplePath path)
        {
            foreach(Monster m in monsters)
            {
                m.update(path.GetPos(path.beginT + m.velocity), t);
            }
            clearMonsters();
        }
        public void addMonster(Vector2 startPos)
        {
            this.monsters.Add(new Monster(tex, startPos));
        }
        public void Draw(SpriteBatch sb)
        {
            foreach (Monster m in monsters)
            {
                m.Draw(sb);
            }
        }
        public void clearMonsters()
        {
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].health < 0)
                {
                    monsters.RemoveAt(i);
                }
            }
        }
    }
}
