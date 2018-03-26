public interface IScalable<T>
{
    T Left { get; }
    T Right { get; }

    T GetHeavier();
}

