using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    // ObjectPool stars;
    public GameObject star;
    float timer;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        // stars.Init(star, 10);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            // GameObject star1 = stars.Get();
            // star1.transform.position = new Vector3(Random.Range(-6.7f, 6.7f), 9f, 0f);
            GameObject NewStar = Instantiate(star, new Vector3(Random.Range(-6.7f, 6.7f), 9f, 0f), Quaternion.identity);
            timer = 0;
        }

    }
}
