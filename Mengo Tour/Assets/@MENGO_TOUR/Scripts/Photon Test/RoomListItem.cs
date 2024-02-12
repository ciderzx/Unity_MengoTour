using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class RoomListItem : MonoBehaviour
{

    [SerializeField] private Text itemText;

    /// <summary>
    /// 포톤의 리얼타임 방정보 기능
    /// </summary>
    public RoomInfo info;

    public void SetUp(RoomInfo info)
    {
        this.info = info;
        itemText.text = info.Name;
    }

    public void OnClick()
    {
        Launcher.Instance.JoinRoom(this.info);
    }
}
