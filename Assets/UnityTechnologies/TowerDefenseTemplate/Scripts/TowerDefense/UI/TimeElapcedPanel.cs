using System;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.UI
{
    public class TimeElapcedPanel : MonoBehaviour
    {
        [SerializeField] private Text[] timeText;

        public void SetTimes(float[] elapcedTimes)
        {
            if(elapcedTimes != null)
            {
                for (int i = 0; i < timeText.Length; i++)
                {
                    TimeSpan timeSpan = TimeSpan.FromSeconds(elapcedTimes[i]);
                    string formattedTime = string.Format("{0:00}:{1:00}", (int)timeSpan.TotalMinutes, timeSpan.Seconds);

                    formattedTime = (i + 1).ToString() + ") TIME : " + formattedTime;

                    timeText[i].text = formattedTime;
                }
            }
        }
    }
}


