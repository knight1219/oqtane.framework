using Microsoft.AspNetCore.Components;
using Oqtane.Core.Modules;

namespace Oqtane.Core.Themes
{
    public class LayoutBase : ComponentBase, ILayoutControl
    {
        [CascadingParameter]
        protected PageState PageState { get; set; }
        public virtual string Panes { get; set; }

        public string LayoutPath()
        {
            return "Themes/" + this.GetType().Namespace + "/";
        }

    }
}
