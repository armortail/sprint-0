using Microsoft.Xna.Framework.Input;

namespace Sprint_0;

public class KeyboardController : IController
{
    private ICommand[] keyCommands = new ICommand[256];

    public void RegisterCommand(Keys key, ICommand command)
    {
        keyCommands[(int)key] = command;
    }

    public void Update()
    {
        Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

        foreach (Keys key in pressedKeys)
        {
            ICommand command = keyCommands[(int)key];
            if (command != null)
            {
                command.Execute();
            }
        }
    }
}