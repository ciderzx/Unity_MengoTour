using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScene : MonoBehaviour
{
    public void Go(string sceneNm)
    {
        SceneChanger.LoadScene(sceneNm);
    }
}
