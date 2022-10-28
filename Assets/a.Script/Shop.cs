using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{ 
    public bool Equip;

    public void w_Gold(int w_Gold)
    {
        Equip = PlayerInfo.GetInstance().UseGold(w_Gold);
    }

    public void w_Exp(int w_Exp)
    {
        if (Equip == true)
        {
            PlayerInfo.GetInstance().AddMineExp(w_Exp);
        }
    }
}
