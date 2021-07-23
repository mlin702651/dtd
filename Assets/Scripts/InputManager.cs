using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance; // 設定這邊的數值為全域變數
    public int planes; //一個玩家要幾個地板
    public float planespeed; //地板沉下去的速度
    public float playerSpeed; //玩家移動速度 

}
