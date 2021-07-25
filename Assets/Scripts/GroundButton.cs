using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundButton : MonoBehaviour
{
    bool onStage = false;
    public ButtonType buttonType;
    public Transform Point;
    public Sprite textSprite;
    SpriteRenderer textSpriteRenderer;

    void Start()
    {
        textSpriteRenderer = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        textSpriteRenderer.sprite = textSprite;
    }


    void Update()
    {
        if (onStage)
        {
            transform.TranslateY(ParameterManager.Instance.ButtonSpeed * Time.deltaTime);
            onStage = false;
        }

        if (Physics2D.OverlapPoint(Point.GetPosition(), LayerMask.GetMask("ButtonGround")))
        {
            if (buttonType == ButtonType.RestartType)
            {
                SceneManager.LoadScene("Testground");
            }
            else if (buttonType == ButtonType.ExitType)
            {
                Application.Quit();
            }
        }
    }

    void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.CompareTag("Player"))
        {
            onStage = true;
        }
    }
    public enum ButtonType
    {
        RestartType, ExitType
    }
}
