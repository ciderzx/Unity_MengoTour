using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using Photon.Pun;
using Photon.Realtime;

public class PTPlayerSpawnManager : PhotonSingleton<PTPlayerSpawnManager>
{
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject character;

    [SerializeField] private Transform characterParent;

    [HideInInspector] public GameObject objectTrans;

    public MENGO_TOUR.Game.Player GetMyPlayer()
    {
        MonoBehaviourPunCallbacks[] players = characterParent.GetComponentsInChildren<MonoBehaviourPunCallbacks>();
        foreach(var player in players)
        {
            if (player.photonView.IsMine)
            {
                return player.GetComponent<MENGO_TOUR.Game.Player>();
            }
        }
        return null;
    }


    // Start is called before the first frame update
    public void CreatePlayerToCountry()
    {
        int random = Random.Range(1, points.Length);
        int playerCountNum = PhotonNetwork.LocalPlayer.ActorNumber;

        GameObject spawn = PhotonNetwork.Instantiate(character.name.ToString(), points[random].position, Quaternion.Euler(0, 90, 0));
        spawn.transform.parent = characterParent;
    }
}
