using Notifications;
using System;
using System.Threading;

namespace ToastNotificationConsole
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //var thread = new Thread(() =>
            //{
            //    System.Windows.Forms.Application.Run(new Notification("title", "body", 5000, FormAnimator.AnimationMethod.Fade,
            //         FormAnimator.AnimationDirection.Up));
            //    //Thread.Sleep(5000);
            //})
            //{ IsBackground = false };
            //thread.SetApartmentState(ApartmentState.STA);
            //thread.Start();
            new Notification("title", "body", 5000, FormAnimator.AnimationMethod.Fade,
                FormAnimator.AnimationDirection.Up).ShowInNewThread();
            Console.ReadKey();

        }
    }
}
