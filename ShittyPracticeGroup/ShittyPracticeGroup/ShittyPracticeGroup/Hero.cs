using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShittyPracticeGroup
{
    class Hero
    {
        Vector2 position;
        Vector2 motion;
        float heroSpeed = 0f;

        KeyboardState keyboardState;
        GamePadState gamePadState;

        Texture2D texture;
        Rectangle screenBounds;

        public Hero(Texture2D texture, Rectangle screenBounds)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            SetInStartPosition();
        }

				#region Input&Motion
        public void Update()
        {
            motion = Vector2.Zero;
						int directionX = 0;
						int directionY = 0;
						float heroSpeed = 5f;

            keyboardState = Keyboard.GetState();
            gamePadState = GamePad.GetState(PlayerIndex.One);

						if (keyboardState.IsKeyDown(Keys.Left) || 
							gamePadState.IsButtonDown(Buttons.LeftThumbstickLeft) || 
							gamePadState.IsButtonDown(Buttons.DPadLeft))
							{
							directionX = -1;
							}

						if (keyboardState.IsKeyDown(Keys.Up) || 
							gamePadState.IsButtonDown(Buttons.LeftThumbstickUp) || 
							gamePadState.IsButtonDown(Buttons.DPadUp))
							{
							directionY = -1;
							}

						if (keyboardState.IsKeyDown(Keys.Right) || 
							gamePadState.IsButtonDown(Buttons.LeftThumbstickRight) || 
							gamePadState.IsButtonDown(Buttons.DPadRight))
							{
							directionX = 1;
							}

						if (keyboardState.IsKeyDown(Keys.Down) || 
							gamePadState.IsButtonDown(Buttons.LeftThumbstickDown) || 
							gamePadState.IsButtonDown(Buttons.DPadDown))
							{
							directionY = 1;
							}

						motion.X = directionX * heroSpeed;
						motion.Y = directionY * heroSpeed;
						position += motion;
						LockHero();
						}
						#endregion


						public void LockHero()
						{
							//TODO: eventually this can go to parent class for all objects (ie boss)
							if (position.X < 0)
							position.X = 0;
							if (position.X + texture.Width > screenBounds.Width)
							position.X = screenBounds.Width - texture.Width;
							if (position.Y < 0)
							position.Y = 0;
							if (position.Y + texture.Height > screenBounds.Height)
							position.Y = screenBounds.Height - texture.Height;
						}

						public void SetInStartPosition()
						{
						//start hero in the middle of the bottom of screen
						position.X = (screenBounds.Width - texture.Width) / 2;
						position.Y = screenBounds.Height - texture.Height - 5;
						}

						public void Draw(SpriteBatch spriteBatch)
						{
						spriteBatch.Draw(texture, position, Color.White);
						}

						public Rectangle GetBounds()
						{
							return new Rectangle(
							(int)position.X,
							(int)position.Y,
							texture.Width,
							texture.Height);
						}

    }
}
