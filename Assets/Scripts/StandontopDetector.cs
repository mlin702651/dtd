using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandontopDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject groundctrl;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Player1") || hit.CompareTag("Player2"))
        {
            groundctrl.GetComponent<GroundController>().stepped(this.GetComponentInParent<Transform>().gameObject);
        }
    }
}
