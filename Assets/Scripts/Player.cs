using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool TimeCount = true; //開始倒數計時
    public AudioSource m_MyAudioSource;
    public bool id;
    public float timer;
    public float timer2;
    public Transform leftPoint;
    public Transform RightPoint;
    public Transform leftWallPoint;
    public Transform rightWallPoint;
    public Sprite m_Sprite_idle;
    public Sprite m_Sprite_left;
    public Sprite m_Sprite_left2;
    public Sprite m_Sprite_right;
    public Sprite m_Sprite_right2;
    public Sprite m_Sprite_jump;
    private SpriteRenderer spriteRenderer;
    private int InputState = 0;
    Vector2 v;
    float G = 0;
    float JumpForce;
    float Xspeed;
    float limitspeed;
    void Start()
    {
        limitspeed = ParameterManager.Instance.limitspeed;
        G = ParameterManager.Instance.G;
        JumpForce = ParameterManager.Instance.playerJumpVelocity;
        Xspeed = ParameterManager.Instance.playerXSpeed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = m_Sprite_idle; // set the sprite to sprite1   
    }
    void Update()
    {
        timer2 += Time.deltaTime;
        timer += Time.deltaTime;

        if (Physics2D.OverlapArea(leftPoint.GetPosition(), RightPoint.GetPosition(), LayerMask.GetMask("Ground")))
        {
            v.y = 0f;
        }
        else if (timer2 >= ParameterManager.Instance.timeCount2)
        {
            v.y -= G * Time.deltaTime;
        }

        if ((id ? InputButtonDown.up2 : InputButtonDown.up1) && timer2 >= ParameterManager.Instance.timeCount2)
        {
            if (spriteRenderer.sprite == m_Sprite_idle)
            {
                spriteRenderer.sprite = m_Sprite_jump;
                timer = 0;
            }
            v.y += JumpForce;
            m_MyAudioSource.Play();
        }

        if (id ? InputButtonDown.left2 : InputButtonDown.left1)
        {
            if (spriteRenderer.sprite == m_Sprite_idle)
            {
                InputState = 1;
                spriteRenderer.sprite = m_Sprite_left;
                timer = 0;
            }
            v.x = -Xspeed;
            if (Physics2D.OverlapPoint(leftWallPoint.GetPosition(), LayerMask.GetMask("Ground")))
            {
                v.x = 0f;
            }
        }
        else if (id ? InputButtonDown.riught2 : InputButtonDown.riught1)
        {
            if (spriteRenderer.sprite == m_Sprite_idle)
            {
                InputState = 2;
                spriteRenderer.sprite = m_Sprite_right;
                timer = 0;
            }
            v.x = Xspeed;
            if (Physics2D.OverlapPoint(rightWallPoint.GetPosition(), LayerMask.GetMask("Ground")))
            {
                v.x = 0f;
            }
        }
        else
        {
            v.x = 0f;
        }

        if (v.y >= limitspeed)
        {
            v.y = limitspeed;
        }
        transform.Translate(v * Time.deltaTime);

        if (timer >= 0.3)
        {
            switch (InputState)
            {
                case 1:
                    spriteRenderer.sprite = m_Sprite_left2;
                    timer = 0;
                    InputState = 0;
                    break;
                case 2:
                    spriteRenderer.sprite = m_Sprite_right2;
                    timer = 0;
                    InputState = 0;
                    break;
                default:
                    spriteRenderer.sprite = m_Sprite_idle;
                    timer = 0;
                    break;
            }

        }
    }

}

