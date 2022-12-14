using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Hitbox : MonoBehaviour
{
    public GameObject mainGO;
    public string targetTag;
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
        Debug.Log("Ping");
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Oof");
            mainGO.GetComponent<EnemyMovementAndAttack>().TakeDamage();
        }
    }
}
