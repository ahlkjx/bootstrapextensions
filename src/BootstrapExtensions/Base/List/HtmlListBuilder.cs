namespace BootstrapExtensions.Base
{
    public class HtmlListBuilder
    {
        private readonly HtmlList _list;

        public HtmlListBuilder(HtmlList list)
        {
            _list = list;
        }

        public void Item(string text)
        {
            _list.ListItems.Add(new HtmlListItem(text));
        }

        public HtmlListItem Link(string text, string url, string identifier = null)
        {
            var link = new HtmlListItem(string.Format("<a href=\"{0}\">{1}</a>", url, text));
            var currActive = _list.HtmlAttributes["data-activeLink"];
            if (!string.IsNullOrEmpty(identifier) && currActive == identifier) link.Active();
            _list.ListItems.Add(link);
            return link;
        }

        public void Divider()
        {
            _list.ListItems.Add(new HtmlListItem().Divider());
        }
    }
}