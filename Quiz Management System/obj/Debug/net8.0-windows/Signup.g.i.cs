﻿#pragma checksum "..\..\..\Signup.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7CA0A8F790D6B109228F40E0E1B2D46F69A90E8B"
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
    /// Signup
    /// </summary>
    public partial class Signup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button login_bttn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close_bttn;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock id_lbl;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox user_id_tb;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock name_lbl;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox username_tb;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock pass_lbl;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pass_tb;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock confirm_pass_lbl;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox confirm_pass_tb;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Signup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sign_up_bttn;
        
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
            System.Uri resourceLocater = new System.Uri("/Quiz Management System;V1.0.0.0;component/signup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Signup.xaml"
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
            
            #line 9 "..\..\..\Signup.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.login_bttn = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\Signup.xaml"
            this.login_bttn.MouseEnter += new System.Windows.Input.MouseEventHandler(this.login_bttn_MouseEnter);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\Signup.xaml"
            this.login_bttn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.login_bttn_MouseLeave);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\Signup.xaml"
            this.login_bttn.Click += new System.Windows.RoutedEventHandler(this.login_bttn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Close_bttn = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Signup.xaml"
            this.Close_bttn.Click += new System.Windows.RoutedEventHandler(this.Close_bttn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.id_lbl = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.user_id_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.name_lbl = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.username_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.pass_lbl = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.pass_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.confirm_pass_lbl = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.confirm_pass_tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.sign_up_bttn = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\Signup.xaml"
            this.sign_up_bttn.MouseEnter += new System.Windows.Input.MouseEventHandler(this.sign_up_bttn_MouseEnter);
            
            #line default
            #line hidden
            
            #line 60 "..\..\..\Signup.xaml"
            this.sign_up_bttn.MouseLeave += new System.Windows.Input.MouseEventHandler(this.sign_up_bttn_MouseLeave);
            
            #line default
            #line hidden
            
            #line 60 "..\..\..\Signup.xaml"
            this.sign_up_bttn.Click += new System.Windows.RoutedEventHandler(this.sign_up_bttn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

