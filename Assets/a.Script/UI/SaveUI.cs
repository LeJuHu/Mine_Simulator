using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveUI : MonoBehaviour
{
    [SerializeField]
    GameObject Save_UI;

    public SaveLoad _save;

    void Start()
    {
        Save_UI.SetActive(false);
    }

    public void Save()
    {
        Save_UI.SetActive(false);
        _save.GameSave();
    }

    public void Back()
    {
        Save_UI.SetActive(false);
    }

    public void EndGame()
    {
        _save.GameSave();
        Application.Quit();
    }
}
