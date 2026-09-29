namespace Sprint_0;

public class JumpCommand : ICommand
{
    private IPlayer player;

    public JumpCommand(IPlayer player) => this.player = player;

    public void Execute() => player.Jump();
}