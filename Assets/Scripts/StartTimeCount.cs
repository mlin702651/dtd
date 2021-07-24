using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimeCount : MonoBehaviour
{
    public GameObject numberblock; // 文字顯示區
    public GameObject darkCurtain;
    SpriteRenderer spriteRenderer;
    int timeCount = 3;
    public Sprite[] numberSprite;

    void Start()
    {
        spriteRenderer = numberblock.GetComponent<SpriteRenderer>();
        timeCount = ParameterManager.Instance.timeCount2;
        InvokeRepeating("timer", 1, 1);
    }

    void timer()
    {
        spriteRenderer.sprite = numberSprite[timeCount];
        timeCount -= 1;
        if (timeCount == 0)
        {
            CancelInvoke("timer");
            Destroy(numberblock.gameObject);
            Destroy(darkCurtain);
        }
    }

    void Update()
    {

    }
}
