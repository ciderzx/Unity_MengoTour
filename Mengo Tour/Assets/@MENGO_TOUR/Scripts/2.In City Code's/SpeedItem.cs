using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace MENGO_TOUR.CITY
{
    public class SpeedItem : Item, ChangeStatHandler
    {
        #region ChangeStatHandler

        public void ChangeStat(ref Stat stat)
        {
            stat.moveSpeed += increaseValue;
        }

        #endregion

        #region Item

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(Constants.MENGO_TOUR_CITY.PLAYER_TAG))
            {
                Stat stat = other.GetComponent<Player>().Stat;

                ChangeStat(ref stat);

                gameObject.SetActive(false);
            }
        }

        protected override void OnTriggerExit(Collider other)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnTriggerStay(Collider other)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}

