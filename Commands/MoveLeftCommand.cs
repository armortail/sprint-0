namespace Sprint_0;

public class MoveLeftCommand : ICommand
{
    private IPlayer player;

    public MoveLeftCommand(IPlayer player) => this.player = player;

    public void Execute() => player.Move(-1f);
}