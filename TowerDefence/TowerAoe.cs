using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace TowerDefence
{
    class TowerAoe : Tower
    {
                


        public TowerAoe(Vector2 pos, Texture2D tex, Texture2D bulletTex) : base (pos, tex, bulletTex)
        {
           
            this.hitBox = new Rectangle((int)pos.X - 200, (int)pos.Y - 200, tex.Width + 400, tex.Height + 400);

            this.rangeBox = new Rectangle((int)pos.X - 200, (int)pos.Y - 200, tex.Width + 400, tex.Height + 400);
        }
        public override void Update(Vector2 target, float t)
        {
            if (hasTarget)
            {
                
            }
          
        }
        public override void levelUp()
        {
            this.lvl++;
            this.dmg *= lvl;

        }
        public override void shoot(Vector2 target, float t)
        {

        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, Color.White);
            /*for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw(sb);
            }*/
        }

    }
}
