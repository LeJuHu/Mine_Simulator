using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    [SerializeField]
    GameObject _player;

    private static bool s_loadedFirstTime = false;

    private Scene _scene;

    void Start()
    {
        if ( s_loadedFirstTime  == false )
        {
            GameLoad();
            s_loadedFirstTime = true;
            if (SceneManager.GetActiveScene().name == PlayerPrefs.GetString("Scene",""))
            {
                _player.transform.position
                = new Vector3(PlayerPrefs.GetFloat("PlayerX"),
                PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
            }
        }
    }

    public void GameSave()
    {
        _scene = SceneManager.GetActiveScene();

        PlayerPrefs.SetString("Scene", _scene.name);

        PlayerPrefs.SetInt("EquipList", PlayerInfo.GetInstance().GetEquipList().Count);

        for (int i = 0; i < PlayerInfo.GetInstance().GetEquipList().Count; i++)
            PlayerPrefs.SetInt("Equip" + i, PlayerInfo.GetInstance().GetEquipList()[i]);

        PlayerPrefs.SetInt("Gold", PlayerInfo.GetInstance().GetGold());
        PlayerPrefs.SetFloat("HP", PlayerInfo.GetInstance().GetHP());
        PlayerPrefs.SetFloat("MaxHP", PlayerInfo.GetInstance().GetMaxHP());
        PlayerPrefs.SetFloat("MP", PlayerInfo.GetInstance().GetMP());
        PlayerPrefs.SetFloat("MaxMP", PlayerInfo.GetInstance().GetMaxMP());
        PlayerPrefs.SetInt("Level", PlayerInfo.GetInstance().GetLevel());
        PlayerPrefs.SetInt("Exp", PlayerInfo.GetInstance().GetExp());
        PlayerPrefs.SetInt("MaxExp", PlayerInfo.GetInstance().GetMaxExp());
        PlayerPrefs.SetFloat("MineExp", PlayerInfo.GetInstance().GetMineExp());
        PlayerPrefs.SetFloat("MaxMineExp", PlayerInfo.GetInstance().GetMaxMineExp());
        PlayerPrefs.SetFloat("MineLevel", PlayerInfo.GetInstance().GetMineLevel());

        //player.x, player.y
        PlayerPrefs.SetFloat("PlayerX", _player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", _player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", _player.transform.position.z);

        PlayerPrefs.Save();
    }

    public void GameLoad()
    {
        if (PlayerPrefs.HasKey("Gold"))
        {
            int equipCount = PlayerPrefs.GetInt("EquipList", 0);
            for ( int i = 0; i < equipCount; i++ )
            {
                int weaponNum = PlayerPrefs.GetInt("Equip" + i, -1);
                if ( weaponNum != -1)
                    PlayerInfo.GetInstance().PurchasedWeapon(weaponNum);
            } 
            

            PlayerInfo.GetInstance().SetGold(PlayerPrefs.GetInt("Gold") );
            PlayerInfo.GetInstance().SetHP(PlayerPrefs.GetFloat("HP"));
            PlayerInfo.GetInstance().SetMaxHP(PlayerPrefs.GetFloat("MaxHP"));
            PlayerInfo.GetInstance().SetMP(PlayerPrefs.GetFloat("MP"));
            PlayerInfo.GetInstance().SetMaxMP(PlayerPrefs.GetFloat("MaxMP"));
            PlayerInfo.GetInstance().SetLevel(PlayerPrefs.GetInt("Level"));
            PlayerInfo.GetInstance().SetExp(PlayerPrefs.GetInt("Exp"));
            PlayerInfo.GetInstance().SetMaxExp(PlayerPrefs.GetInt("MaxExp"));
            PlayerInfo.GetInstance().SetMineExp(PlayerPrefs.GetFloat("MineExp"));
            PlayerInfo.GetInstance().SetMaxMineExp(PlayerPrefs.GetFloat("MaxMineExp"));
            PlayerInfo.GetInstance().SetMineLevel(PlayerPrefs.GetFloat("MineLevel"));
        }
    }
}
