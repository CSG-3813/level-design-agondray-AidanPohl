using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject playerGO;
    public TextMeshProUGUI healthUI;
    private PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = playerGO.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.text = "Health: "+health.health.ToString()+"/"+health.maxHealth.ToString();
    }
}
