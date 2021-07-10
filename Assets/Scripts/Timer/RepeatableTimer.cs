namespace Timer
{
    public class RepeatableTimer : CustomTimer
    {
        private bool _isReady = false;

        public RepeatableTimer(float duration) : base(duration)
        {
        }

        public override void Tick(float deltaTime)
        {
            if (_isReady) return;

            _remainingTime -= deltaTime;
            _isReady = _remainingTime <= 0 ? true : false;
        }

        public bool IsReady()
        {
            if (_isReady)
            {
                //reset timer
                _isReady = false;
                _remainingTime = Duration;
                return true;
            }

            return false;
        }
    }
}