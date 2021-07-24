﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{
    // Start is called before the first frame update
    public string dirtstate;
    private float temptime;
    void Start()
    {
        temptime=-1;
    }

    // Update is called once per frame
    void Update()
    {
        switch(dirtstate){
            case "rise":
                if(temptime==-1){
                    temptime=0;
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                else if(temptime<ParameterManager.Instance.groundchangingTime){
                    temptime++;
                    transform.SetPositioinY(transform.position.y+ParameterManager.Instance.groundchangingUnit/ParameterManager.Instance.groundchangingTime*temptime);
                }
                else{
                    transform.GetChild(0).gameObject.SetActive(true);
                    Debug.Log(this+"rised");
                    dirtstate="none";
                    temptime=-1;
                }
            break;
            case "fall":
            if(temptime==-1){
                    temptime=0;
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                else if(temptime<ParameterManager.Instance.groundchangingTime){
                    temptime++;
                    transform.SetPositioinY(transform.position.y-ParameterManager.Instance.groundchangingUnit/ParameterManager.Instance.groundchangingTime*temptime);
                }
                else{
                    transform.GetChild(0).gameObject.SetActive(true);
                    if(transform.position.y<=-Screen.height/100){
                        transform.GetChild(0).gameObject.SetActive(false);
                    }
                    dirtstate="none";
                    Debug.Log(this+"falled");
                    temptime=-1;
                }
            break;
            default:
            break;
        }
    }
}