using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public float timeCount;
    public Text timeCount_UI;
    public GameObject END_UI;
    void Start()
    {
        timeCount = ParameterManager.Instance.TimeCount;
        // END_UI.SetActive(false);
        InvokeRepeating("timer", 1, 1);
    }

    public void timer()
    {
        timeCount -= 1;

        timeCount_UI.text = timeCount + "";

        if (timeCount == 0)
        {
            timeCount_UI.text = "0";
            END_UI.SetActive(true);
            CancelInvoke("timer");
        }

    }
}
