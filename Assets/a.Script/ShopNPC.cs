using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour
    
{
    [SerializeField]
    GameObject Interact_UI;

    [SerializeField]
    GameObject Shop_UI;

    [SerializeField]
    PlayerManager _playerManager;

    void Start()
    {

    }

    void Update()
    {
        ShopUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interact")
        {
            Interact_UI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interact_UI.SetActive(false);
        Shop_UI.SetActive(false);
    }

    private void ShopUI()
    {
        if (Interact_UI.activeSelf == true)
        {
            if (_playerManager.IsInteracting())
                Shop_UI.SetActive(!Shop_UI.activeSelf);
        }
    }
}
