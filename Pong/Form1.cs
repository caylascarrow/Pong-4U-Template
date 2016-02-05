/*
 * Description:     A basic PONG simulator
 * Author:     Cayla Scarrow
 * Date:     February 2016
 */

#region libraries

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;

#endregion

namespace Pong
{
    public partial class Form1 : Form
    {
        #region global values

        //paddle position variables
        int paddle1Y, paddle2Y;

        //ball position variables
        int ballX, ballY;

        // check to see if a new game can be started
        Boolean newGameOk = true;

        //ball directions
        Boolean ballMoveRight = false;
        Boolean ballMoveDown = false;

        //constants used to set size and speed of paddles 
        const int PADDLE_LENGTH = 40;
        const int PADDLE_WIDTH = 10;
        const int PADDLE_EDGE = 20;  // buffer distance between screen edge and paddle
        const int PADDLE_SPEED = 4;

        //constants used to set size and speed of ball 
        const int BALL_SIZE = 10;
        const int BALL_SPEED = 4;

        //player scores
        int player1Score = 0;
        int player2Score = 0;

        //determines whether a key is being pressed or not
        Boolean aKeyDown, zKeyDown, jKeyDown, mKeyDown;

        //game winning score
        int gameWinScore = 2;

        //brush for paint method
        SolidBrush drawBrush = new SolidBrush(Color.White);

        #endregion

        public Form1()
        {
            InitializeComponent();
            SetParameters();        
        }

