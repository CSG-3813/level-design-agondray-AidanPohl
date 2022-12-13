using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class AnimationTriggerCollision : MonoBehaviour
{
    public Animator animator;
    public string targetTag;
    public string animParameter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            animator.SetBool(animParameter, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            animator.SetBool(animParameter, false);
        }
    }
}
