using System;
using System.Collections.Generic;
using System.Text;

namespace Problem04
{
    public class Rich
    {
        public Rich()
        {

        }

        public Rich(string protectedAddress)
        {
            this.protectedAddress = protectedAddress;
        }

        public Rich(string publicName, decimal internalDecimal)
            : this(publicName)
        {
            this.internalDecimal = internalDecimal;
        }

        //public
        public string publicName;

        //public readonly
        public readonly string readonlyPublicName;

        //protected internal
        protected internal string protectedInternalName;

        //protected
        protected string protectedAddress;

        //private
        private int privateAge;

        //private const
        private const int privateConstHealth = 20;

        internal decimal internalDecimal;

        public int Age { get; private set; }

        public string Hello()
        {
            return "Hi";
        }

        public string Hello(string name)
        {
            return "Hi " + name;
        }
    }
}