        // -- YOU DO NOT NEED TO MAKE CHANGES TO THIS METHOD
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.Z:
                    zKeyDown = true;
                    break;
                case Keys.J:
                    jKeyDown = true;
                    break;
                case Keys.M:
                    mKeyDown = true;
                    break;
                case Keys.Y:
                    if (newGameOk)
                    {
                        GameStart();
                    }
                    break;
                case Keys.N:
                    if (newGameOk)
                    {
                        Close();
                    }
                    break;
                case Keys.Space:
                    if (newGameOk)
                    {
                        GameStart();
                    }
                    break;
                default:
                    break;
            }
        }
        
        // -- YOU DO NOT NEED TO MAKE CHANGES TO THIS METHOD
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //check to see if a key has been released and set its KeyDown value to false if it has
            switch (e.KeyCode)
            {
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.Z:
                    zKeyDown = false;
                    break;
                case Keys.J:
                    jKeyDown = false;
                    break;
                case Keys.M:
                    mKeyDown = false;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Sets up the game objects in their start position, resets the scores, displays a 
        /// countdown, and then starts the game timer.
        /// </summary>
        private void GameStart()
        {
            newGameOk = true;
            SetParameters();

            // create code to make a graphics object, a brush, and a font to display the countdown
            Graphics g = this.CreateGraphics();
            SolidBrush textBrush = new SolidBrush(Color.White);
            Font countDownFont = new Font("Courier New", 50, FontStyle.Regular);

            startLabel.Visible = false;
            Refresh();
            
            //countdown to start of game
            for (int i = 3; i > 0; i--) // create conditions for a for loop that counts down from 3 
            {
                // --- create code using DrawString to display the countdown in the appropriate area. 

                if (i == 3)
                {
                    g.DrawString("3", countDownFont, textBrush, this.Width / 2 - 35, this.Height / 2);
                }
                else if (i == 2)
                {
                    g.DrawString("2", countDownFont, textBrush, this.Width / 2 - 35, this.Height / 2);
                }
                else
                {
                    g.DrawString("1", countDownFont, textBrush, this.Width / 2 - 35, this.Height / 2);
                }

                // --- sleep for 1 second
                Thread.Sleep(1000);

                // --- refresh the screen
                this.Refresh();
            }

            // start the gameUpdateLoop timer
            gameUpdateLoop.Enabled = true;

            newGameOk = false;
        }

        /// <summary>
        /// sets the ball and paddle positions for game start
        /// </summary>
        private void SetParameters()
        {
            if (newGameOk)
            {
                // sets location of score labels to the middle of the screen
                player1Label.Location = new Point(this.Width / 2 - player1Label.Size.Width - 10, player1Label.Location.Y);
                player2Label.Location = new Point(this.Width / 2 + 10, player2Label.Location.Y);

                //set label, score variables, and ball position
                player1Score = player2Score = 0;
                player1Label.Text = "Player 1:  " + player1Score;
                player2Label.Text = "Player 2:  " + player2Score;

                paddle1Y = paddle2Y = this.Height / 2 - PADDLE_LENGTH / 2;

            }

            // set starting X position for ball to middle of screen, (use this.Width and BALL_SIZE)
            ballX = (this.Width / 2) - (BALL_SIZE / 2);

            // set starting Y position for ball to middle of screen, (use this.Height and BALL_SIZE)
            ballY = (this.Height / 2) - (BALL_SIZE / 2);

        }

        /// <summary>
        /// This method is the game engine loop that updates the position of all elements
        /// and checks for collisions.
        /// </summary>
        private void gameUpdateLoop_Tick(object sender, EventArgs e)
        {
            //sound player to be used for all in game sounds initially set to collision sound
            SoundPlayer player = new SoundPlayer();
            player = new SoundPlayer(Properties.Resources.collision);

            #region update ball position

            // TODO create code to move ball either left or right based on ballMoveRight and BALL_SPEED
            //ballMoveRight = 

            // TODO create code move ball either down or up based on ballMoveDown and BALL_SPEED

            #endregion

            #region update paddle positions

            if (aKeyDown == true && paddle1Y > 0)
            {
                // TODO create code to move player 1 paddle up using paddle1Y and PADDLE_SPEED
            }

            // TODO create an if statement and code to move player 1 paddle down using paddle1Y and PADDLE_SPEED

            // TODO create an if statement and code to move player 2 paddle up using paddle2Y and PADDLE_SPEED

            // TODO create an if statement and code to move player 2 paddle down using paddle2Y and PADDLE_SPEED

            #endregion

            #region ball collision with top and bottom lines

            if (ballY < 0) // if ball hits top line
            {
                // TODO use ballMoveDown boolean to change direction
                // TODO play a collision sound
            }
            // TODO In an else if statement use ballY, this.Height, and BALL_SIZE to check for collision with bottom line
            // If true use ballMoveDown down boolean to change direction

            #endregion

            #region ball collision with paddles

            if (ballY > paddle1Y && ballY < paddle1Y + PADDLE_LENGTH && ballX < PADDLE_EDGE + PADDLE_WIDTH) // left paddle collision
            {
                // TODO play a "paddle hit" sound 
                // TODO use ballMoveRight boolean to change direction
            }
            else if (ballY > paddle2Y && ballY < paddle2Y + PADDLE_LENGTH && ballX + BALL_SIZE > this.Width - PADDLE_EDGE - PADDLE_WIDTH / 2) // right paddle collision
            {
                // TODO play a "paddle hit" sound 
                // TODO use ballMoveRight boolean to change direction
            }

            #endregion

            #region ball collision with side walls (point scored)

            player = new SoundPlayer(Properties.Resources.score);

            if (ballX < 0)  // TODO ball hits left wall logic
            {
                // --- play score sound
                // --- update player 2 score
                // --- update player2Label with new score
                // --- refresh

                // --- use if statement to check to see if player 2 has won the game. If true run 
                // gameWinScore method. Else call SetParameters method to reset ball position.

            }

            // TODO same as above but this time check for collision with the right wall

            #endregion
            
            //refresh the screen, which causes the Form1_Paint method to run
            this.Refresh();
        }
        
        /// <summary>
        /// Displays a message for the winner when the game is over and allows the user to either select
        /// to play again or end the program
        /// </summary>
        /// <param name="winner">The player name to be shown as the winner</param>
        private void GameOver(string winner)
        {
            newGameOk = true;

            // TODO create game over logic
            // --- stop the gameUpdateLoop
            // --- show a message on the startLabel to indicate a winner
            // --- pause for two seconds 
            // --- use the startLabel to ask the user if they want to play again

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // draw paddles using FillRectangle
            e.Graphics.FillRectangle(drawBrush, PADDLE_EDGE, paddle1Y, PADDLE_WIDTH, PADDLE_LENGTH);
            e.Graphics.FillRectangle(drawBrush, (this.Width - (PADDLE_EDGE + PADDLE_WIDTH)), paddle2Y, PADDLE_WIDTH, PADDLE_LENGTH);

            // draw ball using FillRectangle
            e.Graphics.FillRectangle(drawBrush, ballX, ballY, BALL_SIZE, BALL_SIZE);

        }

    }
}
