using System.Web;
using System.Web.Mvc;
using BootstrapExtensions.Common;

namespace BootstrapExtensions.Base.Form.Label
{
    public class LabelAndControl : HtmlContainer
    {
        private static readonly string HorizontalTemplate = "<div {3}><label class=\"control-label\" for=\"{0}\">{1}</label><div class=\"controls\">{2}</div></div>";
        private static readonly string DefaultTemplate = "<label for=\"{0}\">{1}</label>{2}";

        private readonly string _labelFor;
        private readonly string _labelText;
        private readonly IHtmlString _control;
        private readonly string _formLayout;

        public LabelAndControl(ViewContext viewContext, string labelFor, string labelText, IHtmlString control)
        {
            _labelFor = labelFor;
            _labelText = labelText;
            _control = control;
            _formLayout = viewContext.TempData["BootstrapFormLayout"].ToString();
            HtmlAttributes["class"] = "control-group";
        }

        public override string ToHtmlString()
        {
            return string.Format(
                _formLayout == "Horizontal" ? HorizontalTemplate : DefaultTemplate, 
                _labelFor, _labelText,
                _control,
                HtmlAttributes
                );
        }

        public LabelAndControl Warning(bool condition = true)
        {
            if (condition) HtmlAttributes["class"] = "warning";
            return this;
        }

        public LabelAndControl Error(bool condition = true)
        {
            if (condition) HtmlAttributes["class"] = "error";
            return this;
        }

        public LabelAndControl Info(bool condition = true)
        {
            if (condition) HtmlAttributes["class"] = "info";
            return this;
        }

        public LabelAndControl Success(bool condition = true)
        {
            if (condition) HtmlAttributes["class"] = "success";
            return this;
        }
    }
}