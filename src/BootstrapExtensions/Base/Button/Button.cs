using BootstrapExtensions.Common;

namespace BootstrapExtensions.Base.Button
{
    public class Button : HtmlContainer
    {
        private readonly string _text;
        private readonly ButtonSettings _settings;

        public Button(string text, ButtonSettings settings, object htmlAttributes)
        {
            _text = text;
            _settings = settings ?? new ButtonSettings();
            HtmlAttributes = new HtmlAttributes(htmlAttributes);
            InnerHtml = CreateButton();
        }

        private string CreateButton()
        {
            HtmlAttributes["class"] = "btn";
            _settings.UpdateAttributes(HtmlAttributes);
            return string.Format(_settings.Tag == Tag.Input ? "<input {0} value=\"{1}\"/>" : "<{0} {1}>{2}</{0}>", _settings.Tag.ToString().ToLower(), HtmlAttributes, _text);
        }
    }
}