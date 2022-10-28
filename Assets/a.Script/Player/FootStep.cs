using UnityEngine;

public class FootStep : MonoBehaviour
{
    public AudioSource footStepSound;

    private void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            footStepSound.enabled = true;
        }
        else
        {
            footStepSound.enabled = false;
        }
        
    }
}
