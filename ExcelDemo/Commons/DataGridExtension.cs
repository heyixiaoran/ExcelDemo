using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using ExcelDemo.Models;

namespace ExcelDemo.Commons
{
    public class DataGridExtension
    {
        public static ObservableCollection<DataGridColumnConfigModel> GetBindingColumns(DependencyObject obj)
        {
            return (ObservableCollection<DataGridColumnConfigModel>)obj.GetValue(BindingColumnsProperty);
        }

        public static void SetBindingColumns(DependencyObject obj, ObservableCollection<DataGridColumnConfigModel> value)
        {
            obj.SetValue(BindingColumnsProperty, value);
        }

        // Using a DependencyProperty as the backing store for BindingColumns.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BindingColumnsProperty =
            DependencyProperty.RegisterAttached("BindingColumns", typeof(ObservableCollection<DataGridColumnConfigModel>),
                typeof(DataGridExtension), new PropertyMetadata(null, BindingColumnsChanged));

        private static void BindingColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var bindingColumns = e.NewValue as ObservableCollection<DataGridColumnConfigModel>;
            if (bindingColumns != null)
            {
                var dataGrid = d as DataGrid;
                if (dataGrid != null)
                {
                    dataGrid.Columns.Clear();
                    foreach (var bindingColumn in bindingColumns)
                    {
                        var column = new DataGridTextColumn()
                        {
                            Header = bindingColumn.HeaderName,
                            Binding = new Binding(bindingColumn.ColumnName),
                            //Width = new DataGridLength(bindingColumn.Width),
                        };

                        dataGrid.Columns.Add(column);
                    }
                }
            }
        }
    }
}
