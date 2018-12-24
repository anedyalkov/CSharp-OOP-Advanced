namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

	public class Stage : IStage
	{
		
		private readonly List<ISet> sets;
		private readonly List<ISong> songs;
		private readonly List<IPerformer> performers;

        public Stage()
        {
            sets = new List<ISet>();
            songs = new List<ISong>();
            performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => sets.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => songs.AsReadOnly();

        public IReadOnlyCollection<IPerformer> Performers => performers.AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            var performer = performers.FirstOrDefault(p => p.Name == name);
            return performer;
        }

        public ISet GetSet(string name)
        {
            var set = sets.FirstOrDefault(s => s.Name == name);
            return set;
        }

        public ISong GetSong(string name)
        {
            var song = songs.FirstOrDefault(s => s.Name == name);
            return song;
        }

        public bool HasPerformer(string name)
        {
            return performers.Any(p => p.Name == name);
        }

        public bool HasSet(string name)
        {
            return sets.Any(s => s.Name == name);
        }

        public bool HasSong(string name)
        {
            return songs.Any(s => s.Name == name);
        }
    }
}
