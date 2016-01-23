using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace ExcelDemo.Models
{
    [ImplementPropertyChanged]
    public class TreeNode
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public int Level { get; set; }
        public ObservableCollection<TreeNode> TreeNodes { get; set; }
    }
}
