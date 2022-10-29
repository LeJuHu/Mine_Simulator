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
    int AddExp = 100;
    [SerializeField]
    int AddGold = 1000;
    [SerializeField]
    int minusMP = 20;
    [SerializeField]
    AudioSource MiningSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (Ore1.activeSelf == true)
        {
            if (other.gameObject.tag == "Mining")
            {
                MiningSFX.time = 0.2f;
                MiningSFX.enabled = true;
                StarCatch.StartGame(Success, Fail);
                Ore1.SetActive(false);
                Ore2.SetActive(true);
            }
        }
    }

    private void Success()
    {
        PlayerInfo.GetInstance().AddExp(AddExp);
        PlayerInfo.GetInstance().AddGold(AddGold);
        EarnUI.GetInstance().Show(AddExp, AddGold);
        PlayerInfo.GetInstance().MinusMP(minusMP);
    }

    private void Fail()
    {
        PlayerInfo.GetInstance().AddExp(AddExp / 3);
        PlayerInfo.GetInstance().AddGold(AddGold / 3);
        EarnUI.GetInstance().Show(AddExp / 3, AddGold / 3);
        PlayerInfo.GetInstance().MinusMP(minusMP);
    }
}