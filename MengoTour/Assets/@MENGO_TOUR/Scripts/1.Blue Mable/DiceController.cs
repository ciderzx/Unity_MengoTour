using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MENGO_TOUR.BOARD
{
    public class DiceController : MonoBehaviour, IPunObservable
    {
        [SerializeField] private Collider[] pointColliders;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private DiceChecker checker;
        private Transform diceTran;

        private void Awake()
        {
            diceTran = GetComponent<Transform>();
        }

        private bool doInit;

        private void Init()
        {
            if (doInit) return;
            doInit = true;

            foreach (Collider collider in pointColliders)
            {
                collider.enabled = true;
            }
        }

        public void Rollin()
        {
            Invoke(nameof(Init), .5f);

            checker.rollinDice = true;

            DOTween.Kill(gameObject + "Rollin");

            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);

            float jumpForce = Random.Range(200, 400);

            transform.position = Vector3.up * 2;
            transform.rotation = Quaternion.identity;
            rigidbody.AddForce(transform.up * jumpForce);
            rigidbody.AddTorque(dirX, dirY, dirZ);
        }

        private Vector3 curPos;
        private Quaternion curRot;

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(diceTran.position);
                stream.SendNext(diceTran.rotation);
            }
            else
            {
                curPos = (Vector3)stream.ReceiveNext();
                curRot = (Quaternion)stream.ReceiveNext();
            }
        }
    }
}


