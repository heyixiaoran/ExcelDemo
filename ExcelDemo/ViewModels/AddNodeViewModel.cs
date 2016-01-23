using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using PropertyChanged;

namespace ExcelDemo.ViewModels
{
    [ImplementPropertyChanged]
    public class AddNodeViewModel : Screen
    {
        public ObservableCollection<string> DataSourceTypes { get; set; }
        public Visibility SqlServerVisibility { get; set; }
        public Visibility OracleVisibility { get; set; }

        public AddNodeViewModel()
        {
            InitDataSourceTypes();
            SqlServerVisibility = Visibility.Visible;
            OracleVisibility = Visibility.Collapsed;
        }

        private void InitDataSourceTypes()
        {
            DataSourceTypes = new ObservableCollection<string>()
            {
                "Sql Server",
                "Oracle"
            };
        }

        public void DataSourceTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataSourceType = sender as string;
            if (dataSourceType == "Sql Server")
            {
                SqlServerVisibility = Visibility.Visible;
                OracleVisibility = Visibility.Collapsed;
            }
            else
            {
                SqlServerVisibility = Visibility.Collapsed;
                OracleVisibility = Visibility.Visible;
            }
        }

        public void OkButtonClick()
        {
            TryClose();
        }

        public void CancelButtonClick()
        {
            TryClose();
        }
    }
}
