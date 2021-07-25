using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public GameObject UNIT;
    public GameObject TEN;

    SpriteRenderer unitSprite;
    SpriteRenderer tenSprite;
    public Sprite[] numberSprite;
    public GameObject RButton;
    public GameObject EButton;
    float timeCount;
    public Text timeCount_UI;
    public GameObject END_UI;
    public GameObject Win_UI;
    public Text win_UI;
    int addd; //遊戲開始倒數

    int unitPlace = 0;
    int tenPlace = 6;

    void Start()
    {
        addd = ParameterManager.Instance.timeCount2;
        timeCount = ParameterManager.Instance.TimeCount;
        unitSprite = UNIT.GetComponent<SpriteRenderer>();
        tenSprite = TEN.GetComponent<SpriteRenderer>();
        // END_UI.SetActive(false);
        InvokeRepeating("timer", 1, 1);
    }

    public void timer()
    {
        if (addd == 0)
        {
            timeCount--;
            unitPlace = (int)timeCount / 1 % 10;
            tenPlace = (int)timeCount / 10 % 10;
        }
        else
        {
            addd--;
        }
        unitSprite.sprite = numberSprite[unitPlace];
        tenSprite.sprite = numberSprite[tenPlace];
        // timeCount_UI.text = timeCount + "";

        if (timeCount == 0)
        {
            timeCount_UI.text = "0";
            END_UI.SetActive(true);
            Win_UI.SetActive(true);
            RButton.SetActive(true);
            EButton.SetActive(true);
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
