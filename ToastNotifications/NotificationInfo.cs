// =====COPYRIGHT=====
// Copyright 2007 - 2011 Service Repair Solutions, Inc.
// =====COPYRIGHT=====
using System.Drawing;

namespace Mpi.Edge.ShopFlagNotifier
{
    public class NotificationInfo
    {
        public string Title { get; set; }
        public string RoInfo { get; set; }
        public string Updated { get; set; }
        public Image Icon { get; set; }
        public Color Color { get; set; }
        public int Duration { get; set; }

        public NotificationInfo(string title, string roInfo, string updated, Image icon, Color color, int duration)
        {
            this.Title = title;
            this.RoInfo = roInfo;
            this.Updated = updated;
            this.Icon = icon;
            this.Color = color;
            this.Duration = duration;
        }

        public NotificationInfo()
        {
        }
    }
}
