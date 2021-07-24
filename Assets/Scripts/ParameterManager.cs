using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterManager : MonoBehaviour
{
    public static ParameterManager Instance; // 設定這邊的數值為全域變數
    public int planes; //一個玩家要幾個地板
    public float planespeed; //地板沉下去的速度
    public float playerSpeed; //玩家移動速度 
    public float playerJumpVelocity; //玩家跳的力氣
    public float TimeCount; // 時間倒數計時
    public float groundchangingTime; //一次地形改變總時長
    public int startblockamount; //起始地形高度，每個的高度隨機分配 
    public List<GameObject> dirtlist; //條狀板塊的傳參照

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

}
