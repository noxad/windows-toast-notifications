using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Notifications
{
    public class NotificationManager
    {
        static bool _activated;
        static readonly object Locker = new object();
        public static bool Activated
        {
            get { lock (Locker) return _activated; }
            set { lock (Locker) _activated = value; }
        }
        static NotificationManagerForm _mainForm;

        public static NotificationManagerForm MainForm
        {
            get { lock (Locker) return _mainForm; }
            set { lock (Locker) _mainForm = value; }
        }

        public static void Activate()
        {
            if (Activated) return;
            var thread = new Thread(() => StartInternal());
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = false;
            thread.Start();
            Activated = true;
        }

        public static void Show(Notification notification)
        {
            lock (Locker)
            {
                if (!_activated)
                {
                    Activate();
                    Monitor.Pulse(Locker);
                    Monitor.Wait(Locker);
                }

                MainForm.MakeVisible(notification);
            }
        }


        [STAThread]
        static void StartInternal()
        {
            lock (Locker)
            {
                MainForm = new NotificationManagerForm()
                { Visible = false };
                Monitor.Pulse(Locker);
            }
            Application.Run();
        }
    }

    public class NotificationManagerForm : Form
    {
        readonly Queue<Notification> ToShow = new Queue<Notification>();
        readonly System.Windows.Forms.Timer timer;
        public NotificationManagerForm()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += (sender, args) =>
            {
                lock (ToShow)
                {
                    while (ToShow.Count > 0)
                    {
                        Notification current;
                        try
                        {
                            current = ToShow.Dequeue();
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }

                        if (!current.IsDisposed)
                            current.Show();
                    }
                }
            };
            timer.Enabled = true;
        }
        public void MakeVisible(Notification notification)
        {
            lock (ToShow)
                ToShow.Enqueue(notification);
        }
    }

    public class NotificationToShowEventArgs : EventArgs
    {
        public Notification Notification { get; set; }
    }
}