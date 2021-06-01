using System.Collections.Generic;
using System.Web.Mvc;

namespace cmsCore.Library.Services
{
    public interface IDataTypeValueService
    {
        IEnumerable<SelectListItem> GetItemsFromValueListDataType(string dataTypeName,
            string[] selectedValues);
    }
}
