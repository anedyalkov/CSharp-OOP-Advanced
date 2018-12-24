namespace Logger.Core
{
    using Logger.Appenders.Contracts;
    using Logger.Appenders.Factory;
    using Logger.Appenders.Factory.Contract;
    using Logger.Core.Contracts;
    using Logger.Enums;
    using Logger.Layouts.Factory;
    using Logger.Layouts.Factory.Contracts;
    using System;
    using System.Collections.Generic;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private ILayoutFactory layoutFactory;
        private IAppenderFactory appenderFactory;
        

        public CommandInterpreter()
        {
            appenders = new List<IAppender>();
            layoutFactory = new LayoutFactory();
            appenderFactory = new AppenderFactory();
        }
        public void AddAppender(string[] args)
        {
            var appenderType = args[0];
            var layoutType = args[1];
            var reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);                
            }
            var currentLayout = layoutFactory.CreateLayout(layoutType);
            var currentAppender = appenderFactory.CreateAppender(appenderType, currentLayout);
            currentAppender.ReportLevel = reportLevel;

            this.appenders.Add(currentAppender);
        }

        public void AddMessage(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0]);
            var dateTime = args[1];
            var message = args[2];

            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
