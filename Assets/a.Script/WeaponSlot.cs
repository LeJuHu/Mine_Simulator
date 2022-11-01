using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public int Number;
    
    [SerializeField]
    GameObject N;
    [SerializeField]
    GameObject NX;

    private void Start()
    {
        Equipedlist();
    }

    public void WeaponNumber(int w_num){
        Number = w_num;
    }

    public void Equipedlist()
    {
        if (PlayerInfo.GetInstance().EquipWeapon(Number) == true)
        {
            N.SetActive(false);
            NX.SetActive(true);
        }
        else{
            N.SetActive(true);
            NX.SetActive(false);
        }
    }
    
}
