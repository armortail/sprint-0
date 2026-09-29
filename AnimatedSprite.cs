using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0;

public enum AnimationState
{
    Idle,
    Run,
    Jump
}

public class AnimatedSprite : ISprite
{
    private Texture2D texture;
    private int rows;
    private int columns;

    private AnimationState currentState;
    private int currentRow;
    private int currentFrameCount;

    private int currentFrame;
    private double frameTimer;
    private double frameInterval = 0.1;
    private const int IdleRow = 0;
    private const int IdleFrameCount = 1;
    private const int RunRow = 1;
    private const int RunFrameCount = 3;
    private const int JumpRow = 2;
    private const int JumpFrameCount = 1;

    public AnimatedSprite(Texture2D texture, int rows, int columns)
    {
        this.texture = texture;
        this.rows = rows;
        this.columns = columns;

        SetAnimation(AnimationState.Idle);
    }

    public void SetAnimation(AnimationState state)
    {
        if (state == currentState && currentFrameCount != 0) return;

        currentState = state;

        switch (state)
        {
            case AnimationState.Idle:
                currentRow = IdleRow;
                currentFrameCount = IdleFrameCount;
                break;
            case AnimationState.Run:
                currentRow = RunRow;
                currentFrameCount = RunFrameCount;
                break;
            case AnimationState.Jump:
                currentRow = JumpRow;
                currentFrameCount = JumpFrameCount;
                break;
        }

        currentFrame = 0;
        frameTimer = 0;
    }

    public void Update(GameTime gameTime)
    {
        frameTimer += gameTime.ElapsedGameTime.TotalSeconds;
        if (frameTimer >= frameInterval)
        {
            currentFrame = (currentFrame + 1) % currentFrameCount;
            frameTimer = 0;
        }
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, SpriteEffects effects)
{
    int width = texture.Width / columns;
    int height = texture.Height / rows;

    Rectangle sourceRectangle = new Rectangle(
        width * currentFrame,
        height * currentRow,
        width,
        height);

    Vector2 origin = new Vector2(width, height) * 0.5f;

    spriteBatch.Draw(
        texture,                    //texture
        position,                   //position
        sourceRectangle,            //source rectangle (which part of the texture to draw)
        Color.White,                //color applies tint and * percent opaque wanted
        MathHelper.ToRadians(0),    //rotation (in degrees)
        origin,                     //origin
        new Vector2(4f, 4f),        //scale first is x axis second is y axis
        effects,                    //effects
        0.0f                        //layer depth
    );
}
}