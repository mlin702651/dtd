using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public GameObject timeUp;
    public GameObject UNIT;
    public GameObject TEN;

    public GameObject LCrown;

    public GameObject RCrown;
    SpriteRenderer unitSprite;
    SpriteRenderer tenSprite;
    public Sprite[] numberSprite;
    public GameObject RButton;
    public GameObject EButton;
    float timeCount;
    public GameObject END_UI;
    public GameObject Win_UI;
    int addd; //遊戲開始倒數

    int unitPlace = 0;
    int tenPlace = 6;

    void Start()
    {
        addd = ParameterManager.Instance.timeCount2;
        timeCount = ParameterManager.Instance.TimeCount;
        unitSprite = UNIT.GetComponent<SpriteRenderer>();
        tenSprite = TEN.GetComponent<SpriteRenderer>();
        InvokeRepeating("timer", 1, 1);
    }

    public void timer()
    {
        if (addd == 0)
        {

            if (timeCount > 0)
            {
                unitPlace = (int)timeCount / 1 % 10;
                tenPlace = (int)timeCount / 10 % 10;
                timeCount--;
            }

        }
        else
        {
            addd--;
        }
        unitSprite.sprite = numberSprite[unitPlace];
        tenSprite.sprite = numberSprite[tenPlace];

        if (timeCount == 0)
        {
            UNIT.SetActive(false);
            TEN.SetActive(false);
            timeUp.SetActive(true);
            RButton.SetActive(true);
            EButton.SetActive(true);
            switch (ParameterManager.Instance.win_status)
            {
                case -1:
                    LCrown.SetActive(true);
                    break;
                case 0:

                    break;
                case 1:
                    RCrown.SetActive(true);
                    break;
                default:
                    Debug.Log("Default case");
                    break;
            }

            CancelInvoke("timer");
        }

    }
}
