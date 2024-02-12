using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class SceneChanger : MonoBehaviourPunCallbacks 
{
    public static string nextScene;
    //public Text LoadingBarText;

    //[SerializeField]
    //public Image progressBar;

    private void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
        StartCoroutine(LoadScene());
    }

    string nextSceneName;
    public static void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        nextScene = sceneName;
        PhotonNetwork.LoadLevel("LoadScene");

        //SceneManager.LoadScene("LoadScene");
    }

    IEnumerator LoadScene()
    {
        //yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;

        yield return null;

        while (!op.isDone)
        {
            yield return null;

            Debug.Log(timer);

            timer += Time.deltaTime;

            if (!(op.progress >= timer)) yield return null;

            yield return new WaitForSecondsRealtime(2.0f);
            op.allowSceneActivation = true;
        }
        //while (!op.isDone)
        //{
        //    yield return null;

        //    timer += Time.deltaTime;

        //    LoadingBarText.text = (progressBar.fillAmount * 100f).ToString("N0") + " %";

        //    if (op.progress >= 0.9f)
        //    {
        //        progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

        //        if (progressBar.fillAmount == 1.0f)
        //            op.allowSceneActivation = true;
        //    }
        //    else
        //    {
        //        progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);

        //        if (progressBar.fillAmount >= op.progress)
        //        {
        //            timer = 0f;
        //        }
        //    }
        //}
    }
}
