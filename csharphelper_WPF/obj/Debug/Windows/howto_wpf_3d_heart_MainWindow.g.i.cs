﻿#pragma checksum "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "74742F9BA0B4470DAFDF9C0AFDEBAA9D53E36C610D17862C8BEFA144CE6C1525"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using howto_wpf_3d_heart;


namespace csharphelper.Windows_Cs {
    
    
    /// <summary>
    /// howto_wpf_3d_heart_MainWindow
    /// </summary>
    public partial class howto_wpf_3d_heart_MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkAxes;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDistance;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReset;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borViewport;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewport3D MainViewport;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/csharphelper_WPF;component/windows/howto_wpf_3d_heart_mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml"
            ((csharphelper.Windows_Cs.howto_wpf_3d_heart_MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.chkAxes = ((System.Windows.Controls.CheckBox)(target));
            
            #line 39 "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml"
            this.chkAxes.Click += new System.Windows.RoutedEventHandler(this.chkItem_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblDistance = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btnReset = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml"
            this.btnReset.Click += new System.Windows.RoutedEventHandler(this.btnReset_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.borViewport = ((System.Windows.Controls.Border)(target));
            
            #line 62 "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml"
            this.borViewport.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MainViewport_MouseDown);
            
            #line default
            #line hidden
            
            #line 64 "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml"
            this.borViewport.ManipulationStarting += new System.EventHandler<System.Windows.Input.ManipulationStartingEventArgs>(this.Border_ManipulationStarting);
            
            #line default
            #line hidden
            
            #line 65 "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml"
            this.borViewport.ManipulationDelta += new System.EventHandler<System.Windows.Input.ManipulationDeltaEventArgs>(this.Border_ManipulationDelta);
            
            #line default
            #line hidden
            
            #line 66 "..\..\..\Windows\howto_wpf_3d_heart_MainWindow.xaml"
            this.borViewport.ManipulationInertiaStarting += new System.EventHandler<System.Windows.Input.ManipulationInertiaStartingEventArgs>(this.Border_ManipulationInertiaStarting);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MainViewport = ((System.Windows.Controls.Viewport3D)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
