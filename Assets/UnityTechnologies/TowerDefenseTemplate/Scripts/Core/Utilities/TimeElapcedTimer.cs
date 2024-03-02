using System;

namespace Core.Utilities
{
    public class TimeElapcedTimer : Timer
    {
		public float currentTime
        {
			get { return m_CurrentTime; }
        }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="time">The time of one cycle</param>
		/// <param name="onElapsed">The event fired at the end of each cycle</param>
		public TimeElapcedTimer(float time, Action onElapsed = null)
			: base(time, onElapsed)
		{
		}

		/// <summary>
		/// Ticks and does not turn off on elapse
		/// </summary>
		/// <param name="deltaTime">The change in time since last tick</param>
		/// <returns>false always to ensure that the timer is not automatically removed</returns>
		public override bool Tick(float deltaTime)
		{
			m_CurrentTime += deltaTime;
			return false;
		}
	}
}


