using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public float timeCount;
    public Text timeCount_UI;
    public GameObject END_UI;
    public GameObject Win_UI;
    public Text win_UI;
    int addd;
    void Start()
    {
        addd = ParameterManager.Instance.timeCount2;
        timeCount = ParameterManager.Instance.TimeCount;
        // END_UI.SetActive(false);
        InvokeRepeating("timer", 1, 1);
    }

    public void timer()
    {
        if (addd == 0)
        {
            timeCount--;
        }
        else
        {
            addd--;
        }
        timeCount_UI.text = timeCount + "";

        if (timeCount == 0)
        {
            timeCount_UI.text = "0";
            END_UI.SetActive(true);
            Win_UI.SetActive(true);
            switch (ParameterManager.Instance.win_status)
            {
                case -1:
                    win_UI.text = "LeftWin!";
                    break;
                case 0:
                    win_UI.text = "Tie!";
                    break;
                case 1:
                    win_UI.text = "RightWin!";
                    break;
                default:
                    Debug.Log("Default case");
                    break;
            }

            CancelInvoke("timer");
        }

    }
}
