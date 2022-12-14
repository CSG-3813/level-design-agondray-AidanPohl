using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnim : MonoBehaviour
{
    public GameObject animatorGO;
    private Animator animator;
    public string animParameter;
    // Start is called before the first frame update
    void Awake()
    {
        animator = animatorGO.GetComponent<Animator>();
        animator.SetBool(animParameter, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
