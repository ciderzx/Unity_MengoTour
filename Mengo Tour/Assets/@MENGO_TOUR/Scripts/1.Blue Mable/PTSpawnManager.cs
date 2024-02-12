using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using Photon.Pun;
using Photon.Realtime;

public class PTSpawnManager : PhotonSingleton<PTSpawnManager>
{
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject[] characters;

    public void CreatePlayerToBpard()
    {
        int random = Random.Range(1, characters.Length);
        int playerCountNum = PhotonNetwork.LocalPlayer.ActorNumber;

        PhotonNetwork.Instantiate(characters[random].name.ToString(), points[--playerCountNum].position, Quaternion.Euler(0, 90, 0));
    }
}
