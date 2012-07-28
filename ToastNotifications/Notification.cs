// =====COPYRIGHT=====
// Code originally retrieved from http://www.vbforums.com/showthread.php?t=547778 - no license information supplied
// =====COPYRIGHT=====
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ToastNotifications
{
    public partial class Notification : Form
    {
        private static List<Notification> openNotifications = new List<Notification>();
        private bool allowFocus = false;
        private FormAnimator animator;
        private IntPtr currentForegroundWindow;

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

            this.lifeTimer.Interval = duration;
            this.labelTitle.Text = title;
            this.labelBody.Text = body;

            this.animator = new FormAnimator(this, animation, direction, 500);

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
            this.currentForegroundWindow = NativeMethods.GetForegroundWindow();

            base.Show();
        }

        #endregion // Methods

        #region Event Handlers

        private void Notification_Load(object sender, EventArgs e)
        {
            // Display the form just above the system tray.
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width,
                                      Screen.PrimaryScreen.WorkingArea.Height - this.Height);

            // Move each open form upwards to make room for this one
            foreach (Notification openForm in Notification.openNotifications)
            {
                openForm.Top -= this.Height;
            }

            Notification.openNotifications.Add(this);
            this.lifeTimer.Start();
        }

        private void Notification_Activated(object sender, EventArgs e)
        {
            // Prevent the form taking focus when it is initially shown
            if (!this.allowFocus)
            {
                // Activate the window that previously had focus
                NativeMethods.SetForegroundWindow(this.currentForegroundWindow);
            }
        }

        private void Notification_Shown(object sender, EventArgs e)
        {
            // Once the animation has completed the form can receive focus
            this.allowFocus = true;

            // Close the form by sliding down.
            this.animator.Duration = 0;
            this.animator.Direction = FormAnimator.AnimationDirection.Down;
        }

        private void Notification_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Move down any open forms above this one
            foreach (Notification openForm in Notification.openNotifications)
            {
                if (openForm == this)
                {
                    // Remaining forms are below this one
                    break;
                }
                openForm.Top += this.Height;
            }

            Notification.openNotifications.Remove(this);
        }

        private void lifeTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Notification_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void messageIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelRO_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelUpdated_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelIconBackground_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion // Event Handlers
    }
}