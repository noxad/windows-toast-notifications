// =====COPYRIGHT=====
// Code originally retrieved from http://www.vbforums.com/showthread.php?t=547778 - no license information supplied
// =====COPYRIGHT=====

using Notifications.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Notifications
{
    public partial class Notification : Form
    {
        public event EventHandler<NotificationClickedEventArgs> OnNotificationClicked;
        static readonly List<Notification> OpenNotifications = new List<Notification>();
        bool _allowFocus;
        readonly FormAnimator _animator;
        IntPtr _currentForegroundWindow;
        static readonly Font SmallFont = new Font("Calibri", 8, FontStyle.Regular, GraphicsUnit.Point, 0);
        static readonly Font DefaultFont = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="body"></param>
        /// <param name="duration"></param>
        /// <param name="animation"></param>
        /// <param name="direction"></param>
        public Notification(string title, string body, int duration, FormAnimator.AnimationMethod animation, FormAnimator.AnimationDirection direction)
        {
            InitializeComponent();

            if (duration < 0)
                duration = int.MaxValue;
            else
                duration = duration * 1000;

            lifeTimer.Interval = duration;
            labelTitle.Text = title;
            if (body.Length > 100)
                labelBody.Font = SmallFont;
            labelBody.Text = body;


            _animator = new FormAnimator(this, animation, direction, 500);

            Region = Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width - 5, Height - 5, 20, 20));
        }

        #region Methods

        /// <summary>
        /// Displays the form
        /// </summary>
        /// <remarks>
        /// Required to allow the form to determine the current foreground window before being displayed
        /// </remarks>
        public new void Show()
        {
            // Determine the current foreground window so it can be reactivated each time this form tries to get the focus
            _currentForegroundWindow = NativeMethods.GetForegroundWindow();

            base.Show();
        }

        #endregion // Methods

        #region Event Handlers

        void Notification_Load(object sender, EventArgs e)
        {
            // Display the form just above the system tray.
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width,
                                      Screen.PrimaryScreen.WorkingArea.Height - Height);

            // Move each open form upwards to make room for this one
            foreach (Notification openForm in OpenNotifications)
            {
                openForm.SetPropertyThreadSafe(() => openForm.Top, openForm.Top - Height);
                /* Notice! The line below changed by me (aleksandresukhitashvili@gmail.com)
                 *  with the line above because it threw 
                 *  an exception when I created another 
                 *  notification from different thread
                 */
                //openForm.Top -= Height;
            }

            OpenNotifications.Add(this);
            lifeTimer.Start();
        }

        void Notification_Activated(object sender, EventArgs e)
        {
            // Prevent the form taking focus when it is initially shown
            if (!_allowFocus)
            {
                // Activate the window that previously had focus
                NativeMethods.SetForegroundWindow(_currentForegroundWindow);
            }
        }

        void Notification_Shown(object sender, EventArgs e)
        {
            // Once the animation has completed the form can receive focus
            _allowFocus = true;

            // Close the form by sliding down.
            _animator.Duration = 0;
            _animator.Direction = FormAnimator.AnimationDirection.Down;
        }

        void Notification_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Move down any open forms above this one
            foreach (Notification openForm in OpenNotifications)
            {
                if (openForm == this)
                {
                    // Remaining forms are below this one
                    break;
                }
                openForm.Top += Height;
            }

            OpenNotifications.Remove(this);
        }

        void lifeTimer_Tick(object sender, EventArgs e)
        {
            Close();
        }

        void Notification_Click(object sender, EventArgs e)
        {
            Close();
        }

        void labelTitle_Click(object sender, EventArgs e)
        {
            InvokeClicked();
            Close();
        }

        void labelRO_Click(object sender, EventArgs e)
        {
            InvokeClicked();
            Close();
        }

        void InvokeClicked()
        {
            OnNotificationClicked?.Invoke(this,
                new NotificationClickedEventArgs()
                {
                    Content = new NotificationContentStruct() { Body = this.labelBody.Text, Title = this.labelTitle.Text }
                });
        }

        #endregion // Event Handlers
    }

    public class NotificationClickedEventArgs : EventArgs
    {
        public NotificationContentStruct Content { get; set; }
    }

    public class NotificationContentStruct
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }
}