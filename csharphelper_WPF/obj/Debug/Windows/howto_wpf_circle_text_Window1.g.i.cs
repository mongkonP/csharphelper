﻿#pragma checksum "..\..\..\Windows\howto_wpf_circle_text_Window1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E77AE15EC0218A29C4CA80043ACDC5BDC407A245CDA3F1ECEE3B3E5024A6A3DA"
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
    /// howto_wpf_circle_text_Window1
    /// </summary>
    public partial class howto_wpf_circle_text_Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Windows\howto_wpf_circle_text_Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblZoom;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Windows\howto_wpf_circle_text_Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliZoom;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Windows\howto_wpf_circle_text_Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scvGraph;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Windows\howto_wpf_circle_text_Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canGraph;
        
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
            System.Uri resourceLocater = new System.Uri("/csharphelper_WPF;component/windows/howto_wpf_circle_text_window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\howto_wpf_circle_text_Window1.xaml"
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
            
            #line 6 "..\..\..\Windows\howto_wpf_circle_text_Window1.xaml"
            ((csharphelper.Windows_Cs.howto_wpf_circle_text_Window1)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblZoom = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.sliZoom = ((System.Windows.Controls.Slider)(target));
            
            #line 22 "..\..\..\Windows\howto_wpf_circle_text_Window1.xaml"
            this.sliZoom.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.sliZoom_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.scvGraph = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 5:
            this.canGraph = ((System.Windows.Controls.Canvas)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

