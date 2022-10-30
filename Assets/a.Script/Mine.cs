using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class Mine : MonoBehaviour
{
    [SerializeField]
    public float MinHP;

    [SerializeField]
    int SceneLevel;

    void Update()
    {
        DecreaseHP();
        if(PlayerInfo.GetInstance().GetHP() == 0)
        {
            PlayerDeath();
        }
    }

    private void DecreaseHP()
    {
        PlayerInfo.GetInstance().MinusHP(MinHP * Time.deltaTime);
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneLevel);
        PlayerInfo.GetInstance().SetHP(PlayerInfo.GetInstance().GetMaxHP());
        PlayerInfo.GetInstance().SetMP(PlayerInfo.GetInstance().GetMaxMP());
        PlayerInfo.GetInstance().MinExp();
    }
}
