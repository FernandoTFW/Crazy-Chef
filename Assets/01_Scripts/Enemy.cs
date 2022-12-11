using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 100;
    public float moveSpeed = 8;
    public float damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(float damage){
        hp -= damage;
        if(hp <= 0){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            Player p = other.gameObject.GetComponent<Player>();
            p.TakeDamage(damage);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            Player p = other.gameObject.GetComponent<Player>();
            p.TakeDamage(damage);
        }
    }

    
}