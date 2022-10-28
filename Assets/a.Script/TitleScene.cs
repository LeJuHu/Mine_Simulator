using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    [SerializeField]
    int SceneLevel;

    public void touchToStart(){
        SceneManager.LoadScene(SceneLevel);
    }
}
