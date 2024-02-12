using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.UI;

public class StartManager : PhotonSingleton<StartManager>
{
    [HideInInspector]public bool clickCheck = false; // Connect 버튼을 눌렀는지 확인

    [SerializeField] private GameObject connectionPanel; 

    public void ConnectionCheck()
    {
        connectionPanel.SetActive(clickCheck); // 패널 닫기
        MenuManager.Instance.OpenMenu("loading");//로딩창 열기
        clickCheck = true; 
    }
}
