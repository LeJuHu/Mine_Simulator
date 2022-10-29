using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    GameObject Title;
    [SerializeField]
    GameObject NewLoad;

    [SerializeField]
    private int SceneN;

    public void TouchTostart(){
        SceneManager.LoadScene(SceneN);
    }

    public void TitleTouch(){
        NewLoad.SetActive(true);
        Title.SetActive(false);
    }

    public void Back(){

    }
}
