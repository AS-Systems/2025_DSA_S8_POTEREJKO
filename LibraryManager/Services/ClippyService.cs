using System;
using System.Windows.Controls;
using System.Windows.Media;
using Wpf.Clippy;
using Wpf.Clippy.Types;

namespace LibraryManager.Services
{
    public static class ClippyService
    {
        private static ClippyCharacter character;
        private static bool isVisible = false;

        public static void Initialize()
        {
            if (character == null)
            {
                character = new ClippyCharacter(Character.Clippy);
                character.Show();
                character.PlayAnimation("Idle1_1", AnimationMode.Loop);
                isVisible = true;
            }
        }

        public static bool IsVisible => isVisible;

        public static void ToggleVisibility()
        {
            if (character == null)
            {
                Initialize();
            }
            else
            {
                if (isVisible)
                {
                    character.Close();
                    isVisible = false;
                }
                else
                {
                    character.Show();
                    isVisible = true;
                }
            }
        }

        public static void SayLoginInstructions()
        {
            if (character == null)
            {
                Initialize();
            }

        character.Say(new TextBlock 
        { 
            Text = "Insert your username and password. Click the login button after input. If you don't have an account, click the register button.", 
            Foreground = Brushes.Black 
        });
        }

    }
}
