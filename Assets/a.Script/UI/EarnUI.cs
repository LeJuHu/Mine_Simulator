using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EarnUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI e_Gold;
    [SerializeField]
    TextMeshProUGUI e_Exp;

    float _time;

    private static EarnUI s_EarnUI = null;

    public static EarnUI GetInstance()
    {
        return s_EarnUI;
    }

    void Start()
    {
        gameObject.SetActive(false);
        s_EarnUI = this;
    }

    private void OnDestroy()
    {
        s_EarnUI = null;
    }

    void Update()
    {
        Invisable();
    }

    public void Show(int exp, int gold)
    {
        e_Gold.text = "+ " + gold.ToString() + "G";
        e_Exp.text = "+ " + exp.ToString() + "exp";

        gameObject.SetActive(true);
        _time = Time.time;
    }

    public void Invisable()
    {
        if (gameObject.activeSelf == true)
        {
            if (_time + 3 < Time.time)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
