using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSword : MonoBehaviour
{
    public GameObject animatorGO;
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = animatorGO.GetComponent<Animator>();
        animator.SetBool("Has Sword", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
