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
    class Bullet : GameObject
    {
        public Rectangle hitBox;
        Vector2 startPos;
        Vector2 targetPos;
        public int targetIndex;
        public float dmg;
        public float slowEffect;
       // Vector2 endPos;
        public Bullet(Vector2 startPos, Vector2 endPos, Texture2D tex, int targetIndex, float dmg) : base(startPos, tex)
        {
            this.startPos = startPos;
            this.dmg = dmg;
            //this.endPos = endPos;
            this.hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
            this.targetIndex = targetIndex;
            this.slowEffect = 1.0f;
        }
        public void update()
        {
            Vector2 dest = Vector2.Normalize(this.targetPos - this.pos);        //- startpos om skottet ska fortsätta
            this.pos += dest * 20;
            this.hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
            
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, this.pos, Color.White);
        }
        public void updateTargetPos(Vector2 pos)
        {
            this.targetPos = pos;
        }
    }
}
