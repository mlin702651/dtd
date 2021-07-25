using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{
    // Start is called before the first frame update
    public string dirtstate;
    public int risestack = 0;
    public bool isspeacial=false;
    private float temptime;
    private Color blocolor;
    private bool coloring;
    void Start()
    {
        blocolor=ParameterManager.Instance.blockcolor;
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
                        if(Random.Range(0f,1f)<=ParameterManager.Instance.specialspawn){
                            isspeacial=true;
                        }
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
                    if(isspeacial){
                        isspeacial=false;
                        this.GetComponent<SpriteRenderer>().color=ParameterManager.Instance.blockcolor;
                        //do something special
                    }
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
        if(isspeacial){
            if(coloring){
                if(blocolor.b+Time.deltaTime>1){
                    coloring=false;
                }
                else{
                    blocolor.b+=Time.deltaTime;
                }
            }
            else{
                if(blocolor.b<Time.deltaTime){
                    coloring=true;
                }
                else{
                    blocolor.b-=Time.deltaTime;
                }
            }
            this.GetComponent<SpriteRenderer>().color=blocolor;
        }
    }
}
