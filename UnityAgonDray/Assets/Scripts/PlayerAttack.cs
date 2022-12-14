using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Animator))]
public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public GameObject swordGO;
    private Collider swordCollider;
    public int damage = 1;
    public string attackAnimation;
    public float attackCooldown = 1f;
    private float attackTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        swordCollider = swordGO.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && attackTimer <= 0)
        {
            attackTimer = attackCooldown;
            animator.SetTrigger(attackAnimation);
            swordCollider.isTrigger = false;
            UnityEngine.Debug.Log("Sword Active");
            Invoke("SwordEnable", 2);

            
        }

        
    }

    void SwordEnable()
    {
        swordCollider.isTrigger = true;
        UnityEngine.Debug.Log("Sowrd Unactive");
    }
 
}
