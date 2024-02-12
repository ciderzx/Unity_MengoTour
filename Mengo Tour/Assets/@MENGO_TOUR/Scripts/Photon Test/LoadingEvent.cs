using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingEvent : MonoBehaviour
{
    public Text loadText;
    public float checkTime;

    public string eventText;

    private float timeSpan = 0.0f;
    private int connectCount = 0;
    private string tempText;

    private void Start()
    {
        tempText = eventText;
    }

    // Update is called once per frame
    void Update()
    {
        timeSpan += Time.deltaTime;
        StartCoroutine(TextEvent());
    }

    private IEnumerator TextEvent()
    {
        if (timeSpan >= checkTime)
        {
            loadText.text = eventText;
            eventText += ".";
            timeSpan = 0f;
            connectCount++;

            if (connectCount > 3)
            {
                connectCount = 0;
                eventText = tempText;
            }
        }
        yield return null;
    }
}
