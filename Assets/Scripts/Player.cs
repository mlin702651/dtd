using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * ParameterManager.Instance.playerSpeed);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * ParameterManager.Instance.playerSpeed);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.velocity = Vector2.up * ParameterManager.Instance.playerJumpVelocity;
        }
    }
}
