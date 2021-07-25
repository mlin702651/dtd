using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{
    // Start is called before the first frame update
    public string dirtstate;
    public int risestack = 0;
    public bool isspeacial=false;
    public bool isdangerous=false;
    public float danger;
    private float temptime;
    private float colortime;
    private Color blocolor;
    private Color dangerouscolor;
    private Color specialcolor;
    private bool coloring;
    void Start()
    {
        blocolor=ParameterManager.Instance.blockcolor;
        dangerouscolor=ParameterManager.Instance.dangerouscolor;
        specialcolor=ParameterManager.Instance.specialcolor;
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
        if(isspeacial||isdangerous){
            if(isdangerous){
                blocolor=Color.Lerp(ParameterManager.Instance.blockcolor,dangerouscolor,ParameterManager.Instance.fadetime*colortime);
            }
            else{
                blocolor=Color.Lerp(ParameterManager.Instance.blockcolor,specialcolor,ParameterManager.Instance.fadetime*colortime);
            }
            if(coloring){
                    colortime+=Time.deltaTime;
                }
                else{
                    colortime-=Time.deltaTime;
                }
                if(colortime>ParameterManager.Instance.fadetime){
                    coloring=false;
                    colortime=ParameterManager.Instance.fadetime;
                }
                else if(colortime<0){
                    coloring=true;
                    colortime=0;
                }
            danger-=Time.deltaTime;
            if(danger<=0){
                isdangerous=false;
                blocolor=ParameterManager.Instance.blockcolor;
            }
            this.GetComponent<SpriteRenderer>().color=blocolor;
        }
    }
}
