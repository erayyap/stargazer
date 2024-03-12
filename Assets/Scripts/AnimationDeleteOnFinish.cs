using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDeleteOnFinish : MonoBehaviour
{
    private Animator animator;
    private bool hasPlayed;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        hasPlayed = false;
    }

    void Update()
    {
        // Check if the animation has finished playing and the object hasn't been deleted yet
        if (!hasPlayed && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            hasPlayed = true;
            // Trigger object deletion
            Destroy(gameObject);
        }
    }

}
