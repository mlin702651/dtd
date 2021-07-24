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
        fall(dirt.transform.parent.gameObject);
        rise(dirt.transform.position.x);
    }
    public void rise(float dirtx){
        GameObject dirt;
        int blockamount=ParameterManager.Instance.dirtlist.Count;
        if(dirtx>0){
            dirt=ParameterManager.Instance.dirtlist[Random.Range(0,blockamount/2)];
            dirt.transform.GetChild(0).gameObject.SetActive(false);
            for(float i=0;i<ParameterManager.Instance.groundchangingTime;i++){
                dirt.transform.SetPositioinY(dirt.transform.position.y+ParameterManager.Instance.groundchangingUnit*i);
            }
        }
        else{
            dirt=ParameterManager.Instance.dirtlist[Random.Range(blockamount/2,blockamount)];
            dirt.transform.GetChild(0).gameObject.SetActive(false);
            for(float i=0;i<ParameterManager.Instance.groundchangingTime;i++){
                dirt.transform.SetPositioinY(dirt.transform.position.y+ParameterManager.Instance.groundchangingUnit*i);
            }
        }   
        dirt.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log(dirt+"rised");
    }
    private void fall(GameObject dirt){
        dirt.transform.GetChild(0).gameObject.SetActive(false);
        for(float i=0;i<ParameterManager.Instance.groundchangingTime;i++){
            dirt.transform.SetPositioinY(dirt.transform.position.y-ParameterManager.Instance.groundchangingUnit*i);
        }
        dirt.transform.GetChild(0).gameObject.SetActive(true);
        if(dirt.transform.position.y<=-Screen.height/100){
            dirt.transform.GetChild(0).gameObject.SetActive(false);
        }
        Debug.Log(dirt+"falled");
    }
}
