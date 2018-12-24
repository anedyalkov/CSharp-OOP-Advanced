namespace Logger.Appenders
{
    using Logger.Appenders.Contracts;
    using Logger.Enums;
    using Logger.Layouts.Contracts;
    using System;

    public class ConsoleAppender : Appender, IAppender
    { 
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {

        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
           
            if (reportLevel >= ReportLevel)
            {
                MessagesCount++;
                Console.WriteLine(string.Format(Layout.Format, dateTime, reportLevel, message)); 
            }
        }

        public override string ToString()
        {
            //Appender type: ConsoleAppender, Layout type: SimpleLayout, Report level: CRITICAL, Messages appended: 2
            return $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {MessagesCount}";
        }
    }
}
