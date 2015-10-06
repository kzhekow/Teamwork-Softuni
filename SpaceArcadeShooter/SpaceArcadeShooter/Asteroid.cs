﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceArcadeShooter
{
    class Asteroid : GameObject
    {
        static Random RNG = new Random();
        public int startPosition = RNG.Next(0, 700);

        const int maxLeftSpeed = -3;
        const int maxRightSpeed = 4;

        const int minFallSpeed = 2;
        const int maxFallSpeed = 6;

        public Asteroid(int X, int Y, string imagePath) : base(X, Y, imagePath)
        {
            collisionTimer.Start();
            Xspeed = RNG.Next(maxLeftSpeed, maxRightSpeed);
            Yspeed = RNG.Next(minFallSpeed, maxFallSpeed);
            this.X = startPosition + X;
            this.Y = RNG.Next(-1600, -200);
        }

        public void Move()
        {
            // If asteroid moves to the sides, get it back up
            // to a random position with random fall speed
            // and random side movement.
            X += Xspeed;
            if (X < -200 || X > 900)
            {                
                Xspeed = RNG.Next(maxLeftSpeed, maxRightSpeed);
                Yspeed = RNG.Next(minFallSpeed, maxFallSpeed);
                X = RNG.Next(0, 700);
                Y = -200;
            }

            // If asteroid falls down, get it back up
            // to a random position with random fall speed
            // and random side movement.
            Y += Yspeed;
            if (Y < -1700 || Y > 800)
            {
                Xspeed = RNG.Next(maxLeftSpeed, maxRightSpeed);
                Yspeed = RNG.Next(minFallSpeed, maxFallSpeed);
                X = RNG.Next(0, 700);
                Y = -200;
            }
        }

        public void MoveTo(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            if (Y > 800) this.Y -= 1500;
        }

        public void RotateImage()
        {
            img = Engine.RotateImage(img, 1);
        }

        public static Asteroid[] MakeAsteroids()
        {
            // Repeat them twice for more asteroids
            string[] starPaths = { @"Asteroids\medium_Asteroid0.png", @"Asteroids\medium_Asteroid1.png",
                                   @"Asteroids\medium_Asteroid2.png", @"Asteroids\medium_Asteroid3.png",
                                   @"Asteroids\medium_Asteroid4.png", @"Asteroids\medium_Asteroid5.png",

                                   @"Asteroids\small_Asteroid0.png", @"Asteroids\small_Asteroid1.png",
                                   @"Asteroids\small_Asteroid2.png", @"Asteroids\small_Asteroid3.png",
                                   @"Asteroids\small_Asteroid4.png", @"Asteroids\small_Asteroid5.png",

                                   @"Asteroids\big_Asteroid0.png", @"Asteroids\big_Asteroid1.png",
                                   @"Asteroids\big_Asteroid2.png", @"Asteroids\big_Asteroid3.png",
                                   @"Asteroids\big_Asteroid4.png", @"Asteroids\big_Asteroid5.png",
            };

            Asteroid[] Asteroids = new Asteroid[starPaths.Length];

            for (int i = 0; i < Asteroids.Length; i++)
            {
                Asteroids[i] = new Asteroid(0, 0, starPaths[i]);
                Asteroids[i].collidable = true;
            }

            return Asteroids;
        }
    }
}
