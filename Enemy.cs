using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public DetectionZone detectionZone;
    public float moveSpeed = 500f;
    Rigidbody2D rb;
    Animator animator; 


    void FixedUpdate() {
        //If there are more than one objects in zone
        if(detectionZone.detectedObjs.Count > 0) {

            //Calculate direction to target object
            Vector2 direction = (detectionZone.detectedObjs[0].transform.position - transform.position).normalized;

            //Move towards detected object
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
    }

    public float Health {
        set {
            health = value;
            if (health <= 0) {
                Defeated();
            }
        } 
        get {
            return health;
        }
    }

    //Slime Health
    public float health = 1;

    private void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Defeated() {
       animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }

}