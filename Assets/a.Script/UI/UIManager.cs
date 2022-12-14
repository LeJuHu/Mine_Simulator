using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public Slider Exp_Bar;
    [SerializeField]
    public Slider HP_Bar;
    [SerializeField]
    public Slider MP_Bar;
    [SerializeField]
    public Slider MP_EXP_Bar;

    [SerializeField]
    TextMeshProUGUI Level;
    [SerializeField]
    TextMeshProUGUI MineLevel;

    [SerializeField]
    public Button LVButton;
    [SerializeField]
    GameObject LevelObj;
    [SerializeField]
    GameObject MineLevelObj;

    [SerializeField]
    TextMeshProUGUI Gold;

    [SerializeField]
    GameObject Save_UI;

    [SerializeField]
    GameObject _shop_ui;

    [SerializeField]
    TP _tp;

    [SerializeField]
    GameObject Status_UI;
    
    [SerializeField]
    AudioSource SoundEffect;

    void Update()
    {
        EXP_UI();
        HP_UI();
        MP_UI();
        Level_UI();
        MP_EXP_UI();
        MineLV_UI();
        Gold_UI();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_shop_ui.activeSelf == false && _tp._active == false){
                Save_UI.SetActive(true);
                SoundEffect.Play();
            }
        }
        if(Status_UI.activeSelf == false){
            if (Input.GetKeyDown(KeyCode.Tab)){
                Status_UI.SetActive(true);
                SoundEffect.Play();
            }
        }
        else{
            if (Input.GetKeyDown(KeyCode.Tab)){
                Status_UI.SetActive(false);
                SoundEffect.Play();
            }
        }
    }

    private void EXP_UI()
    {
        Exp_Bar.value = (float)(PlayerInfo.GetInstance().GetExp()) / (float)(PlayerInfo.GetInstance().GetMaxExp());
    }

    private void HP_UI()
    {
        HP_Bar.value = (PlayerInfo.GetInstance().GetHP()) / (PlayerInfo.GetInstance().GetMaxHP());
    }

    private void MP_UI()
    {
        MP_Bar.value = (PlayerInfo.GetInstance().GetMP()) / (PlayerInfo.GetInstance().GetMaxMP());
    }

    private void MP_EXP_UI()
    {
        MP_EXP_Bar.value = (PlayerInfo.GetInstance().GetMineExp()) / (PlayerInfo.GetInstance().GetMaxMineExp());
    }

    private void Level_UI()
    {
        Level.text = PlayerInfo.GetInstance().GetLevel().ToString();
    }

    private void MineLV_UI()
    {
        MineLevel.text = PlayerInfo.GetInstance().GetMineLevel().ToString();
    }

    public void LVUI_Change()
    {
        if(LevelObj.activeSelf == true)
        {
            LevelObj.SetActive(false);
            MineLevelObj.SetActive(true);
        }
        else
        {
            MineLevelObj.SetActive(false);
            LevelObj.SetActive(true);
        }
    }

    public void Gold_UI()
    {
        Gold.text = PlayerInfo.GetInstance().GetGold().ToString();
    }
}
