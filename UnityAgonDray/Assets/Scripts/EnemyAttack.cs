using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class EnemyAttack : MonoBehaviour
{
    public GameObject animatorGO;
    private Animator animator;
    public string playerTag;
    public int attack = 1;
    public float attackCooldown = 5;
    private float attackTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = animatorGO.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(playerTag) && attackTimer <=0)
        {
            animator.SetTrigger("Attack 01");
            other.gameObject.GetComponent<PlayerHealth>().Damage(attack);
        }
    }


}
