﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using Photon.Pun;
using UnityEngine.SceneManagement;


public class RoomoManager : PhotonSingleton<RoomoManager>
{
    void Awake()
    {
        if (Instance)//다른 룸매니저 존재확인
        {
            Destroy(gameObject);//있으면 파괴
            return;
        }
        DontDestroyOnLoad(gameObject);//룸매니저 나혼자면 그대로 
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
        // 활성화되면 씬 매니저의 OnSceneLoaded에 체인을 건다.
        // 씬이 바뀔때마다 작동됨
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
        // 비활성화되면 씬 매니저의 체인을 지운다.
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode load)
    {
        if (scene.buildIndex == 1)//게임씬이면. 0은 현재 시작메뉴 씬이다. 
        {
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity); ;
            //포톤 프리펩에 있는 플레이어 매니저를 저 위치에 저 각도로 만들어주기
        }
    }
}
