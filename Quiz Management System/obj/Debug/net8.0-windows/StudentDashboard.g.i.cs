﻿#pragma checksum "..\..\..\StudentDashboard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "206F4439E0F8A6FD8CB4BA31C237C772C2A8C824"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Quiz_Management_System;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Quiz_Management_System {
    
    
    /// <summary>
    /// StudentDashboard
    /// </summary>
    public partial class StudentDashboard : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\StudentDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button min_bttn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\StudentDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button max_bttn;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\StudentDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close_bttn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Quiz Management System;V1.0.0.0;component/studentdashboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\StudentDashboard.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.min_bttn = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\StudentDashboard.xaml"
            this.min_bttn.Click += new System.Windows.RoutedEventHandler(this.min_bttn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.max_bttn = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\StudentDashboard.xaml"
            this.max_bttn.Click += new System.Windows.RoutedEventHandler(this.max_bttn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Close_bttn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\StudentDashboard.xaml"
            this.Close_bttn.Click += new System.Windows.RoutedEventHandler(this.Close_bttn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

