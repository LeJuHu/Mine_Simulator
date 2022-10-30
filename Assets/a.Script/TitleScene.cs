using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    GameObject Title;
    [SerializeField]
    GameObject NewLoad; 
    [SerializeField]
    TextMeshProUGUI Level;
    [SerializeField]
    TextMeshProUGUI MineLevel;
    [SerializeField]
    TextMeshProUGUI Gold;
    [SerializeField]
    public int _scene;

    private void Start() {
        LevelText();
        MineLevelText();
        GoldText();
    }

    public void TitleTouch(){
        NewLoad.SetActive(true);
        Title.SetActive(false);
    }

    public void Back(){
        Title.SetActive(true);
        NewLoad.SetActive(false);
    }

    public void LevelText(){
        if(PlayerPrefs.HasKey("Level")){
            Level.text = "Level: " + (PlayerPrefs.GetInt("Level")).ToString();
        }
        else{
            Level.text = "New Game";
        }
    }

    public void MineLevelText(){
        if (PlayerPrefs.HasKey("MineLevel")){
            MineLevel.text = "MineLevel: " + (PlayerPrefs.GetFloat("MineLevel")).ToString();
        }
        else{
            MineLevel.text = "New Game";
        }
    }

    public void GoldText(){
        if (PlayerPrefs.HasKey("Gold")){
            Gold.text = "Gold: " + (PlayerPrefs.GetInt("Gold")).ToString();
        }
        else{
            Gold.text = "New Game";
        }
    }

    public void GameStart(){
        if(PlayerPrefs.HasKey("Gold")){
            SceneManager.LoadScene(PlayerPrefs.GetString("Scene"));
        }

        else{
            SceneManager.LoadScene(_scene);
        }
    }

    public void Erase(){
        PlayerPrefs.DeleteAll();
        LevelText();
        MineLevelText();
        GoldText();
    }
}
