using System;
using System.IO;
using System.Windows.Forms;

namespace ToastNotifications
{
    public partial class NotificationLauncher : Form
    {
        private bool _initialLoad = true;

        public NotificationLauncher()
        {
            InitializeComponent();
            PopulateComboBoxes();
        }

        private void PopulateComboBoxes()
        {
            foreach (FormAnimator.AnimationMethod method in Enum.GetValues(typeof(FormAnimator.AnimationMethod)))
            {
                comboBoxAnimation.Items.Add(method.ToString());
            }
            comboBoxAnimation.SelectedIndex = 2;

            foreach (FormAnimator.AnimationDirection direction in Enum.GetValues(typeof(FormAnimator.AnimationDirection)))
            {
                comboBoxAnimationDirection.Items.Add(direction.ToString());
            }
            comboBoxAnimationDirection.SelectedIndex = 3;

            DirectoryInfo soundsFolder = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds"));
            foreach (FileInfo file in soundsFolder.GetFiles())
            {
                comboBoxSound.Items.Add(Path.GetFileNameWithoutExtension(file.FullName));
            }
            comboBoxSound.SelectedIndex = 5;
            _initialLoad = false;

            comboBoxDuration.SelectedIndex = 0;
        }

        private void ShowNotification()
        {
            int duration;
            int.TryParse(comboBoxDuration.SelectedItem.ToString(), out duration);
            if (duration <= 0)
            {
                duration = -1;
            }

            FormAnimator.AnimationMethod animationMethod = FormAnimator.AnimationMethod.Slide;
            foreach (FormAnimator.AnimationMethod method in Enum.GetValues(typeof(FormAnimator.AnimationMethod)))
            {
                if (string.Equals(method.ToString(), comboBoxAnimation.SelectedItem))
                {
                    animationMethod = method;
                    break;
                }
            }

            FormAnimator.AnimationDirection animationDirection = FormAnimator.AnimationDirection.Up;
            foreach (FormAnimator.AnimationDirection direction in Enum.GetValues(typeof(FormAnimator.AnimationDirection)))
            {
                if (string.Equals(direction.ToString(), comboBoxAnimationDirection.SelectedItem))
                {
                    animationDirection = direction;
                    break;
                }
            }

            Notification toastNotification = new Notification(textBoxTitle.Text, textBoxBody.Text, duration, animationMethod, animationDirection);
            PlayNotificationSound(comboBoxSound.Text);
            toastNotification.Show();
        }

        private void buttonShowNotification_Click(object sender, EventArgs e)
        {
            ShowNotification();
        }

        private static void PlayNotificationSound(string sound)
        {
            string soundsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds");
            string soundFile = Path.Combine(soundsFolder, sound + ".wav");

            using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundFile))
            {
                player.Play();
            }
        }

        private void comboBoxSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                PlayNotificationSound(comboBoxSound.Text);
            }
        }
    }
}
