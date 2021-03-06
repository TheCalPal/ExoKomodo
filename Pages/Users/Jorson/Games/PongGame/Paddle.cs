using System;
using ExoKomodo.Helpers.P5.Enums;
using ExoKomodo.Helpers.P5.Models;

namespace ExoKomodo.Pages.Users.Jorson.Games.PongGame
{
    public class Paddle
    {
        #region Public

        #region Constructors
        public Paddle(PongApp application)
        {
            Application = application;
        }
        #endregion

        #region Members
        public readonly PongApp Application;
        public Rectangle Body { get; set; }
        public Color FillColor { get; set; }
        public double HalfHeight => Body.Height / 2;
        public double HalfWidth => Body.Width / 2;
        public uint Score { get; set; }
        public const double Speed = 100;
        public Color? StrokeColor { get; set; }
        #endregion
        
        #region Member Methods
        public void Draw()
        {
            Application.Push();
            if (StrokeColor.HasValue)
            {
                Application.Stroke(StrokeColor.Value);
            }
            Application.Fill(FillColor);
            Application.SetRectangleMode(RectangleMode.Center);
            Application.DrawRectangle(Body);
            Application.Pop();
        }

        public void UpdateAi()
        {
            var ball = Application.Ball;
            var delta = Application.DeltaTime;
            if (delta == 0)
            {
                return;
            }

            var plannedMove = Math.Min(
                Math.Abs(Body.Y - ball.Body.Y),
                Speed / delta
            );
            if (Body.Y > ball.Body.Y)
            {
                Body.Y -= plannedMove;
            }
            else if (Body.Y < ball.Body.Y)
            {
                Body.Y += plannedMove;
            }

            Body.Y = Math.Clamp(
                Body.Y,
                HalfHeight,
                Application.Height - HalfHeight
            );
        }

        public void UpdatePlayer()
        {
            Body.Y = Math.Clamp(
                Application.MouseY,
                HalfHeight,
                Application.Height - HalfHeight
            );
        }

        #endregion

        #endregion
    }
}
