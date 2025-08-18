/* An object to get all user inputs */

using Raylib_cs;

public static class KeyboardInputHandler
{
    public enum Key
    {
        A = KeyboardKey.A,
        B = KeyboardKey.B,
        C = KeyboardKey.C,
        D = KeyboardKey.D,
        E = KeyboardKey.E,
        F = KeyboardKey.F,
        G = KeyboardKey.G,
        H = KeyboardKey.H,
        I = KeyboardKey.I,
        J = KeyboardKey.J,
        K = KeyboardKey.K,
        L = KeyboardKey.L,
        M = KeyboardKey.M,
        N = KeyboardKey.N,
        O = KeyboardKey.O,
        P = KeyboardKey.P,
        Q = KeyboardKey.Q,
        R = KeyboardKey.R,
        S = KeyboardKey.S,
        T = KeyboardKey.T,
        U = KeyboardKey.U,
        V = KeyboardKey.V,
        W = KeyboardKey.W,
        X = KeyboardKey.X,
        Y = KeyboardKey.Y,
        Z = KeyboardKey.Z,
        Zero = KeyboardKey.Zero,
        One = KeyboardKey.One,
        Two = KeyboardKey.Two,
        Three = KeyboardKey.Three,
        Four = KeyboardKey.Four,
        Five = KeyboardKey.Five,
        Six = KeyboardKey.Six,
        Seven = KeyboardKey.Seven,
        Eight = KeyboardKey.Eight,
        Nine = KeyboardKey.Nine,
        Escape = KeyboardKey.Escape,
        LControl = KeyboardKey.LeftControl,
        LShift = KeyboardKey.LeftShift,
        LAlt = KeyboardKey.LeftAlt,
        RControl = KeyboardKey.RightControl,
        RShift = KeyboardKey.RightShift,
        RAlt = KeyboardKey.RightAlt,
        Menu = KeyboardKey.Menu,
        LBracket = KeyboardKey.LeftBracket,
        RBracket = KeyboardKey.RightBracket,
        SemiColon = KeyboardKey.Semicolon,
        Comma = KeyboardKey.Comma,
        Period = KeyboardKey.Period,
        Slash = KeyboardKey.Slash,
        Backslash = KeyboardKey.Backslash,
        Equal = KeyboardKey.Equal,
        Space = KeyboardKey.Space,
        Return = KeyboardKey.Enter,
        Back = KeyboardKey.Back,
        Backspace = KeyboardKey.Backspace,
        Tab = KeyboardKey.Tab,
        PageUp = KeyboardKey.PageUp,
        PageDown = KeyboardKey.PageDown,
        End = KeyboardKey.End,
        Home = KeyboardKey.Home,
        Insert = KeyboardKey.Insert,
        Delete = KeyboardKey.Delete,
        Add = KeyboardKey.KpAdd,
        Subtract = KeyboardKey.KpSubtract,
        Multiply = KeyboardKey.KpMultiply,
        Divide = KeyboardKey.KpDivide,
        Left = KeyboardKey.Left,
        Right = KeyboardKey.Right,
        Up = KeyboardKey.Up,
        Down = KeyboardKey.Down,
        Kp0 = KeyboardKey.Kp0,
        Kp1 = KeyboardKey.Kp1,
        Kp2 = KeyboardKey.Kp2,
        Kp3 = KeyboardKey.Kp3,
        Kp4 = KeyboardKey.Kp4,
        Kp5 = KeyboardKey.Kp5,
        Kp6 = KeyboardKey.Kp6,
        Kp7 = KeyboardKey.Kp7,
        Kp8 = KeyboardKey.Kp8,
        Kp9 = KeyboardKey.Kp9,
        F1 = KeyboardKey.F1,
        F2 = KeyboardKey.F2,
        F3 = KeyboardKey.F3,
        F4 = KeyboardKey.F4,
        F5 = KeyboardKey.F5,
        F6 = KeyboardKey.F6,
        F7 = KeyboardKey.F7,
        F8 = KeyboardKey.F8,
        F9 = KeyboardKey.F9,
        F10 = KeyboardKey.F10,
        F11 = KeyboardKey.F11,
        F12 = KeyboardKey.F12,
        Pause = KeyboardKey.Pause,
    }

    public static class Keyboard
    {
        public static bool IsKeyDown(Key key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key);
        }

        public static bool IsKeyUp(Key key)
        {
            return Raylib.IsKeyUp((KeyboardKey)key);
        }

        public static bool IsKeyPressed(Key key)
        {
            return Raylib.IsKeyPressed((KeyboardKey)key);
        }

        public static bool IsKeyReleased(Key key)
        {
            return Raylib.IsKeyReleased((KeyboardKey)key);
        }

        public static bool IsKeyPressedRepeat(Key key)
        {
            return Raylib.IsKeyPressedRepeat((KeyboardKey)key);
        }

        public static int GetKeyPressed()
        {
            return Raylib.GetKeyPressed();
        }

        public static int GetCharPressed()
        {
            return Raylib.GetCharPressed();
        }

        public static void SetExitKey(Key key)
        {
            Raylib.SetExitKey((KeyboardKey)key);
        }

    }
}
