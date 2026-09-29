namespace Sprint_0;

public class MoveRightCommand : ICommand
{
    private IPlayer player;

    public MoveRightCommand(IPlayer player) => this.player = player;

    public void Execute() => player.Move(1f);
}