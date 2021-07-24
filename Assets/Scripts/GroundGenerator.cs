﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject inputman;
    public GameObject dirtblock;
    public GameObject groundctrl;
    public Transform defaultt;
    private float width;
    private float height;
    private int planes; //一個玩家要幾個地板
    private float planespeed; //地板沉下去的速度
    void Start()
    {
        width=Screen.width/200;
        height=Screen.height/200;
        planes=ParameterManager.Instance.planes;
        planespeed=ParameterManager.Instance.planespeed;
        Genmap();
        for(int i=0;i<ParameterManager.Instance.startblockamount;i++){
            groundctrl.GetComponent<GroundController>().rise(-1f);
            groundctrl.GetComponent<GroundController>().rise(1f);
        }
    }
    public void Genmap(){
        for(int i=-planes;i<planes;i++){
            Vector3 pos=defaultt.position;
            pos.x+=i<0?(width/planes)*(i+0.5f):(width/planes)*(i+0.5f);
            pos.y=-height*2;
            pos.z-=0.1f;
            GameObject dirt=Instantiate(dirtblock,pos,Quaternion.identity);
            dirt.transform.SetLocalScaleX(width/planes);
            //dirt.transform.SetLocalScaleY(height);
            //dirt.GetComponent<BoxCollider2D>().size=new Vector2(2f,2f);
            dirt.name="土塊"+i;
            dirt.SetActive(true);
            ParameterManager.Instance.dirtlist.Add(dirt);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
