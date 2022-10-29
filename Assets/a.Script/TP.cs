using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TP : MonoBehaviour
{
    [SerializeField]
    int SceneLevel;

    [SerializeField]
    GameObject TP_UI;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TP_UI.SetActive(true);
        }
    }

    public void OnClickGo()
    {
        SceneManager.LoadScene(SceneLevel);
        PlayerInfo.GetInstance().SetHP(PlayerInfo.GetInstance().GetMaxHP());
        PlayerInfo.GetInstance().SetMP(PlayerInfo.GetInstance().GetMaxMP());
    }

    public void OnClickBack()
    {
        TP_UI.SetActive(false);
    }
}
