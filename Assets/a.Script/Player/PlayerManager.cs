using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool IsInteracting()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            return true;
        }

        return false;
    }
}
