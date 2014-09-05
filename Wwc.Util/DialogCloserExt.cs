using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Wwc.Util
{
    /// <summary>
    /// A UI extension to close a dialog.
    /// It works because if a dialog is opened using the showDialog() method,
    /// the dialog is closed when its DialogResult property is set.
    /// This extension helps to set that property from the ViewModel.
    /// 
    /// USAGE:
    /// View
    /// -----
    ///     &lt;Window ...
    ///         xmlns:ui="clr-namespace:Wwc.Util"
    ///         ui:DialogCloserExt.DialogResult="{Binding DialogResult}"
    ///         
    /// ViewModel
    /// -----
    ///     Add a property for DialogResult, and, invoke OnPropertyChanged() when set
    ///     
    /// </summary>
    public static class DialogCloserExt
    {
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.RegisterAttached(
                "DialogResult",
                typeof(bool?),
                typeof(DialogCloserExt),
                new PropertyMetadata(DialogResultChanged));

        private static void DialogResultChanged(
            DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window != null) window.DialogResult = e.NewValue as bool?;
        }

        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }
    }
}
