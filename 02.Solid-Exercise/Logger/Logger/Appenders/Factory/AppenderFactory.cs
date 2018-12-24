namespace Logger.Appenders.Factory
{
    using Logger.Appenders.Contracts;
    using Logger.Appenders.Factory.Contract;
    using Logger.Layouts.Contracts;
    using Logger.Loggers;
    using System;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            var appanderType = type.ToLower();
            switch (appanderType)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout,new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
