namespace Logger.Loggers
{
    using System;
    using global::Logger.Appenders.Contracts;
    using global::Logger.Enums;
    using global::Logger.Loggers.Contracts;

    public class Logger : ILogger
    {
        private IAppender consoleAppender;
        private IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }
        public Logger(IAppender consoleAppender,IAppender fileAppender)
            :this(consoleAppender)
        {
            this.fileAppender = fileAppender;
        }

        public void Error(string dateTime, string errorMessage)
        {
            AppendMessage(dateTime, ReportLevel.ERROR, errorMessage);
        }

        internal void Warn(string dateTime, string warningMessage)
        {
            AppendMessage(dateTime, ReportLevel.WARNING, warningMessage);
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            AppendMessage(dateTime, ReportLevel.CRITICAL, criticalMessage);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            AppendMessage(dateTime, ReportLevel.FATAL, fatalMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            AppendMessage(dateTime, ReportLevel.INFO, infoMessage);
        }

        private void AppendMessage(string dateTime, ReportLevel reportLevel, string message)
        {
            consoleAppender.Append(dateTime, reportLevel, message);
            fileAppender?.Append(dateTime, reportLevel, message);
        }
    }
}
