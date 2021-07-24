using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{
    // Start is called before the first frame update
    public string dirtstate;
    public int risestack = 0;
    private float temptime;
    void Start()
    {
        temptime = -1;
        transform.SetPositioinY(transform.position.y + ParameterManager.Instance.planespeed * risestack);
        risestack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (dirtstate)
        {
            case "rise":
                if (temptime == -1)
                {
                    temptime = 0;
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                else if (temptime < ParameterManager.Instance.groundchangingTime)
                {
                    temptime++;
                    transform.SetPositioinY(transform.position.y + ParameterManager.Instance.planespeed / ParameterManager.Instance.groundchangingTime * temptime);
                }
                else
                {
                    if (risestack == 0)
                    {
                        transform.GetChild(0).gameObject.SetActive(true);
                        dirtstate = "none";
                        temptime = -1;
                    }
                    else
                    {
                        risestack--;
                        temptime = -1;
                    }
                }
                break;
            case "fall":
                if (temptime == -1)
                {
                    temptime = 0;
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                else if (temptime < ParameterManager.Instance.groundchangingTime)
                {
                    temptime++;
                    transform.SetPositioinY(transform.position.y - ParameterManager.Instance.planespeed / ParameterManager.Instance.groundchangingTime * temptime);
                }
                else
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                    if (transform.position.y <= -ParameterManager.Instance.height*2)
                    {
                        transform.GetChild(0).gameObject.SetActive(false);
                    }
                    dirtstate = "none";
                    temptime = -1;
                }
                break;
            default:
                break;
        }
    }
}
