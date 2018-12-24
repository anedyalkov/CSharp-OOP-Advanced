namespace FestivalManager.Entities.Factories
{
	using System;
    using System.Reflection;
    using Contracts;
	using Entities.Contracts;

	public class SongFactory : ISongFactory
	{
		public ISong CreateSong(string name, TimeSpan duration)
		{
            var songType = Assembly.GetCallingAssembly().GetType("FestivalManager.Entities.Song");
            var instance = (ISong)Activator.CreateInstance(songType, new object[] { name, duration });
            return instance;

            //var song = new Song(name, duration);
            //return song;
        }
	}
}