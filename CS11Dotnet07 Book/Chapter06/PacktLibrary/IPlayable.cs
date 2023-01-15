namespace Packt.Shared;

public interface IPlayable
{
    void Play();
    void Pause();
    void Stop()
    {
        WriteLine("defualt implementation of Stop");
    }
}

