using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace MENGO_TOUR.BOARD
{
    public class CheckMap : MonoBehaviour
    {
        [SerializeField] private InGameData gameData;

        private void OnTriggerEnter(Collider other)
        {
            BoardPlayer player = other.GetComponent<BoardPlayer>();

            if (player != null)
            {
                DataManager.Instance.SetGameData(gameData);
            }
        }
    }
}

