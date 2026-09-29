using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0;

public interface IPlayer
{
    Vector2 Position { get; set; }
    Vector2 Velocity { get; set; }
    bool IsGrounded { get; set; }
    
    void Move(float direction);
    void Jump();
    void ActionAt(Vector2 targetPosition);
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch);
}