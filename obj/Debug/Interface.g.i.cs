﻿#pragma checksum "..\..\Interface.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4585A68FC46B5C44FEF6AC86A0EB8F3C"
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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\Interface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox usernamebox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Interface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox statusbox2;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Interface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button create_button;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Interface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox username_create;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Interface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password_create;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Interface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox secret_create;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Interface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox admin_check;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Interface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox roomidbox;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Interface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Purge_Room;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Interface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Purge_Room_Copy;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\Interface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox roomlist;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\Interface.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock versionbox;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/interface.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Interface.xaml"
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
            this.usernamebox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            
            #line 18 "..\..\Interface.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 20 "..\..\Interface.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 21 "..\..\Interface.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 5:
            this.statusbox2 = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 6:
            this.create_button = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\Interface.xaml"
            this.create_button.Click += new System.Windows.RoutedEventHandler(this.create_click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.username_create = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.password_create = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.secret_create = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 10:
            this.admin_check = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 11:
            this.roomidbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.Purge_Room = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\Interface.xaml"
            this.Purge_Room.Click += new System.Windows.RoutedEventHandler(this.Purge_Button);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Purge_Room_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\Interface.xaml"
            this.Purge_Room_Copy.Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            case 14:
            this.roomlist = ((System.Windows.Controls.ListBox)(target));
            
            #line 53 "..\..\Interface.xaml"
            this.roomlist.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.roomlist_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 15:
            this.versionbox = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

