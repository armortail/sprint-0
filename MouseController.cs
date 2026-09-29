using Microsoft.Xna.Framework.Input;

namespace Sprint_0;

public enum MouseButton
{
    LeftClick,
    RightClick
}

public class MouseController : IController
{
    private ICommand leftClickCommand;
    private ICommand rightClickCommand;
    private MouseState previousState;

    public MouseController()
    {
        previousState = Mouse.GetState();
    }

    public void RegisterCommand(MouseButton button, ICommand command)
    {
        switch (button)
        {
            case MouseButton.LeftClick:
                leftClickCommand = command;
                break;
            case MouseButton.RightClick:
                rightClickCommand = command;
                break;
        }
    }

    public void Update()
    {
        MouseState currentState = Mouse.GetState();

        if (currentState.LeftButton == ButtonState.Pressed && previousState.LeftButton == ButtonState.Released)
        {
            if (leftClickCommand != null)
            {
                leftClickCommand.Execute();
            }
        }

        if (currentState.RightButton == ButtonState.Pressed && previousState.RightButton == ButtonState.Released)
        {
            if (rightClickCommand != null)
            {
                rightClickCommand.Execute();
            }
        }

        previousState = currentState;
    }
}