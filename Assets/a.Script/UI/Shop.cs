using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    private int WeaponNum;

    private int _useGold;
    private int _addExp;
    GameObject _x;
    GameObject _b;



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

    public void x_Image(GameObject image){
        _x = image;
    }

    public void b_Button(GameObject _button){
        _b = _button;
    }

    public void w_Number(int _n){
        WeaponNum = _n;
    }

    public void ActiveBuy(){
        if(_buyButton.activeSelf == false){
            _buyButton.SetActive(true);
        }
    }

    public void Buy(){
        if(PlayerInfo.GetInstance().GetGold() > _useGold){
            _x.SetActive(true);
            _b.SetActive(false);
            PlayerInfo.GetInstance().PurchasedWeapon(WeaponNum);
            Gold.text = "Purchased";
            MineExp.text = "Purchased";
            PlayerInfo.GetInstance().UseGold(_useGold);
            PlayerInfo.GetInstance().AddMineExp(_addExp);
            _buyButton.SetActive(false);
        }
    }
}
