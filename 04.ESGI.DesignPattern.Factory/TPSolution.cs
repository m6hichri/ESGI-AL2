using System;

namespace _04.ESGI.DesignPattern.Factory
{
    public interface ILogger
    {
        string Log(string log);
    }

    public class XmlLogger : ILogger
    {
        public string Log(string log)
        {
            return $"<log>{log}</log>";
        }
    }

    public class JsonLogger : ILogger
    {
        public string Log(string log) 
        {
            return $"{{Log:'{log}'}}";
        }
    }

    public class Logger
    {
        public enum Format
        {
            Xml,
            Json
        }

        public static ILogger Create(Format format)
        {
            switch (format)
            {
                case Format.Xml: return new XmlLogger();
                case Format.Json: return new JsonLogger();
                default: throw new Exception("...");
            }
        }
    }
}
