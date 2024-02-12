using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace MENGO_TOUR.BOARD
{
    public class BoardPlayer : MonoBehaviourPunCallbacks, IPunObservable
    {
        [SerializeField] private float jumpPower;
        [SerializeField] private Ease jumpEase;

        private Transform boardPlayerTran;

        private int tileIndex;
        private int prevTileIndex;

        private void Awake()
        {
            boardPlayerTran = GetComponent<Transform>();
        }

        private void Start()
        {
            BoardManager.Instance.PlayerMoveEventHandler += Movement;
        }

        public int TileIndex
        {
            get { return tileIndex; }
            set
            {
                prevTileIndex = tileIndex;

                if (value > 11)
                {
                    tileIndex = value - 12;
                }
                else
                {
                    tileIndex = value;
                }
            }
        }

        //private Vector3 MovePosition()
        //{
        //    return BoardManager.Instance.GetBoard(tileIndex).position;
        //}

        private Vector3 MovePosition(int tileIndex)
        {
            return BoardManager.Instance.GetBoard(tileIndex).position;
        }

        public void Movement(int randomDice)
        {    
            if (!photonView.IsMine) return;

            TileIndex += randomDice;

            StartCoroutine(MoveCoroutine());
        }

        private IEnumerator MoveCoroutine()
        {
            int realTileIndex = tileIndex;

            if(realTileIndex < prevTileIndex)
            {
                realTileIndex += 12;
            }    

            for (int index = ++prevTileIndex; index <= realTileIndex; index++)
            {
                int moveIndex = index;

                if(moveIndex > 11)
                {
                    moveIndex -= 12;
                }

                transform.DOJump(MovePosition(moveIndex), jumpPower, 1, .5f)
                    .SetEase(jumpEase)
                    .SetId(gameObject);

                yield return new WaitUntil(() => !DOTween.IsTweening(gameObject));
            }

            yield return new WaitForSeconds(.5f);

            BoardManager.Instance.LoadScene();
        }

        private Vector3 curPos;
        private Quaternion curRot;

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(boardPlayerTran.position);
                stream.SendNext(boardPlayerTran.rotation);
            }
            else
            {
                curPos = (Vector3)stream.ReceiveNext();
                curRot = (Quaternion)stream.ReceiveNext();
            }
        }
    }
}

