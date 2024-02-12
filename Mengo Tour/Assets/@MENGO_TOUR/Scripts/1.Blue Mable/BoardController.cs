using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class BoardController : MonoBehaviourPunCallbacks
{
    private PhotonView myView;

    [HideInInspector] public int uniqueNumber;

    private void Awake()
    {
        if (!photonView.IsMine) return;

        myView = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine) return;

        uniqueNumber = myView.ViewID / 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
