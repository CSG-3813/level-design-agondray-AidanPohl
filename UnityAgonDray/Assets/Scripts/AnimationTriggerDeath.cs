using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class AnimationTriggerDeath : MonoBehaviour
{
    public Animator animator;
    public string targetTag;
    public GameObject targetEnemy;
    public string animParameterTrigger;
    public string animParameterDeath;
    public GameObject collisionGO;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy.GetComponent<EnemyManager>().health <= 0)
            animator.SetBool(animParameterDeath, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            animator.SetTrigger(animParameterTrigger);
            collisionGO.SetActive(false);
        }
    }


}
