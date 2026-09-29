using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0library;

namespace Sprint_0;

public class Game1 : Core
{
    private Player player;
    private IController keyboardController;
    private IController mouseController;

    private Texture2D _mario;
    private SpriteFont _font;
    public Game1() : base("Sprint 0", 1280, 720, false)
    {
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
        //if dependent on assets and needs to be initialized put here
    }

    protected override void LoadContent() //assets
    {
        _mario = Content.Load<Texture2D>("SpriteSheet/mario_spritesheet");
        ISprite sprite = new AnimatedSprite(_mario, rows: 3, columns: 3);
        player = new Player(sprite, new Vector2(300, 1500));

        _font = Content.Load<SpriteFont>("spritefont");

        var kb = new KeyboardController();
        kb.RegisterCommand(Keys.A, new MoveLeftCommand(player));
        kb.RegisterCommand(Keys.D, new MoveRightCommand(player));
        kb.RegisterCommand(Keys.Space, new JumpCommand(player));
        kb.RegisterCommand(Keys.Escape, new QuitCommand(this)); 
        //This was made for consistency, yes i know the escape key wass already handled in the update method, but this was made for consistency with the other commands and removed in update
        keyboardController = kb;

        var mouse = new MouseController();
        mouse.RegisterCommand(MouseButton.LeftClick, new MouseActionCommand(player));
        mouseController = mouse;
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        keyboardController.Update();
        mouseController.Update();
        player.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SpriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack);

        string text = "Credits: \nProgram made by: Arav Bhagat \nSprite sheet: https://www.spriters-resource.com/nes/supermariobros/asset/50365/ \n(I used this but cut and modified by AI)";

        Vector2 textSize = _font.MeasureString(text);

        SpriteBatch.DrawString(

            _font, //texture

            text,

            new Vector2( //position

                Window.ClientBounds.Width* 0.5f,

                Window.ClientBounds.Height* 0.85f), //i want it offset

            Color.White,

            MathHelper.ToRadians(0), 

            textSize * 0.5f, 

            new Vector2(2f, 2f), //scale first is x axis second is y axis

            SpriteEffects.None, //effects

            0.1f //layer depth

        );

        player.Draw(SpriteBatch);

        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
