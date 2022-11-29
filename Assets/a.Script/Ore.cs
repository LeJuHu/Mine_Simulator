using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    [SerializeField]
    GameObject Ore1;
    [SerializeField]
    GameObject Ore2;
    [SerializeField]
    int AddExp;
    [SerializeField]
    int AddGold;
    [SerializeField]
    int minusMP;
    [SerializeField]
    AudioSource MiningSFX;
    
    private void OnTriggerEnter(Collider other)
    {
        if (Ore1.activeSelf == true)
        {
            if( PlayerInfo.GetInstance().GetMP() != 0){
                if (other.gameObject.tag == "Mining")
                {
                    MiningSFX.time = 0.2f;
                    MiningSFX.enabled = true;
                    StarCatch.StartGame(Success,Fail);
                    Ore1.SetActive(false);
                    Ore2.SetActive(true);
                }
            }
        }
    }

    private void Success()
    {
        int Exp = Random.Range(AddExp/2, AddExp*2);
        int Gold = Random.Range(AddGold / 2, AddGold * 2);
        int m_MP = Random.Range(minusMP / 2, minusMP * 2);

        PlayerInfo.GetInstance().AddExp(Exp);
        PlayerInfo.GetInstance().AddGold(Gold);
        EarnUI.GetInstance().Show(Exp, Gold);
        PlayerInfo.GetInstance().MinusMP(m_MP);
    }

    private void Fail()
    {
        PlayerInfo.GetInstance().AddExp(AddExp / 4);
        PlayerInfo.GetInstance().AddGold(AddGold / 4);
        EarnUI.GetInstance().Show(AddExp / 4, AddGold / 4);
        PlayerInfo.GetInstance().MinusMP(minusMP);
    }
}