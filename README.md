Windows Toast Notifications
========================

C# demo project for easily creating toast-style notifications in a Windows application. 

Original modified and cleaned up version of code mentioned in Attribution section below was for use in [EDGE Shop Flag Notifier](http://www.mpiworldclass.com/customer-center/beta-widgets.aspx).

Features
---------------------

* **Toast-Style Notifications**
	* Notifications that pop up near the system tray
* **Notification Animations**
	* 4 different ways that a notification can appear (slide, fade, roll, center) and from 4 different directions (up, down, left, right)
* **Custom Duration**
	* Notifications can be sticky (click to dismiss) or can disappear based on the defined lifetime
* **Sounds**
	* Easy to add sounds to the notifications

Demo
---------------------

Simply build and run the solution. Demo notification launcher allows you to test out the different customizations available.

How to Use
---------------------

1. Add the following class files to your project:
	- FormAnimator.cs
	- NativeMethods.cs
2. Add the Notifications form files to your project:
	- Notification.cs
	- Notification.designer.cs
	- Notification.resx
3. Customize the appearance of the Notification form
	- Size, color, background (demo uses an image for the background)
4. Create a toast notification form object in your project's code and call Show() to display it

    ```csharp
    Notification toastNotification = new Notification(title, body, duration, animationMethod, animationDirection);
    toastNotification.Show();
    ```

Attribution
---------------------

Core code originally retrieved from URL below. No license information supplied. 
* http://www.vbforums.com/showthread.php?t=547778
