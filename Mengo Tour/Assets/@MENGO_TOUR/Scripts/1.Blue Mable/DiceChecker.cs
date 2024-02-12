using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MENGO_TOUR.BOARD
{
    public class DiceChecker : MonoBehaviour
    {
        public DicePoint point;
        [SerializeField] private Text diceText;

        private float time;
        [SerializeField] private float checkDuration;

        public bool rollinDice { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<DicePoint>())
            {
                point = other.GetComponent<DicePoint>();
                diceText.text = "Dice : " + point.dicePoint;
                time = checkDuration;

                StartCoroutine(CheckDurationCoroutine());
            }
        }

        private bool runCheckDuration;

        private IEnumerator CheckDurationCoroutine()
        {
            if (runCheckDuration) yield break;
            runCheckDuration = true;

            while (time > 0)
            {
                time -= Time.deltaTime;
                yield return null;
            }

            BoardManager.Instance.PlayerMove(point.dicePoint);

            runCheckDuration = false;
            rollinDice = false;
        }
    }
}
