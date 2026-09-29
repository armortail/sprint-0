using Microsoft.Xna.Framework;

namespace Sprint_0;

public class MouseActionCommand : ICommand
{
    private readonly IPlayer player;
    public MouseActionCommand(IPlayer player) { this.player = player; }
    public void Execute()
    {
        var mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
        player.ActionAt(new Vector2(mouseState.X, mouseState.Y));
    }
}