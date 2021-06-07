using System;

public abstract class Timer
{
    public float Duration { get; set; }

    private float _remainingTime;

    protected Timer(float duration)
    {
        Duration = duration;
        _remainingTime = duration;
    }

    public abstract void Tick(float deltaTime);

}
