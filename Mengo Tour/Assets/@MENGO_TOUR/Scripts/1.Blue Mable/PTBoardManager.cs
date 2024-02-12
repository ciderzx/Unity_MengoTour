using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PTBoardManager : PhotonSingleton<PTBoardManager>
{
    [SerializeField] private Text myNickName;

    // Start is called before the first frame update
    void Start()
    {
        // 포톤 네트워크의 데이터 통신을 다시 연결 시켜줌
        PhotonNetwork.IsMessageQueueRunning = true;
        PTSpawnManager.Instance.CreatePlayerToBpard();
        myNickName.text = "Name : " + PhotonNetwork.NickName.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
