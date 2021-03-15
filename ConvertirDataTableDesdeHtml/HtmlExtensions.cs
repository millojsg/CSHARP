using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ConvertirDataTableDesdeHtml
{
    public static class HtmlExtensions
        {
            public static IEnumerable<HtmlElement> GetByTagName(this HtmlElement element, string TagName)
            {
                return element.All.Cast<HtmlElement>().Where(el=>el.TagName.ToUpper().Equals(TagName.ToUpper())).ToList();
            }
     }
}
