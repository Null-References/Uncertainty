using System;

public abstract class CustomTimer
{
    protected float Duration { get; set; }

    protected float _remainingTime;

    protected CustomTimer(float duration)
    {
        Duration = duration;
       _remainingTime = duration;
    }

    public abstract void Tick(float deltaTime);

}

