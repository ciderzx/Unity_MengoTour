using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util;

namespace MENGO_TOUR.CITY
{
    public class Timer : MonoBehaviour
    {
        private int maxTime;

        private int currentTime;

        [SerializeField] private Text timerText;

        private void OnEnable()
        {
            maxTime = DataManager.Instance.GetGameData().timer;
            //Debug.Log(maxTime);

            StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            currentTime = maxTime;
            while (currentTime > 0)
            {
                timerText.text = Function.GetTime(currentTime);

                currentTime--;
                yield return new WaitForSeconds(1f);
            }

            SceneChanger.LoadScene("Board Play Scene");
        }
    }
}


