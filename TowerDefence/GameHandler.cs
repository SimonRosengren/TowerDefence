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
    class GameHandler
    {
        List<Tower> towers;
        List<Monster> monsters;
        SimplePath path;


        public GameHandler(GraphicsDevice gd)
        {
            this.towers = new List<Tower>();
            this.monsters = new List<Monster>();
            this.path = new SimplePath(gd);
        }
        public void update(float t)
        {
            foreach (Monster monster in monsters)
            {
                
            }

        }
        public void Draw(SpriteBatch sb)
        {
            foreach (Tower tower in towers)
            {
                tower.Draw(sb);
            }
            path.Draw(sb);
        }
        public void loadLevel()
        {

        }
    }
}
