/**
 * Created by: Aidan Pohl
 * Created on: December 11, 2022
 * 
 * Edited By: N/A
 * Edited on: N/A
 * 
 * Descritpion: Handles Naviagation and attacking by Enemies
 */
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Animator))]
public class EnemyMovementAndAttack : MonoBehaviour
{
    [Header("Animation")]
    public Animator animator;
    public string runAnimation;
    public string attackAnimation;
    public string damageAnimation;
    public string deathAnimation;
    [Header("Navigation")]
    private NavMeshAgent thisAgent;
    public Transform destination;
    public Transform spawn;
    [Header("SightLine")]
    public Transform eyePoint;
    public string targetTag = "Player";
    public float fieldOfView = 45f;
    [SerializeField] bool isTargetInSight = false;
    public Vector3 lastKnownSighting { get; set; } = Vector3.zero;
    private SphereCollider sightBubble;
    [Header("Combat")]
    public int health = 5;
    public float damageCooldown = 2;
    public float damageTimer=0;
    public string weaponTag;
    private LayerMask sightMask; 
    

    private void Awake()
    {
        sightMask = 4;
        sightMask = ~sightMask;
        thisAgent = GetComponent<NavMeshAgent>();
        sightBubble = GetComponent<SphereCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(runAnimation, !thisAgent.isStopped);
        damageTimer -= Time.deltaTime;

    }

    public void OnTriggerStay(Collider other)
    {
        //Debug.Log("Something in Range");
        if (other.CompareTag(targetTag))
        {
            //Debug.Log(other.gameObject.name + " in Range of "+this.gameObject.name);
            //Debug.Log(other.transform.position);
            UpdateSight(other.transform);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            isTargetInSight = false;
        }
    }

    public void UpdateSight(Transform target)
    {
        isTargetInSight = ClearLineOfSight(target) && TargetInFOV(target);
        if (isTargetInSight)
        {
            //Debug.Log("PlayerSighted");
            lastKnownSighting = target.position;
            thisAgent.SetDestination(lastKnownSighting); //updates where the agent wants to go;
        }
        else
        {
            thisAgent.SetDestination(destination.position);
        }
    }

    private bool TargetInFOV(Transform target)
    {
        Vector3 directionToTarget = target.position - eyePoint.position;
        float angle = Vector3.Angle(eyePoint.forward, directionToTarget);
        if (angle <= fieldOfView)
        {
            //Debug.Log("Target in FOV");
            return true;
        }
        else
        {
            return false;
        }
    }//end TargetInFOV(Transform)

    private bool ClearLineOfSight(Transform target)
    { //Debug.Log("Updating sight of " +this.gameObject.name);
        RaycastHit hit;
        Vector3 targetcenter = target.position;
        //targetcenter.y += 1;
        Vector3 dirToTarget = (targetcenter - eyePoint.position).normalized;
        if (Physics.Raycast(eyePoint.position, dirToTarget, out hit, sightBubble.radius))
        {
            Debug.DrawLine(eyePoint.position, hit.point);
            //Debug.Log("Hit " + hit.transform.gameObject.name);
            if (hit.transform.CompareTag(targetTag))
            {
                //Debug.Log("TARGET FOUND!!");
                return true;
            }
        }
        return false;
    }

public void TakeDamage()
    {
        Debug.Log(this.gameObject.name + " was hurt!");
        if (damageTimer <= 0)
        {
            health--;
            damageTimer = damageCooldown;
            if (health <= 0)
            {
                animator.SetTrigger("Die");
                Invoke("Death", 2);
            }
            else { animator.SetTrigger("Take Damage"); }
        }
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}


