using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using Photon.Pun;

namespace MENGO_TOUR.BOARD
{
    public class BoardManager : Singleton<BoardManager>
    {
        public delegate void PlayerMoveEvent(int randomDice);
        public event PlayerMoveEvent PlayerMoveEventHandler;

        [SerializeField] private List<Transform> boardList;

        private void OnEnable()
        {
            PlayerMoveEventHandler = delegate (int randomDice) { };
        }

        public Transform GetBoard(int index)
        {
            return boardList[index];
        }

        public void PlayerMove(int diceNumber)
        {
            PlayerMoveEventHandler(diceNumber);
        }

        public void LoadScene()
        {
            PhotonNetwork.LoadLevel("France Play Scene");
            //SceneChanger.LoadScene("France Play Scene");
        }
    }
}

