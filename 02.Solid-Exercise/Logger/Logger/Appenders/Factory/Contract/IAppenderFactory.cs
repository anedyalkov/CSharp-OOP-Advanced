namespace Logger.Appenders.Factory.Contract
{
    using Logger.Appenders.Contracts;
    using Logger.Layouts.Contracts;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
