using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Sprite m_Sprite_idle;
    public Sprite m_Sprite_left;
    public Sprite m_Sprite_left2;
    public Sprite m_Sprite_right;
    public Sprite m_Sprite_right2;
    public Sprite m_Sprite_jump;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    private int InputState = 0;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = m_Sprite_idle; // set the sprite to sprite1
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            if (spriteRenderer.sprite == m_Sprite_idle)
            {
                InputState = 1;
                spriteRenderer.sprite = m_Sprite_left;
                timer = 0;
            }
            transform.Translate(Vector3.left * Time.deltaTime * ParameterManager.Instance.playerSpeed);

        }

        if (Input.GetKey(KeyCode.D))
        {
            if (spriteRenderer.sprite == m_Sprite_idle)
            {
                InputState = 2;
                spriteRenderer.sprite = m_Sprite_right;
                timer = 0;
            }

            transform.Translate(Vector3.right * Time.deltaTime * ParameterManager.Instance.playerSpeed);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InputState = 3;
            if (spriteRenderer.sprite == m_Sprite_idle)
            {
                spriteRenderer.sprite = m_Sprite_jump;
                timer = 0;
            }

            rigidbody2D.velocity = Vector2.up * ParameterManager.Instance.playerJumpVelocity;
        }
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
