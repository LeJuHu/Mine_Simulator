using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCtr : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isMiningHash;

    [SerializeField]
    GameObject MineCollider;

    void Start()
    {
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isMiningHash = Animator.StringToHash("isMining");
    }

    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isMining = animator.GetBool(isMiningHash);
        bool MovePressed = Input.GetKey("w") | Input.GetKey("a") | Input.GetKey("s") | Input.GetKey("d");
        bool MinePressed = Input.GetKey("e");

        if(!isWalking && MovePressed)
        {
            animator.SetBool("isWalking", true);
        }

        if (isWalking && !MovePressed)
        {
            animator.SetBool("isWalking", false);
        }

        if( !isMining && MinePressed)
        {
            animator.SetBool("isMining", true);
        }

        if (isMining && !MinePressed)
        {
            animator.SetBool("isMining", false);
        }
    }

    void ActivateCollider()
    {
        MineCollider.SetActive(true);
    }

    void DeactivateCollider()
    {
        MineCollider.SetActive(false);
    }
}
