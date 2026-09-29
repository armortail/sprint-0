using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0;

public class Player : IPlayer
{
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    public bool IsGrounded { get; set; }

    private ISprite currentSprite;
    private SpriteEffects spriteEffect = SpriteEffects.None;
    private const float Gravity = 800f;
    private const float MoveSpeed = 250f;
    private const float JumpVelocity = -400f;
    private const float FloorY = 500f; // Temporary ground level for testing (became semi perminant for now lol))

    public Player(ISprite sprite, Vector2 startPosition)
    {
        currentSprite = sprite;
        Position = startPosition;
        Velocity = Vector2.Zero;
    }

    public void Move(float direction)
    {
        Velocity = new Vector2(direction * MoveSpeed, Velocity.Y);
        if (direction < 0) spriteEffect = SpriteEffects.FlipHorizontally;
        else if (direction > 0) spriteEffect = SpriteEffects.None;
    }

    public void Jump()
    {
        if (IsGrounded)
        {
            Velocity = new Vector2(Velocity.X, JumpVelocity);
            IsGrounded = false;
        }
    }

    public void ActionAt(Vector2 targetPosition)
    {
        Position = Vector2.Lerp(Position, targetPosition, 0.2f);
    }

    public void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        Velocity = new Vector2(Velocity.X, Velocity.Y + Gravity * dt);
        Position += Velocity * dt;

        if (Position.Y >= FloorY)
        {
            Position = new Vector2(Position.X, FloorY);
            Velocity = new Vector2(Velocity.X, 0);
            IsGrounded = true;
        }

        if (!IsGrounded)
            currentSprite.SetAnimation(AnimationState.Jump);
        else if (Velocity.X != 0)
            currentSprite.SetAnimation(AnimationState.Run);
        else
            currentSprite.SetAnimation(AnimationState.Idle);

        currentSprite.Update(gameTime);

        Velocity = new Vector2(0, Velocity.Y); //idk why this took me the longest but the order of these things matter...
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentSprite.Draw(spriteBatch, Position, spriteEffect);
    }
}