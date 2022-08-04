using System;

namespace RumarApp.Infraestructure.ViewModelAttributes
{
    public class PlaceHolderAttribute : Attribute
    {
        public string Text { get; private set; }

        public PlaceHolderAttribute(string text)
        {
            Text = text;
        }
    }
}
