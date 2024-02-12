using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace MENGO_TOUR.CITY
{
    public class MissionItem : Item
    {
        [SerializeField] private Mission mission;

        [SerializeField] private bool isAddMission;

        [SerializeField] private bool isInputE;

        private void OnDisable()
        {

        }

        #region Item

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(Constants.MENGO_TOUR_CITY.PLAYER_TAG))
            {
                if (!isInputE)
                {
                    if (isAddMission)
                    {
                        MissionManager.Instance.AddMission(mission);
                    }
                    else
                    {
                        MissionManager.Instance.CountUp(mission);
                    }

                    gameObject.SetActive(false);
                }
            }

        }

        protected override void OnTriggerExit(Collider other)
        {

        }

        protected override void OnTriggerStay(Collider other)
        {
            if (other.transform.CompareTag(Constants.MENGO_TOUR_CITY.PLAYER_TAG))
            {
                if (MissionManager.Instance.interaction && isInputE)
                {
                    if (isAddMission)
                    {
                        MissionManager.Instance.AddMission(mission);
                    }
                    else
                    {
                        MissionManager.Instance.CountUp(mission);
                    }

                    gameObject.SetActive(false);
                }
            }
        }

        #endregion
    }
}

