using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    class TowerSlow : Tower
    {
        public TowerSlow(Vector2 pos, Texture2D tex, Texture2D bulletTex)
            : base(pos, tex, bulletTex)
        {
            this.slowEffect = 0.5f;
            this.dmg = 25;


            this.rangeBox = new Rectangle((int)pos.X - 200, (int)pos.Y - 200, tex.Width + 400, tex.Height + 400);
        }
        public override void Update(Vector2 target, float t)
        {


        }
        public override void levelUp()
        {
            this.lvl++;
            this.dmg *= lvl;

        }
        public override void shoot(Vector2 target, float t)
        {
            // Bullet bullet = new Bullet(pos, target, bulletTex);
        }
        public override void Draw(SpriteBatch sb)
        {
            if (isSelected)
            {
                sb.Draw(tex, pos, Color.Black);
            }
            else
                sb.Draw(tex, hitBox, Color.Blue);
        }

    }
}
