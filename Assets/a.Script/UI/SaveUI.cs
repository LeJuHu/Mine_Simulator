using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveUI : MonoBehaviour
{
    [SerializeField]
    GameObject Save_UI;

    [SerializeField]
    GameObject _SoundManager;

    void Start()
    {
        Save_UI.SetActive(false);
    }

    public void Save()
    {
        Save_UI.SetActive(false);
    }

    public void Sound()
    {
        _SoundManager.SetActive(true);
        Save_UI.SetActive(false);

    }

    public void Back()
    {
        Save_UI.SetActive(false);
    }

    public void EndGame()
    {
        Debug.Log("End Game.");
        Application.Quit();
    }
}
