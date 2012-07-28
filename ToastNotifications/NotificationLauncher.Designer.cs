namespace ToastNotifications
{
    partial class NotificationLauncher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelBody = new System.Windows.Forms.Label();
            this.textBoxBody = new System.Windows.Forms.TextBox();
            this.labelDuration = new System.Windows.Forms.Label();
            this.comboBoxDuration = new System.Windows.Forms.ComboBox();
            this.labelAnimation = new System.Windows.Forms.Label();
            this.comboBoxAnimation = new System.Windows.Forms.ComboBox();
            this.comboBoxAnimationDirection = new System.Windows.Forms.ComboBox();
            this.labelAnimationDirection = new System.Windows.Forms.Label();
            this.buttonShowNotification = new System.Windows.Forms.Button();
            this.comboBoxSound = new System.Windows.Forms.ComboBox();
            this.labelSound = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(13, 19);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(32, 13);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(89, 16);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(191, 20);
            this.textBoxTitle.TabIndex = 1;
            this.textBoxTitle.Text = "My Notification";
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBody.Location = new System.Drawing.Point(13, 56);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(35, 13);
            this.labelBody.TabIndex = 2;
            this.labelBody.Text = "Body";
            // 
            // textBoxBody
            // 
            this.textBoxBody.Location = new System.Drawing.Point(89, 53);
            this.textBoxBody.Multiline = true;
            this.textBoxBody.Name = "textBoxBody";
            this.textBoxBody.Size = new System.Drawing.Size(191, 51);
            this.textBoxBody.TabIndex = 3;
            this.textBoxBody.Text = "My notification message goes here";
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDuration.Location = new System.Drawing.Point(13, 128);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(55, 13);
            this.labelDuration.TabIndex = 4;
            this.labelDuration.Text = "Duration";
            // 
            // comboBoxDuration
            // 
            this.comboBoxDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDuration.FormattingEnabled = true;
            this.comboBoxDuration.Items.AddRange(new object[] {
            "sticky (click to dismiss)",
            "1",
            "3",
            "5",
            "10"});
            this.comboBoxDuration.Location = new System.Drawing.Point(89, 128);
            this.comboBoxDuration.Name = "comboBoxDuration";
            this.comboBoxDuration.Size = new System.Drawing.Size(191, 21);
            this.comboBoxDuration.TabIndex = 5;
            // 
            // labelAnimation
            // 
            this.labelAnimation.AutoSize = true;
            this.labelAnimation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnimation.Location = new System.Drawing.Point(14, 158);
            this.labelAnimation.Name = "labelAnimation";
            this.labelAnimation.Size = new System.Drawing.Size(62, 13);
            this.labelAnimation.TabIndex = 6;
            this.labelAnimation.Text = "Animation";
            // 
            // comboBoxAnimation
            // 
            this.comboBoxAnimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnimation.FormattingEnabled = true;
            this.comboBoxAnimation.Location = new System.Drawing.Point(89, 155);
            this.comboBoxAnimation.Name = "comboBoxAnimation";
            this.comboBoxAnimation.Size = new System.Drawing.Size(191, 21);
            this.comboBoxAnimation.TabIndex = 7;
            // 
            // comboBoxAnimationDirection
            // 
            this.comboBoxAnimationDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnimationDirection.FormattingEnabled = true;
            this.comboBoxAnimationDirection.Location = new System.Drawing.Point(89, 182);
            this.comboBoxAnimationDirection.Name = "comboBoxAnimationDirection";
            this.comboBoxAnimationDirection.Size = new System.Drawing.Size(191, 21);
            this.comboBoxAnimationDirection.TabIndex = 9;
            // 
            // labelAnimationDirection
            // 
            this.labelAnimationDirection.AutoSize = true;
            this.labelAnimationDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnimationDirection.Location = new System.Drawing.Point(13, 185);
            this.labelAnimationDirection.Name = "labelAnimationDirection";
            this.labelAnimationDirection.Size = new System.Drawing.Size(58, 13);
            this.labelAnimationDirection.TabIndex = 8;
            this.labelAnimationDirection.Text = "Direction";
            // 
            // buttonShowNotification
            // 
            this.buttonShowNotification.Location = new System.Drawing.Point(89, 262);
            this.buttonShowNotification.Name = "buttonShowNotification";
            this.buttonShowNotification.Size = new System.Drawing.Size(105, 23);
            this.buttonShowNotification.TabIndex = 10;
            this.buttonShowNotification.Text = "Show Notification";
            this.buttonShowNotification.UseVisualStyleBackColor = true;
            this.buttonShowNotification.Click += new System.EventHandler(this.buttonShowNotification_Click);
            // 
            // comboBoxSound
            // 
            this.comboBoxSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSound.FormattingEnabled = true;
            this.comboBoxSound.Location = new System.Drawing.Point(89, 211);
            this.comboBoxSound.Name = "comboBoxSound";
            this.comboBoxSound.Size = new System.Drawing.Size(191, 21);
            this.comboBoxSound.TabIndex = 12;
            this.comboBoxSound.SelectedIndexChanged += new System.EventHandler(this.comboBoxSound_SelectedIndexChanged);
            // 
            // labelSound
            // 
            this.labelSound.AutoSize = true;
            this.labelSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSound.Location = new System.Drawing.Point(13, 214);
            this.labelSound.Name = "labelSound";
            this.labelSound.Size = new System.Drawing.Size(43, 13);
            this.labelSound.TabIndex = 11;
            this.labelSound.Text = "Sound";
            // 
            // NotificationLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 297);
            this.Controls.Add(this.comboBoxSound);
            this.Controls.Add(this.labelSound);
            this.Controls.Add(this.buttonShowNotification);
            this.Controls.Add(this.comboBoxAnimationDirection);
            this.Controls.Add(this.labelAnimationDirection);
            this.Controls.Add(this.comboBoxAnimation);
            this.Controls.Add(this.labelAnimation);
            this.Controls.Add(this.comboBoxDuration);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.textBoxBody);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelTitle);
            this.Name = "NotificationLauncher";
            this.Text = "Toast Notification Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.TextBox textBoxBody;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.ComboBox comboBoxDuration;
        private System.Windows.Forms.Label labelAnimation;
        private System.Windows.Forms.ComboBox comboBoxAnimation;
        private System.Windows.Forms.ComboBox comboBoxAnimationDirection;
        private System.Windows.Forms.Label labelAnimationDirection;
        private System.Windows.Forms.Button buttonShowNotification;
        private System.Windows.Forms.ComboBox comboBoxSound;
        private System.Windows.Forms.Label labelSound;
    }
}