using Notifications;
using System;

namespace ToastNotificationConsole
{
    class Program
    {
        //[STAThread]
        static void Main(string[] args)
        {
            new Notification("title", "body", 5000, FormAnimator.AnimationMethod.Fade,
                  FormAnimator.AnimationDirection.Up).ShowFromManager();

            new Notification("title", "body", 5000, FormAnimator.AnimationMethod.Fade,
                FormAnimator.AnimationDirection.Up).ShowFromManager();

            Console.ReadKey();

        }
    }

}
