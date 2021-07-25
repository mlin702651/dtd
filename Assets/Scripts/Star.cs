using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float starJump;
    public float starJumpMin;
    public float starJumpMax;
    public static Star Instance;
    public Transform starPos;
    float G;

    Vector2 vector2;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        G = ParameterManager.Instance.G;
    }
    void Update()
    {
        if (Physics2D.OverlapPoint(starPos.GetPosition(), LayerMask.GetMask("Ground")))
        {
            vector2.y = starJump;
            starJump = Mathf.Clamp(starJump--, starJumpMin, starJumpMax);

            if (transform.position.x <= -6.7f)
            {
                vector2.x = Random.Range(0, 5);
            }
            else if (transform.position.x >= 6.7f)
            {
                vector2.x = Random.Range(0, -5);
            }
            else
            {
                vector2.x = Random.Range(5, -5);
            }
        }
        else
        {
            vector2.y -= G * Time.deltaTime;
        }
        transform.Translate(vector2 * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player1":
                //ParameterManager.Instance.whoTouch = 1;
                Destroy(gameObject);
                Debug.Log("Player1");
                break;
            case "Player2":
                //sParameterManager.Instance.whoTouch = 2;
                Destroy(gameObject);
                Debug.Log("Player2");
                break;
            default:
                break;
        }
    }
}
