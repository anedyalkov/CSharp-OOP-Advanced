namespace Logger.Appenders
{
    using Logger.Appenders.Contracts;
    using Logger.Enums;
    using Logger.Layouts.Contracts;
    using Logger.Loggers;
    using Logger.Loggers.Contracts;
    using System;
    using System.IO;

    public class FileAppender : Appender, IAppender
    {
        private const string path = "../../../log.txt";

        private ILayout layout;
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            :base(layout)
        {
            this.logFile = logFile;
        }


        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
           
            if (reportLevel >= ReportLevel)
            {
                MessagesCount++;
                var content = string.Format(Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
                logFile.Write(content);
                File.AppendAllText(path, content); 
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel}, " +
                $"Messages appended: {MessagesCount}, File size: {logFile.Size}";
        }
    }
}

