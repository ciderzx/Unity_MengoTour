using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject firstPersonCam;
    [SerializeField] private GameObject thirdPersonCam;

    private bool isFirstPersonCam = false;
    private int CamMode = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            StartCoroutine(camChange());
        }
    }

    IEnumerator camChange()
    {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0)
        {
            firstPersonCam.SetActive(true);
            thirdPersonCam.SetActive(false);
        }
        if (CamMode == 1)
        {
            firstPersonCam.SetActive(false);
            thirdPersonCam.SetActive(true);
        }
    }
}
