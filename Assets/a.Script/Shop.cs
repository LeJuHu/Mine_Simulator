using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{ 
    [SerializeField]
    TextMeshProUGUI Gold;

    [SerializeField]
    TextMeshProUGUI MineExp;

    [SerializeField]
    GameObject ShopCanvas;

    [SerializeField]
    GameObject _buyButton;

    private string Name;

    private int _useGold;
    private int _addExp;

    public void WeaponGold(int _gold)
    {
        Gold.text = _gold.ToString();
        _useGold = _gold;
    }

    public void WeaponExp(int _mineExp)
    {
        MineExp.text = "+ " + _mineExp.ToString();
        _addExp = _mineExp;
    }

    public void WeaponName(string _weaponName){
        Name = _weaponName;
    }

    public void ActiveBuy(){
        if(_buyButton.activeSelf == false){
            _buyButton.SetActive(true);
        }
    }

    public void Buy(){
        ((ShopCanvas.transform.Find(Name).gameObject).transform.Find("X").gameObject).SetActive(true);
        Gold.text = "Purchased";
        MineExp.text = "Purchased";
        PlayerInfo.GetInstance().UseGold(_useGold);
        PlayerInfo.GetInstance().AddMineExp(_addExp);
        _buyButton.SetActive(false);
    }

    

    /*
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
    }*/
}
