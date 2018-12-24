namespace Logger.Layouts.Factory
{
    using Logger.Layouts.Contracts;
    using Logger.Layouts.Factory.Contracts;
    using System;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            var layoutType = type.ToLower();
            switch (layoutType)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
