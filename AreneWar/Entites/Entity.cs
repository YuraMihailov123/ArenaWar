﻿using System.Drawing;

namespace AreneWar.Entites
{
    public class Entity
    {
        public int posX;
        public int posY;

        public int dirX;
        public int dirY;
        public bool isMoving;

        public int flip;

        public int currentAnimation;
        public int currentFrame;
        public int currentLimit;

        public int idleFrames;
        public int runFrames;
        public int attackFrames;
        public int deathFrames;

        public int size;

        public Image spriteSheet;

        public Entity(int posX,int posY,int idleFrames,int runFrames, int attackFrames,int deathFrames,Image spriteSheet)
        {
            this.posX = posX;
            this.posY = posY;
            this.idleFrames = idleFrames;
            this.runFrames = runFrames;
            this.attackFrames = attackFrames;
            this.deathFrames = deathFrames;
            this.spriteSheet = spriteSheet;
            size = 31;
            currentAnimation = 0;
            currentFrame = 0;
            currentLimit = idleFrames;
            flip = 1;
        }

        public void Move()
        {
            posX += dirX;
            posY += dirY;
        }

        public void PlayAnimation(Graphics g)
        {
            g.DrawImage(spriteSheet, new Rectangle(new Point(posX - flip*size/2, posY), new Size(flip*size, size)),32*currentFrame, 32*currentAnimation, size, size, GraphicsUnit.Pixel);

            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else currentFrame = 0;
        }

        public void SetAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    currentLimit = idleFrames;
                    break;
                case 1:
                    currentLimit = runFrames;
                    break;
                case 2:
                    currentLimit = attackFrames;
                    break;
                case 4:
                    currentLimit = deathFrames;
                    break;
            }
        }
    }
}
