namespace Logger.Appenders
{
    using Logger.Appenders.Contracts;
    using Logger.Enums;
    using Logger.Layouts.Contracts;

    public abstract class Appender : IAppender
    {
        private ILayout layout;

        public Appender(ILayout layout)
        {
            this.layout = layout;
        }
        protected ILayout Layout => layout;

        public ReportLevel ReportLevel { get;  set; }

        public int MessagesCount { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

        //public override string ToString()
        //{
        //    //Appender type: ConsoleAppender, Layout type: SimpleLayout, Report level: CRITICAL, Messages appended: 2
        //    return $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {MessagesCount}";
        //}
    }
}
