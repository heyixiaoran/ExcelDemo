using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ExcelDemo.Models
{
    public class MenuItemModel
    {
        public ICommand CommandName { get; set; }
        public string HeaderName { get; set; }
        public Geometry PathData { get; set; }
    }
}
