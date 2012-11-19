using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using BootstrapExtensions.Common;

namespace BootstrapExtensions.Base.Form
{
    /* STARTED APPROACHING THIS WRONG. Utilize MvcForm to get benefits such as automatic validation */

    public static class FormExtensions
    {
        public static Form Form(this HtmlHelper html, object htmlAttributes = null)
        {
            return new Form(null, null, htmlAttributes);
        }
        public static Form Form(this HtmlHelper html, Action<FormBuilder> formBuilder, object htmlAttributes = null)
        {
            return new Form(formBuilder, null, htmlAttributes);
        }

        public static Form Form(this HtmlHelper html, FormSettings settings, Action<FormBuilder> formBuilder, object htmlAttributes = null)
        {
            return new Form(formBuilder, settings, htmlAttributes);
        }
    }

    public class FormBuilder
    {
        private readonly Form _form;

        private readonly List<FormItem> _formItems = new List<FormItem>();

        public FormBuilder(Form form)
        {
            _form = form;
        }

        public void Legend(string text)
        {
            _form.InnerHtml += string.Format("<legend>{0}</legend>", text);
        }

        public FormItem TextBox()
        {
            var textbox = new FormItem
                              {
                              };
            _formItems.Add(textbox);
            return textbox;
        }
    }

    public class FormItem
    {
        public Func<HtmlHelper, MvcHtmlString> Input { get; set; } 
    }

    public sealed class Form : HtmlContainer
    {
        private readonly FormSettings _settings;

        public Form(Action<FormBuilder> formBuilder, FormSettings settings, object htmlAttributes)
        {
            _settings = settings;
            if (htmlAttributes != null) HtmlAttributes = new HtmlAttributes(htmlAttributes);
            if (formBuilder != null) formBuilder(new FormBuilder(this));
        }

        protected override string StartHtml()
        {
            return string.Format("<form {0}>", HtmlAttributes);
        }

        protected override string EndHtml()
        {
            return string.Format("</form>");
        }

        public Form Search()
        {
            HtmlAttributes["class"] = "form-search";
            return this;
        }

        public Form Inline()
        {
            HtmlAttributes["class"] = "form-inline";
            return this;
        }

        public Form Horizontal()
        {
            HtmlAttributes["class"] = "form-horizontal";
            return this;
        }
    }

    public class FormSettings
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public object RouteValues { get; set; }
        public FormMethod FormMethod { get; set; }
    }
}
