using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void stepped(GameObject dirt){
        if(dirt.transform.parent.GetComponent<DirtController>().isdangerous){
            rise(dirt.transform.parent.gameObject);
        }
        else{
            fall(dirt.transform.parent.gameObject);
            rise(dirt.transform.position.x);
        }
    }
    public void rise(float dirtx){
        GameObject dirt;
        int blockamount=ParameterManager.Instance.dirtlist.Count;
        if(dirtx>0){
            dirt=ParameterManager.Instance.dirtlist[Random.Range(0,blockamount/2)];
        }
        else{
            dirt=ParameterManager.Instance.dirtlist[Random.Range(blockamount/2,blockamount)];
        }
        if(dirt.GetComponent<DirtController>().dirtstate=="rise"){
            dirt.GetComponent<DirtController>().risestack++;
        }else{ 
            dirt.GetComponent<DirtController>().dirtstate="rise";
        }
    }
    public void rise(GameObject dirt){
        if(dirt.GetComponent<DirtController>().dirtstate=="rise"){
            dirt.GetComponent<DirtController>().risestack++;
        }else{ 
            dirt.GetComponent<DirtController>().dirtstate="rise";
        }
    }
    public void dangerify(int playerid){
        int blockamount=ParameterManager.Instance.dirtlist.Count;
        GameObject dirt;
        if(playerid==0){
            dirt=ParameterManager.Instance.dirtlist[Random.Range(0,blockamount/2)];
        }
        else{
            dirt=ParameterManager.Instance.dirtlist[Random.Range(blockamount/2,blockamount)];
        }
        if(dirt.GetComponent<DirtController>().isdangerous){
            dangerify(playerid);
        }else{
            dirt.GetComponent<DirtController>().isdangerous=true;
            dirt.GetComponent<DirtController>().danger=ParameterManager.Instance.dangertime;
        }
    }
    private void fall(GameObject dirt){
        dirt.GetComponent<DirtController>().dirtstate="fall";
    }
}
