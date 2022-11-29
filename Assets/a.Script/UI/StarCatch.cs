using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCatch : MonoBehaviour
{
    public delegate void OnSuccess();
    public delegate void OnFail();

    public Slider m_Slider;
    public float fSpeed = 1.0f;
    private bool m_bRight = true;

    private OnSuccess m_dOnSuccess = null;
    public void SetSuccessCallback(OnSuccess dOnSuccess) { 
        m_dOnSuccess = dOnSuccess; 
    }

    private OnFail m_dOnFail = null;
    public void SetFailCallback(OnFail dOnFail) { 
        m_dOnFail = dOnFail; 
    }

    static private StarCatch s_StarCatch = null;

    public RectTransform GoalSqr;

    public float SqrPosition;

    public bool h_Started = true;

    static public void StartGame(
        OnSuccess dOnSuccess = null,
        OnFail dOnFail = null)
    {

        if (s_StarCatch != null)
        {
            if (s_StarCatch.gameObject.activeSelf == false)
            {
                s_StarCatch.gameObject.SetActive(true);
                s_StarCatch.m_Slider.value = 0.0f;
                s_StarCatch.SetSuccessCallback(dOnSuccess);
                s_StarCatch.SetFailCallback(dOnFail);
            }
        }
    }

    void Start()
    {
        s_StarCatch = this;
        s_StarCatch.gameObject.SetActive(false);

        m_Slider.value = 0.0f;
    }

    private void OnDestroy()
    {
        s_StarCatch = null;
    }

    void Update()
    {
        if (h_Started == true)
        {
            SqrPosition = Random.Range(-500f, 501f);
            GoalSqr.anchoredPosition = new Vector3(SqrPosition, 0);
            h_Started = false;
        }

        float s_SqrPosition = (500f + SqrPosition) / 1000;

        if (m_bRight == true)
        {
            m_Slider.value += (Time.deltaTime * fSpeed);
            if (m_Slider.value >= 1.0f)
            {
                m_Slider.value = 1.0f;
                m_bRight = false;
            }
        }
        else
        {
            m_Slider.value -= (Time.deltaTime * fSpeed);
            if (m_Slider.value <= 0.0f)
            {
                m_Slider.value = 0.0f;
                m_bRight = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m_Slider.value > s_SqrPosition - 0.05f && m_Slider.value < s_SqrPosition + 0.05f)
            {
                if (m_dOnSuccess != null)
                {
                    m_dOnSuccess();
                }
            }
            else
            {
                if (m_dOnFail != null)
                    m_dOnFail();
            }
            h_Started = true;
            m_dOnSuccess = null;
            m_dOnFail = null;
            gameObject.SetActive(false);
        }
    }
}
