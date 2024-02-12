 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class POVController : MonoBehaviourPunCallbacks
{
    public enum POV
    {
        FPS = 0,  // first person shooter
        TPS = 1,  // third person shooter
        MAP = -1,  // third person shooter
    }

    [SerializeField] private GameObject firstPersonCam;
    [SerializeField] private GameObject thirdPersonCam;
    // [SerializeField] private GameObject mapViewCamera;
    [SerializeField] public POV CamMode;

    private GameObject head;

    private void Start()
    {
        //if (!PhotonView.FindObjectOfType<PhotonView>().IsMine) return;

        CamMode = POV.TPS;
        Invoke(nameof(Init), .1f);
    }

    private void Init()
    {
        head = PTPlayerSpawnManager.Instance.GetMyPlayer().Head;
        StartCoroutine(camChange());
    }

    public void OnViewBtnDown()
    {
        if (CamMode == POV.MAP || CamMode == POV.TPS)
        {
            CamMode = 0;
        }
        else
        {
            CamMode += 1;
        }
        StartCoroutine(camChange());
    }

    IEnumerator camChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == POV.FPS)
        {
            firstPersonCam.SetActive(true);
            thirdPersonCam.SetActive(false);
            head.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }
        if (CamMode == POV.TPS)
        {
            firstPersonCam.SetActive(false);
            thirdPersonCam.SetActive(true);
            head.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
        // if (CamMode == POV.MAP)
        // {
        //     firstPersonCam.SetActive(false);
        //     thirdPersonCam.SetActive(false);
        //     mapViewCamera.SetActive(true);
        //     head.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        // }
    }
}
