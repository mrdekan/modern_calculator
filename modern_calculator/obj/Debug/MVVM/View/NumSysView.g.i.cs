﻿#pragma checksum "..\..\..\..\MVVM\View\NumSysView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "523F863FDA52D5C99EBA78EEA12E964964D56FBB61536E32D74F6BFC09AD7D46"
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
using modern_calculator.MVVM.View;


namespace modern_calculator.MVVM.View {
    
    
    /// <summary>
    /// NumSysView
    /// </summary>
    public partial class NumSysView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\MVVM\View\NumSysView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ErrorBorder_NumSys;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\MVVM\View\NumSysView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumSys_input;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\MVVM\View\NumSysView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FromSys_NumSys;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\MVVM\View\NumSysView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ErrorLabel_NumSys;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\MVVM\View\NumSysView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Submit_NumSys;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\MVVM\View\NumSysView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Reverse_NumSys;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\MVVM\View\NumSysView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumSys_output;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\MVVM\View\NumSysView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ToSys_NumSys;
        
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
            System.Uri resourceLocater = new System.Uri("/modern_calculator;component/mvvm/view/numsysview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVM\View\NumSysView.xaml"
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
            this.ErrorBorder_NumSys = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.NumSys_input = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\..\MVVM\View\NumSysView.xaml"
            this.NumSys_input.KeyDown += new System.Windows.Input.KeyEventHandler(this.NumSys_input_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FromSys_NumSys = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.ErrorLabel_NumSys = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Submit_NumSys = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\MVVM\View\NumSysView.xaml"
            this.Submit_NumSys.Click += new System.Windows.RoutedEventHandler(this.Submit_NumSys_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Reverse_NumSys = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\MVVM\View\NumSysView.xaml"
            this.Reverse_NumSys.Click += new System.Windows.RoutedEventHandler(this.Reverse_NumSys_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.NumSys_output = ((System.Windows.Controls.TextBox)(target));
            
            #line 46 "..\..\..\..\MVVM\View\NumSysView.xaml"
            this.NumSys_output.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.NumSys_output_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ToSys_NumSys = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

