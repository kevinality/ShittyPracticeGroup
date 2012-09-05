using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShittyPracticeGroup
{
	class Boss
	{
	Vector2 position;
        Vector2 motion;
        float bossSpeed = 0f;


        Texture2D texture;
        Rectangle screenBounds;

        public Boss(Texture2D texture, Rectangle screenBounds)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            SetInStartPosition();
        }

				#region Input&Motion
        public void Update()
        {
          //Implementation for motion
					motion = Vector2.Zero;
					//TODO: Boss AI.
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
						//start boss in the middle of the top quarter of screen
						position.X = (screenBounds.Width - texture.Width) / 2;
						position.Y = (screenBounds.Width / 4);
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
