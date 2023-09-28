﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;

// See: http://blakenui.codeplex.com/SourceControl/latest#Blake.NUI.WPF/Touch/MouseTouchDevice.cs

namespace howto_wpf_3d_heart
{
    public class MouseTouchDevice : TouchDevice
    {
        #region Class Members

        private static MouseTouchDevice device;

        public Point Position { get; set; }

        #endregion

        #region Public Static Methods

        public static void RegisterEvents(FrameworkElement root)
        {
            root.PreviewMouseDown += MouseDown;
            root.PreviewMouseMove += MouseMove;
            root.PreviewMouseUp += MouseUp;
        }

        #endregion

        #region Private Static Methods

        private static void MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (device != null &&
                device.IsActive)
            {
                device.ReportUp();
                device.Deactivate();
                device = null;
            }
            device = new MouseTouchDevice(e.MouseDevice.GetHashCode());
            device.SetActiveSource(e.MouseDevice.ActiveSource);
            device.Position = e.GetPosition(null);
            device.Activate();
            device.ReportDown();
            e.Handled = true;
        }

        private static void MouseMove(object sender, MouseEventArgs e)
        {
            if (device != null &&
                device.IsActive)
            {
                device.Position = e.GetPosition(null);
                device.ReportMove();
                e.Handled = true;
            }
        }

        private static void MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (device != null &&
                device.IsActive)
            {
                device.Position = e.GetPosition(null);
                device.ReportUp();
                device.Deactivate();
                device = null;
                e.Handled = true;
            }
        }

        #endregion

        #region Constructors

        public MouseTouchDevice(int deviceId) :
            base(deviceId)
        {
            Position = new Point();
        }

        #endregion

        #region Overridden methods

        public override TouchPointCollection GetIntermediateTouchPoints(IInputElement relativeTo)
        {
            return new TouchPointCollection();
        }

        public override TouchPoint GetTouchPoint(IInputElement relativeTo)
        {
            Point point = Position;
            if (relativeTo != null)
            {
                point = this.ActiveSource.RootVisual.TransformToDescendant((Visual)relativeTo).Transform(Position);
            }

            Rect rect = new Rect(point, new Size(1, 1));

            return new TouchPoint(this, point, rect, TouchAction.Move);
        }

        #endregion

    }
}