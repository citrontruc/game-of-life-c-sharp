/* An object to summarize user inputs */

public class InputHandler
{
    public UserInput GetUserInput()
    {
        UserInput userInput = new();
        // Mouse variables
        userInput.MousePosition = MouseInputHandler.position;
        userInput.LeftClick = MouseInputHandler.isButtonPressed(MouseInputHandler.Button.Left);
        userInput.RightClick = MouseInputHandler.isButtonPressed(MouseInputHandler.Button.Right);

        // Position key variables (hold and release)
        userInput.RightHold = KeyboardInputHandler.Keyboard.IsKeyDown(KeyboardInputHandler.Key.Right);
        userInput.LeftHold = KeyboardInputHandler.Keyboard.IsKeyDown(KeyboardInputHandler.Key.Left);
        userInput.UpHold = KeyboardInputHandler.Keyboard.IsKeyDown(KeyboardInputHandler.Key.Up);
        userInput.DownHold = KeyboardInputHandler.Keyboard.IsKeyDown(KeyboardInputHandler.Key.Down);

        userInput.RightRelease = KeyboardInputHandler.Keyboard.IsKeyReleased(KeyboardInputHandler.Key.Right);
        userInput.LeftRelease = KeyboardInputHandler.Keyboard.IsKeyReleased(KeyboardInputHandler.Key.Left);
        userInput.UpRelease = KeyboardInputHandler.Keyboard.IsKeyReleased(KeyboardInputHandler.Key.Up);
        userInput.DownRelease = KeyboardInputHandler.Keyboard.IsKeyReleased(KeyboardInputHandler.Key.Down);

        // Other keys
        userInput.Input = KeyboardInputHandler.Keyboard.IsKeyReleased(KeyboardInputHandler.Key.Return);
        userInput.Pause = KeyboardInputHandler.Keyboard.IsKeyReleased(KeyboardInputHandler.Key.Space);

        return userInput;
    }

}