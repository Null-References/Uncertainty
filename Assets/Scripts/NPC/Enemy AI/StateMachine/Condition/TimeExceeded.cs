using UnityEngine;

public class TimeExceeded : Condition
{
    [SerializeField] private float duration = 1f;

    private float _lastTime = 0;
    public override bool IsMet()
    {
        if (Time.time - _lastTime > duration )
        {
            _lastTime = Time.time;
            return true;
        }
        return false;
    }
}
