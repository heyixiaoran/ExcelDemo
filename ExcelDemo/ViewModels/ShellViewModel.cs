using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using ExcelDemo.Models;
using PropertyChanged;

namespace ExcelDemo.ViewModels
{
    [ImplementPropertyChanged]
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        public ObservableCollection<MenuItemModel> MenuItems { get; set; }
        public ObservableCollection<TreeNode> NodeCollection { get; set; }

        public ObservableCollection<DataGridColumnConfigModel> DataGridColumns { get; set; }

        public ShellViewModel()
        {
            MenuItems = new ObservableCollection<MenuItemModel>()
                {
                    new MenuItemModel() {HeaderName="�½�"}
                };
            LoadTreeNodes();
        }

        private void LoadTreeNodes()
        {
            NodeCollection = new ObservableCollection<TreeNode>()
            {
                new TreeNode(){Id=1,Title="Point 1",ParentId=-1,Level = 1,TreeNodes = new ObservableCollection<TreeNode>() {new TreeNode() {Id=11,Title = "Point 1.1",ParentId = 1,Level = 2} } },
                new TreeNode(){Id=2,Title="Point 2",ParentId=-1,Level = 1,TreeNodes = new ObservableCollection<TreeNode>() {new TreeNode() {Id=11,Title = "Point 2.1",ParentId = 2,Level = 2} } },
            };
        }

        public void AddNode()
        {
            var widgetViewModel = IoC.Get<AddNodeViewModel>();
            IoC.Get<IWindowManager>().ShowDialog(widgetViewModel);
        }

        public void AddTreeNode()
        {
            var a = NodeCollection.FirstOrDefault(t => t.Id == 1).TreeNodes;
            a.Add(new TreeNode() { Id = 12, Title = "Point 1.2", ParentId = 1, Level = 2 });
        }

        public void TreeNodeSelectedChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var treeNode = sender as TreeNode;
            if (treeNode.Level == 1)
            {
                DataGridColumns = new ObservableCollection<DataGridColumnConfigModel>()
                {
                    new DataGridColumnConfigModel() { HeaderName = "���"},
                    new DataGridColumnConfigModel() { HeaderName = "����"},
                    new DataGridColumnConfigModel() { HeaderName = "����Դ����"},
                    new DataGridColumnConfigModel() { HeaderName = "Զ�̷�����"},
                    new DataGridColumnConfigModel() { HeaderName = "���ݿ�"}
                };
            }
            else
            {
                DataGridColumns = new ObservableCollection<DataGridColumnConfigModel>()
                {
                    new DataGridColumnConfigModel() { HeaderName = "����"},
                    new DataGridColumnConfigModel() { HeaderName = "���"},
                    new DataGridColumnConfigModel() { HeaderName = "Schema"},
                    new DataGridColumnConfigModel() { HeaderName = "��ע��"},
                    new DataGridColumnConfigModel() { HeaderName = "����"}
                };
            }
        }
    }
}