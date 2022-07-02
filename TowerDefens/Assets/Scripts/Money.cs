using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int playermoney = 30;

    public void GetMoneyPlayer(int money)
    {
        playermoney = playermoney + money;
        
    }

    public int GetMoney()
    {
        return playermoney; 
    }

}
