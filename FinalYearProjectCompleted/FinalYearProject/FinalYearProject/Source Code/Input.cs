using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FinalYearProject
{
    class Input
    {
        //VARIABLES:************************************************
        //Variable for mouse coordinates
        public Vector2 mousePosition;

        // Keyboard states used to determine key presses
        public KeyboardState currentKeyboardState;
        public KeyboardState previousKeyboardState;

        //mouse state
        public MouseState currentMouseState;
        public MouseState previousMouseState;
        //**********************************************************

        public void UpdateMouseAndDirectionRotation(Player player1, Animation playerAnimation)
        {
            MouseState mouse = Mouse.GetState();
            mousePosition = new Vector2(mouse.X, mouse.Y);

            // You can see how much cleaner it is compared to last time.
            playerAnimation.Direction = player1.GetDirection(playerAnimation.Position, mousePosition);
            playerAnimation.Rotation = player1.GetRotation(playerAnimation.Direction);
        }


        public void UpdateKeyboard()
        {
            //Save the previous state of the keyboard so we can derermine single key / button presses
            previousKeyboardState = currentKeyboardState;
            previousMouseState = currentMouseState;

            // Read the current state of the keyboard and store it
            currentKeyboardState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();
        }

    }
}
