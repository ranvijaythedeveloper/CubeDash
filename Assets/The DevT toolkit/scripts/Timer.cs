using UnityEngine;
using System;
namespace TheDeveloperTrain.utils
{
    public class CustomTimer
    {
        private float duration;
        private float timeRemaining;
        private bool isRunning;
        private Action onTickCallback;
        private Action onStartCallback;
        private Action onStopCallback;
        private Action onFinishedCallback;

        public CustomTimer(float duration, Action onTickCallback = null, Action onStartCallback = null, Action onStopCallback = null, Action onFinishedCallback = null)
        {
            this.duration = duration;
            this.timeRemaining = duration;
            this.onTickCallback = onTickCallback;
            this.onStartCallback = onStartCallback;
            this.onStopCallback = onStopCallback;
            this.onFinishedCallback = onFinishedCallback;
        }

        public void Start()
        {
            if (!isRunning)
            {
                isRunning = true;
                onStartCallback?.Invoke();
                UpdateTimer(); // Start updating the timer
            }
        }

        public void Stop()
        {
            if (isRunning)
            {
                isRunning = false;
                onStopCallback?.Invoke();
            }
        }

        public void Reset()
        {
            timeRemaining = duration;
        }

        public void UpdateTimer()
        {
            if (isRunning)
            {
                timeRemaining -= Time.deltaTime;
                onTickCallback?.Invoke();

                if (timeRemaining <= 0f)
                {
                    timeRemaining = 0f;
                    isRunning = false;
                    onFinishedCallback?.Invoke();
                }
            }
        }

        public float GetDuration()
        {
            return duration;
        }

        public float GetTimeRemaining()
        {
            return timeRemaining;
        }

        public bool IsRunning()
        {
            return isRunning;
        }
    }
}

