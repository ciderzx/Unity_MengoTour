using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Util;
using Cinemachine;

public class PTPlayerManager : PhotonSingleton<PTPlayerManager>
{

    // Start is called before the first frame update
    public override void OnEnable()
    {
        base.OnEnable();

        PhotonNetwork.IsMessageQueueRunning = true;
        PTPlayerSpawnManager.Instance.CreatePlayerToCountry();
    }

}
