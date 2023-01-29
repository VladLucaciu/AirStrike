﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirStrike
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, shooting, isGameOver;
        int score;
        int playerSpeed = 12;
        int enemySpeed;
        int bulletSpeed;
        Random rnd = new Random();




        public Form1()
        {
            InitializeComponent();
            resetGame();
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {

            txtScore.Text = score.ToString();


            enemyOne.Top += enemySpeed;
            enemyTwo.Top += enemySpeed;
            enemyThree.Top += enemySpeed;


            if (enemyOne.Top > 710 || enemyTwo.Top > 710 || enemyThree.Top > 710)
            {
                gameOver();

            }
               




            // logic to move the player on the left right axis dpending on pixels alocated for screen
            if(goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;

            }
            if(goRight == true && player.Left < 600)
            {
                player.Left += playerSpeed;
                // end of the orientation inputs
            }

            if (shooting == true)
            {
                bulletSpeed = 20;
                bullet.Top -= bulletSpeed;

            }
            else
            {
                bullet.Left = -300;
                bulletSpeed = 0;

            }
            if (bullet.Top < -30)
            {
                shooting = false;

            }
            if (bullet.Bounds.IntersectsWith(enemyOne.Bounds) )
            {
                score += 1;
                enemyOne.Top = -450;
                enemyOne.Left = rnd.Next(20, 600);
                shooting = false;
            }
            if(bullet.Bounds.IntersectsWith(enemyTwo.Bounds))
            {
                score += 1;
                enemyTwo.Top = -650;
                enemyTwo.Left = rnd.Next(20, 600);
                shooting = false;
            }
            if(bullet.Bounds.IntersectsWith(enemyThree.Bounds))
            {
                score += 1;
                enemyThree.Top = -750;
                enemyThree.Left = rnd.Next(20, 600);
                shooting = false;
            }

            if (score == 10)
            {
                enemySpeed = 5;
            }
            if (score == 15)
            {
                enemySpeed = 6;
            }
            if (score == 20)
            {
                enemySpeed = 8;
            }
        }


        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Space && shooting == false) 
            {
                shooting = true;
                bullet.Top = player.Top - 30;
                bullet.Left = player.Left + (player.Width / 2);

            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetGame();
            }
        }

        private void resetGame()
        {
            gameTimer.Start();
            enemySpeed = 3;

            enemyOne.Left = rnd.Next(20, 600);
            enemyTwo.Left = rnd.Next(20, 600);
            enemyThree.Left = rnd.Next(20, 600);

            enemyOne.Top = rnd.Next(0, 600) * -1;
            enemyTwo.Top = rnd.Next(0, 500) * -1;
            enemyThree.Top = rnd.Next(0, 900) * -1;

            score = 0;
            bulletSpeed = 0;
            bullet.Left = - 300;
            shooting = false;

            txtScore.Text = score.ToString();



        }
        
        private void gameOver()
        {
            isGameOver = true;
            gameTimer.Stop();
            txtScore.Text += Environment.NewLine + "Game Over" + Environment.NewLine + "Press Enter to try again";

        }

    }
}
