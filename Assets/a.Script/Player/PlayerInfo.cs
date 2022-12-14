using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    private static PlayerInfo s_PlayerInfo = null;

    public static PlayerInfo GetInstance()
    {

        if (s_PlayerInfo == null)
            s_PlayerInfo = new PlayerInfo();
        
        return s_PlayerInfo;
    }
    
    public PlayerInfo()
    {
        HP = MaxHP;
        MP = MaxMP;
    }

    private int Gold = 0;
    public void SetGold(int setgold){
        Gold = setgold;
    }
    public int GetGold() { return Gold; }
    public void AddGold(int addGold)
    {
        Gold += addGold;
        Debug.Log("Gold: " + GetGold());
    }

    public bool UseGold(int useGold)
    {
        if(Gold >= useGold) 
        {
            Gold -= useGold;
            return true;
        }
        return false;
    }

    //////////////////[ Level ]/////////////////////
    private int Exp = 0    ;
    public int GetExp() { return Exp; }
    public int GetMaxExp() { return MaxExp; }
    public void SetExp(int setexp) {
        Exp = setexp;
    }
    public void SetMaxExp(int setmaxexp)
    {
        MaxExp = setmaxexp;
    }


    public int GetLevel() { return Level; }
    public void SetLevel(int setlevel)
    {
        Level = setlevel;
    }
    public void AddExp(int addExp) 
    { 
        Exp += addExp;
        while(Exp > MaxExp){
            LevelUP();
        }
    }

    public void MinExp(){
        Exp = 0;
        LevelDown();
    }

    private int MaxExp = 500;

    private int Level = 1;

    public void LevelUP()
    {
        if(Exp >= MaxExp)
        {
            Level += 1;

            Exp -= MaxExp;

            MaxExp *= 2;
            
            UpdateMaxHP();
        }
    }

    public void LevelDown()
    {
        if (Exp == 0)
        {
            if (Level > 1)
            {
                Level -= 1;
                MaxExp /= 2;
                Exp = (int)(MaxExp * 0.7) ;
                UpdateMaxHP();
            }
        }
    }

    //////////////////[ HP ]//////////////////

    private float DefaultMaxHP = 100;
    private float HP = 0;
    private float MaxHP = 100;
    public float GetMaxHP() { return MaxHP; }
    public void SetHP(float sethp)
    {
        HP = sethp;
    }
    public void SetMaxHP(float setmaxhp)
    {
        MaxHP = setmaxhp;
    }

    public void UpdateMaxHP()
    {
        MaxHP = DefaultMaxHP * Level;
    }
    public void MinusHP(float minusHP)
    {
        HP -= minusHP;
        HP = Mathf.Max(0, HP);
        if(HP == 0)
        {
            LevelDown();
        }
    }
    public float GetHP() { return HP; }
/*
    public void SetHP(float s_HP)
    {
        HP = s_HP;
    }*/

    //////////////////[ Mine Level ]/////////////////////
    private float MineExp = 0;
    public float GetMineExp() { return MineExp; }
    public void SetMineExp(float setmineexp)
    {
        MineExp = setmineexp;
    }
    
    public void AddMineExp(float addMineExp)
    {
        MineExp += addMineExp;
        while (MineExp > MaxMineExp){
            MineLevelUP();
        }
    }

    private float MaxMineExp = 1000;
    public float GetMaxMineExp() { return MaxMineExp; }
    public void SetMaxMineExp(float setmaxmineexp)
    {
        MaxMineExp = setmaxmineexp;
    }

    private float MineLevel = 1;
    public float GetMineLevel() { return MineLevel; }
    public void SetMineLevel(float setminelevel)
    {
        MineLevel = setminelevel;
    }

    public void MineLevelUP()
    {
        if(MineExp >= MaxMineExp)
        {
            MineLevel += 1;

            MineExp -= MaxMineExp;

            MaxMineExp *= 2;
            
            UpdateMaxMP();
        }
    }

    private float DefaultMaxMP = 100;
    private float MaxMP = 100;
    private float MP = 0;
    public float GetMaxMP() { return MaxMP; }
    public float GetMP() { return MP; }
    public void SetMP(float setmp)
    {
        MP = setmp;
    }
    public void SetMaxMP(float setmaxmp)
    {
        MaxMP = setmaxmp;
    }

    public void UpdateMaxMP()
    {
        MaxMP = DefaultMaxMP * MineLevel;
        MP = MaxMP;
    }

    public void MinusMP(float minusMP)
    {
        MP -= minusMP;
        MP = Mathf.Max(0, MP);
    }

    /////////////[Weapon]/////////////
    List<int> Equiplist = new List<int>();

    public List<int> GetEquipList() { return Equiplist; }

    public void PurchasedWeapon(int WeaponNumber){
        Equiplist.Add(WeaponNumber);
    }

    public bool EquipWeapon(int w_Number){
        if(Equiplist.Contains(w_Number)){
            return true;
        }
        return false;
    }
}
