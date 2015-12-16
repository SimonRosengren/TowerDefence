using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    class ParticleHandler
    {
        List<Particle> particles;
        Random rnd;
        Texture2D tex;
        public ParticleHandler(Texture2D tex)
        {
            this.tex = tex;
            this.particles = new List<Particle>();
            rnd = new Random();
        }
        public void addNewParticleExplosion(Vector2 pos)
        {
            
            for (int i = 0; i < 5000; i++)
            {
                int multiplyerX = 1;
                int multiplyerY = 1;
                int speed;
                speed = rnd.Next(1, 7);
                if (rnd.Next(0, 2) == 0)
                {
                    multiplyerX = -1;
                }
                if (rnd.Next(0, 2) == 0)
                {
                    multiplyerY = -1;
                }
                Particle p = new Particle(tex, pos, new Vector2((float)rnd.NextDouble() * multiplyerX, (float)rnd.NextDouble() * multiplyerY), speed, rnd.NextDouble());
                particles.Add(p);
            }

        }
        public void Update(float t)
        {
            foreach (Particle p in particles)
            {
                p.update(t);
            }
            clearList();
        }
        private void clearList()
        {
            int counter = 0;
            foreach (Particle p in particles)
            {
                counter++;
                if (!p.isAlive)
                {
                    particles.RemoveAt(counter);
                }
                break;
            }
        }
        public void Draw(SpriteBatch sb)
        {
            foreach (Particle p in particles)
            {
                if (p.speed < 3)
                {
                    sb.Draw(tex, p.hitBox, Color.Red * (float)p.timeToLive);
                }
                if (p.speed > 3 && p.speed < 5)
                {
                    sb.Draw(tex, p.hitBox, Color.Orange * (float)p.timeToLive);
                }
                if (p.speed > 5)
                {
                    sb.Draw(tex, p.hitBox, Color.Yellow * (float)p.timeToLive);
                }
                
            }
        }
    }
}
