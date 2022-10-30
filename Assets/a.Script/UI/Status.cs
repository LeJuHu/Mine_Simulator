using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Status : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI MaxHP;
    [SerializeField]
    TextMeshProUGUI MaxMP;
    [SerializeField]
    TextMeshProUGUI MaxMineExp;
    [SerializeField]
    TextMeshProUGUI MaxExp;

    void Update()
    {
        HPStatus();
        MPStatus();
        MineExpStatus();
        ExpStatus();
    }

    public void HPStatus(){
        
        MaxHP.text = ((int)PlayerInfo.GetInstance().GetHP() + 1).ToString() + " / " + (PlayerInfo.GetInstance().GetMaxHP()).ToString();
    }

    public void MPStatus(){
        MaxMP.text = (PlayerInfo.GetInstance().GetMP()).ToString() + " / " + (PlayerInfo.GetInstance().GetMaxMP()).ToString();
    }
    
    public void MineExpStatus(){
        MaxMineExp.text = (PlayerInfo.GetInstance().GetMineExp()).ToString() + " / " + (PlayerInfo.GetInstance().GetMaxMineExp()).ToString();
    }

    public void ExpStatus(){
        MaxExp.text = (PlayerInfo.GetInstance().GetExp()).ToString() + " / " + (PlayerInfo.GetInstance().GetMaxExp()).ToString();
    }
}
