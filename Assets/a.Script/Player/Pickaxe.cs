using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    [SerializeField]
    GameObject woodPickaxe;
    [SerializeField]
    GameObject stonePickaxe;
    [SerializeField]
    GameObject metalPickaxe;
    [SerializeField]
    GameObject goldPickaxe;
    [SerializeField]
    GameObject diamondPickaxe;

    private int startLevel = 0;
    public int woodLevel = 2;
    public int stoneLevel = 10;
    public int metalLevel = 15;
    public int goldLevel = 20;

    float nowMineLevel;

    private void Update() {
        equipPickaxe();
    }

    void equipPickaxe(){
        nowMineLevel = PlayerInfo.GetInstance().GetMineLevel();

        if(startLevel < nowMineLevel && nowMineLevel <= woodLevel){
            woodPickaxe.SetActive(true);
        }
        else if(woodLevel < nowMineLevel && nowMineLevel <= stoneLevel){
            if(woodPickaxe.activeSelf == true){
                woodPickaxe.SetActive(false);
            }
            stonePickaxe.SetActive(true);
        }
        else if (stoneLevel < nowMineLevel && nowMineLevel <= metalLevel)
        {
            if (stonePickaxe.activeSelf == true)
            {
                stonePickaxe.SetActive(false);
            }
            metalPickaxe.SetActive(true);
        }
        else if (metalLevel < nowMineLevel && nowMineLevel <= goldLevel)
        {
            if (metalPickaxe.activeSelf == true)
            {
                metalPickaxe.SetActive(false);
            }
            goldPickaxe.SetActive(true);
        }
        else if (goldLevel < nowMineLevel)
        {
            if (goldPickaxe.activeSelf == true)
            {
                goldPickaxe.SetActive(false);
            }
            diamondPickaxe.SetActive(true);
        }
    }
}
