using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaskColor : MonoBehaviour
{
    public Material material;

    [SerializeField]
    Color oneColor;
    [SerializeField]
    Color minusOneColor;
    [SerializeField]
    Color startColor;
    [SerializeField]
    Color startColor02;
    [SerializeField]
    int whoWin;
    float changeTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        whoWin = ParameterManager.Instance.win_status;
        if (whoWin == -1)
        {
            material.color = Color.Lerp(startColor, minusOneColor, Mathf.PingPong(Time.time, changeTime));

        }
        else if (whoWin == 1)
        {
            material.color = Color.Lerp(startColor, oneColor, Mathf.PingPong(Time.time, changeTime));
        }
        else
        {
            material.color = Color.Lerp(startColor, startColor02, Mathf.PingPong(Time.time, changeTime));
        }
    }

}
