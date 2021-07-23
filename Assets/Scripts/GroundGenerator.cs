using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject inputman;
    public GameObject dirtblock;
    public Transform defaultt;
    private float width;
    private float height;
    private int planes; //一個玩家要幾個地板
    private float planespeed; //地板沉下去的速度
    void Start()
    {
        width=Screen.width/200;
        height=Screen.height/200;
        planes=inputman.GetComponent<ParameterManager>().planes;
        planespeed=inputman.GetComponent<ParameterManager>().planespeed;
        Genmap();
    }
    public void Genmap(){
        for(int i=-planes;i<planes;i++){
            Vector3 pos=defaultt.position;
            pos.x+=i<0?(width/planes)*(i+0.5f):(width/planes)*(i+0.5f);
            pos.y=-height*2;
            pos.z-=0.1f;
            GameObject dirt=Instantiate(dirtblock,pos,Quaternion.identity);
            dirt.transform.SetLocalScaleX(width/planes/2);
            dirt.transform.SetLocalScaleY(height);
            dirt.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
