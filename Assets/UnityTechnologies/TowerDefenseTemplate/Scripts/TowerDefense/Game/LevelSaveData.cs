using System;

namespace TowerDefense.Game
{
	/// <summary>
	/// A calss to save level data
	/// </summary>
	[Serializable]
	public class LevelSaveData
	{
		public string id;
		public int numberOfStars;

		public float[] bestElapcedTimes;

		public LevelSaveData(string levelId, int numberOfStarsEarned, float elapcedTime)
		{
			id = levelId;
			numberOfStars = numberOfStarsEarned;

			bestElapcedTimes = new float[] {0, 0, 0, 0, 0};
			bestElapcedTimes[0] = elapcedTime;
		}

		/// <summary>
		/// adds new elapced element in the decresing order
		/// </summary>
		/// <param name="elapsedtime"></param>
		public void AddElapcedTime(float elapsedtime)
        {
			int insertIndex = 0;

			while (insertIndex < bestElapcedTimes.Length && elapsedtime < bestElapcedTimes[insertIndex])
			{
				insertIndex++;
			}

			for (int i = bestElapcedTimes.Length - 1; i > insertIndex; i--)
			{
				bestElapcedTimes[i] = bestElapcedTimes[i - 1];
			}

			bestElapcedTimes[insertIndex] = elapsedtime;
		}
	}
}