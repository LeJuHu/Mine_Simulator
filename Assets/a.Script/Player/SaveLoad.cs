using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [SerializeField]
    GameObject _player;

    private static bool s_loadedFirstTime = false;

    private static SaveLoad _sl = null;

    public static SaveLoad GetInstance()
    {

        if (_sl == null)
            _sl = new SaveLoad();

        return _sl;
    }


    void Start()
    {
        if ( s_loadedFirstTime  == false )
        {
            GameLoad();
            s_loadedFirstTime = true;
        }
        
    }

    public void GameSave()
    {
        //Gold = PlayerInfo.GetInstance().GetGold();
        /*
        HP = PlayerInfo.GetInstance().GetHP();
        MaxHP = PlayerInfo.GetInstance().GetMaxHP();
        MP = PlayerInfo.GetInstance().GetMP();
        MaxMP = PlayerInfo.GetInstance().GetMaxMP();
        Level = PlayerInfo.GetInstance().GetLevel();
        Exp = PlayerInfo.GetInstance().GetExp();
        MaxExp = PlayerInfo.GetInstance().GetMaxExp();
        MineExp = PlayerInfo.GetInstance().GetMineExp();
        MaxMineExp = PlayerInfo.GetInstance().GetMaxMineExp();
        MineLevel = PlayerInfo.GetInstance().GetMineLevel();*/

        PlayerPrefs.SetInt("Gold", PlayerInfo.GetInstance().GetGold());
        /*
        PlayerPrefs.SetFloat("HP", HP);
        PlayerPrefs.SetFloat("MaxHP", MaxHP);
        PlayerPrefs.SetFloat("MP", MP);
        PlayerPrefs.SetFloat("MaxMP", MaxMP);
        PlayerPrefs.SetInt("Level", Level);
        PlayerPrefs.SetInt("Exp", Exp);
        PlayerPrefs.SetInt("MaxExp", MaxExp);
        PlayerPrefs.SetFloat("MineExp", MineExp);
        PlayerPrefs.SetFloat("MaxMineExp", MaxMineExp);
        PlayerPrefs.SetFloat("MineLevel", MineLevel);

        //player.x, player.y
        PlayerPrefs.SetFloat("PlayerX", _player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", _player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", _player.transform.position.z);*/

        PlayerPrefs.Save();
    }

    public void GameLoad()
    {
        if (PlayerPrefs.HasKey("Gold"))
        {
            PlayerInfo.GetInstance().SetGold( PlayerPrefs.GetInt("Gold") );
            /*
            HP = PlayerPrefs.GetFloat("HP");
            MaxHP = PlayerPrefs.GetFloat("MaxHP");
            MP = PlayerPrefs.GetFloat("MP");
            MaxMP = PlayerPrefs.GetFloat("MaxMP");
            Level = PlayerPrefs.GetInt("Level");
            Exp = PlayerPrefs.GetInt("Exp");
            MaxExp = PlayerPrefs.GetInt("MaxExp");
            MineExp = PlayerPrefs.GetFloat("MineExp");
            MaxMineExp = PlayerPrefs.GetFloat("MaxMineExp");
            MineLevel = PlayerPrefs.GetFloat("MineLevel");

            _player.transform.position = new Vector3(x, y, z);*/
        }
    }
}
