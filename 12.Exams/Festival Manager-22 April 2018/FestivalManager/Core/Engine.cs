
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;

	public class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IFestivalController festivalCоntroller, ISetController setCоntroller, IReader reader, IWriter writer)
        {
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
            this.reader = reader;
            this.writer = writer;
        }

		public void Run()
		{
			while (true) 
			{
				var input = reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

				try
				{
					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex) 
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

        public string ProcessCommand(string input)
        {
            var inputArgs = input.Split();

            var command = inputArgs.First();
            var commandArgs = inputArgs.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                var sets = this.setCоntroller.PerformSets();
                return sets;
            }

            var commandToInvoke = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

            string commandResult;

            try
            {
                commandResult = (string)commandToInvoke.Invoke(this.festivalCоntroller, new object[] {commandArgs});
            }
            catch (TargetInvocationException up)
            {
                throw new InvalidOperationException(up.InnerException.Message);
            }

            return commandResult;
        }
    }
}