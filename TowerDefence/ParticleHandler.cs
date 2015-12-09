﻿using System;
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
            
            for (int i = 0; i < 1000; i++)
            {
                int multiplyerX = 1;
                int multiplyerY = 1;
                int speed;
                speed = rnd.Next(50, 500);
                if (rnd.Next(0, 2) == 0)
                {
                    multiplyerX = -1;
                }
                if (rnd.Next(0, 2) == 0)
                {
                    multiplyerY = -1;
                }

                Particle p = new Particle(tex, pos, new Vector2((float)rnd.NextDouble() * multiplyerX, (float)rnd.NextDouble() * multiplyerY), speed);
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
                sb.Draw(tex, p.hitBox, Color.DeepSkyBlue * p.timeToLive);
            }
        }
    }
}
