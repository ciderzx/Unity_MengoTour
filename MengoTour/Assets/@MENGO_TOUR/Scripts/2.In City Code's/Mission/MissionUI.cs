using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MENGO_TOUR.CITY
{
    public class MissionUI : MonoBehaviour
    {
        public Mission mission;
        public Text missionTitle;
        public Text missionCntText;

        [SerializeField] private float time;
        [SerializeField] private Image timeImage;

        private void OnEnable()
        {
            transform.localScale = Vector3.zero;

            transform.DOScale(1f, .5f)
                .SetEase(Ease.OutBack)
                .SetId(gameObject);

            StartCoroutine(PlayTime());
        }

        public void Init()
        {
            missionTitle.text = mission.missionTitle;
            time = mission.time;
            missionCntText.text = mission.MissionCnt + "/" + mission.missionMaxCnt;
        }

        private IEnumerator PlayTime()
        {
            float currentTime = time;
            while(currentTime > 0)
            {
                currentTime-=Time.deltaTime;
                timeImage.fillAmount = currentTime / time * 1;

                yield return null;
            }

            Disable();
        }

        public void Disable()
        {
            DOTween.Kill(gameObject);

            transform.DOScale(0f, .5f)
                .SetEase(Ease.InBack)
                .SetId(gameObject)
                .OnComplete(() =>
                {
                    gameObject.SetActive(false);
                });
        }

        private void OnDisable()
        {
            DOTween.Kill(gameObject);
            MissionManager.Instance.RemoveMission(mission);
        }
    }
}

