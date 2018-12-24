namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Linq;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";

        private ISetFactory setFactory;
        private IPerformerFactory performerFactory;
        private IInstrumentFactory instrumentFactory;
        private ISongFactory songFactory;
        private readonly IStage stage;

		public FestivalController(IStage stage, ISetFactory setFactory,IPerformerFactory performerFactory, IInstrumentFactory instrumentFactory,
            ISongFactory songFactory)
		{
			this.stage = stage;
            this.setFactory = setFactory;
            this.performerFactory = performerFactory;
            this.instrumentFactory = instrumentFactory;
            this.songFactory = songFactory;
		}

		public string ProduceReport()
		{
			var result = string.Empty;

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

			result += ($"Festival length: {FormatTime(totalFestivalLength)}") + "\n";

			foreach (var set in this.stage.Sets)
			{
				result += ($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result += ($"---{performer.Name} ({instruments})") + "\n";
				}

				if (!set.Songs.Any())
					result += ("--No songs played") + "\n";
				else
				{
					result += ("--Songs played:") + "\n";
					foreach (var song in set.Songs)
					{
						result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
					}
				}
			}

			return result.ToString().Trim();
		}

		public string RegisterSet(string[] args)
		{
            var name = args[0];
            var type = args[1];
            var set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            return $"Registered {type} set";
		}

		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

			var instruments = args.Skip(2).ToArray();

			var createdInstruments = instruments
                .Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			var performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instrument in createdInstruments)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            //var songName = args[0];
            //var duration = TimeSpan.Parse(args[1]);
            //var song = songFactory.CreateSong(songName, duration);

            //this.stage.AddSong(song);

            //return $"Registered song {songName} ({duration.ToString()})";

            var name = args[0];
            var stringDuration = args[1].Split(':').Select(int.Parse).ToList();
            TimeSpan duration = new TimeSpan(0, 0, stringDuration[0], stringDuration[1]);

            var song = this.songFactory.CreateSong(name, duration);
            this.stage.AddSong(song);

            return $"Registered song {args[0]} ({args[1]})";
        }

		public string AddSongToSet(string[] args)
		{
			var songName = args[0];
			var setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			var set = this.stage.GetSet(setName);
			var song = this.stage.GetSong(songName);

			set.AddSong(song);

			return $"Added {song} to {set.Name}";
		}

		public string AddPerformerToSet(string[] args)
		{
			return PerformerRegistration(args);
		}

		private string PerformerRegistration(string[] args)
		{
			var performerName = args[0];
			var setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException("Invalid performer provided");
			}

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			//AddPerformerToSet(args);

			var performer = this.stage.GetPerformer(performerName);
			var set = this.stage.GetSet(setName);

			set.AddPerformer(performer);

			return $"Added {performer.Name} to {set.Name}";
		}

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}

        private string FormatTime(TimeSpan totalFestivalLength)
        {
            var stringTotalTime = totalFestivalLength.ToString(TimeFormat);

            if (totalFestivalLength.Hours >= 1)
            {
                var hoursInMinutes = totalFestivalLength.Hours * 60;
                var minutes = totalFestivalLength.Minutes + hoursInMinutes;
                var seconds = totalFestivalLength.Seconds;
                stringTotalTime = $"{minutes}:{seconds:D2}";
            }
            return stringTotalTime;
        }
    }
}