using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{   
    //Strength of Sword
    public float damage = 3; 
    Vector2 rightAttackOffset;
    public Collider2D swordCollider;

    private void Start() {
        rightAttackOffset = transform.position;
    }

    //Flipping side to right
    public void AttackRight() {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }


    //Flipping side to left
    public void AttackLeft() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    //Ending animation
    public void StopAttack() {
        swordCollider.enabled=false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            //Deal damage to the enemy
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null) {
                enemy.Health -= damage;
            }
        }
    }

}
