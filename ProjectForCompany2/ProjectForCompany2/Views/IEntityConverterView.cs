using ProjectForCompany2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForCompany2.Views
{
    public interface IEntityConverterView
    {
        IEnumerable<Entity> Entities { get; set; }
        string FileType { get; set; }

        Presenter.EntityConverterPresenter Presenter { set; }
    }
}
