﻿#pragma checksum "..\..\..\Windows\howto_wpf_xps_to_png_Window1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D4628799AC486453C18963E4893873F405C060D55B1334CCFA0E681C521AE68E"
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


namespace csharphelper.Windows_Cs {
    
    
    /// <summary>
    /// howto_wpf_xps_to_png_Window1
    /// </summary>
    public partial class howto_wpf_xps_to_png_Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\Windows\howto_wpf_xps_to_png_Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtXpsFile;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Windows\howto_wpf_xps_to_png_Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGo;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Windows\howto_wpf_xps_to_png_Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboScale;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Windows\howto_wpf_xps_to_png_Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabResults;
        
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
            System.Uri resourceLocater = new System.Uri("/csharphelper_WPF;component/windows/howto_wpf_xps_to_png_window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\howto_wpf_xps_to_png_Window1.xaml"
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
            
            #line 6 "..\..\..\Windows\howto_wpf_xps_to_png_Window1.xaml"
            ((csharphelper.Windows_Cs.howto_wpf_xps_to_png_Window1)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtXpsFile = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnGo = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Windows\howto_wpf_xps_to_png_Window1.xaml"
            this.btnGo.Click += new System.Windows.RoutedEventHandler(this.btnGo_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cboScale = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\..\Windows\howto_wpf_xps_to_png_Window1.xaml"
            this.cboScale.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cboScale_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tabResults = ((System.Windows.Controls.TabControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

