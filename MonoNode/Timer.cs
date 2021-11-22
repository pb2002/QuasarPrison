using System;
using Microsoft.Xna.Framework;

namespace MonoNode
{
    /// <summary>
    /// A timer object for implementing delays and sequences.
    /// </summary>
    public class Timer : Node
    {
        /// <summary>
        /// An event that gets invoked when the timer runs out.
        /// </summary>
        public event Action OnTimerFinished;
        /// <summary>
        /// An event that gets invoked when the timer is started manually or auto-resets.
        /// </summary>
        public event Action OnTimerStarted;
        
        /// <summary>
        /// The remaining time of this timer.
        /// </summary>
        public float Time { get; private set; }
        /// <summary>
        /// The duration of this timer.
        /// </summary>
        public float Duration { get; set; }
        /// <summary>
        /// Should this timer auto-reset upon finishing?
        /// </summary>
        public bool Repeat { get; set; }
        
        /// <summary>
        /// Is this timer currently paused?
        /// </summary>
        public bool Paused { get; private set; }
        
        /// <summary>
        /// The completion amount of this timer going from 0 to 1.
        /// </summary>
        public float Completion => 1f - (Time / Duration);
        
        /// <summary>
        /// Is this timer finished?
        /// </summary>
        public bool Finished => Time <= 0;
        
        /// <summary>
        /// Is this timer currently running?
        /// </summary>
        public bool Running => !Finished && !Paused;
        
        /// <summary>
        /// A timer object for implementing delays and sequences.
        /// </summary>
        /// <param name="name">The name of the object.</param>
        /// <param name="duration">The duration of the timer.</param>
        /// <param name="repeat">Whether or not the timer should auto-reset upon finishing.</param>
        public Timer(string name, float duration, bool repeat = false) : base(name)
        {
            Duration = duration;
            Repeat = repeat;
        }
        /// <summary>
        /// Starts the timer
        /// </summary>
        public void Start()
        {
            Time = Duration;
            OnTimerStarted?.Invoke();   
        }
        /// <summary>
        /// Starts the timer with the given duration
        /// </summary>
        /// <param name="duration">The new duration of the timer.</param>
        public void Start(float duration)
        {
            Time = duration;
            Duration = duration;
            OnTimerStarted?.Invoke();
        }
        /// <summary>
        /// Pauses or unpauses the timer.
        /// </summary>
        /// <param name="paused">Whether or not the timer should be paused</param>
        public void Pause(bool paused)
        {
            Paused = paused;
        }
        /// <summary>
        /// Stops the timer.
        /// </summary>
        /// <param name="triggerEvent">Whether or not the OnTimerFinished event should be triggered.</param>
        public void Stop(bool triggerEvent = false)
        {
            Time = 0;
            if (triggerEvent) OnTimerFinished?.Invoke();
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (!Running) return;

            Time -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (Time <= 0)
            {
                Time = 0;
                OnTimerFinished?.Invoke();
                if (Repeat) Start();
            }
        }
    }
}