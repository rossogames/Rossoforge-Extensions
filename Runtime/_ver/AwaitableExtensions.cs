using System;
using System.Collections.Generic;
using UnityEngine;

namespace RossoGames.SDK.Extensions.Unity
{
    public static class AwaitableExtensions
    {
        public static Awaitable Completed
        {
            get
            {
                AwaitableCompletionSource _completedTask = new();
                _completedTask.SetResult();
                return _completedTask.Awaitable;
            }
        }

        public static async Awaitable WhenAll(IEnumerable<Awaitable> Awaitables)
        {
            foreach (var task in Awaitables)
                await task;
        }

        public static async Awaitable WaitUntil(Func<bool> condition, float checkIntervalSeconds = 0.01f)
        {
            while (!condition())
            {
                await WaitForSecondsRealtimeAsync(checkIntervalSeconds);
            }
        }

        public static async Awaitable WaitForSecondsRealtimeAsync(float seconds)
        {
            float startTime = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup < startTime + seconds)
            {
                await Awaitable.NextFrameAsync();
            }
        }
    }
}
