using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float damage = 10;
    public float timeToDestroy = 10;
    public GameObject expEffect;
    public AudioClip explosionEffect;

    void Start()
    {
        damage *= Dificulty.damageMultiplier;
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Instantiate(expEffect, transform.position, transform.rotation);
            
            Enemy e = other.gameObject.GetComponent<Enemy>();
            e.TakeDamage(damage);
            Debug.Log("enemigo dañado");
            Scoring.AddScore(1);

            Destroyer();
        }else if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroyer();
        }
    }

    void Destroyer()
    {
        GameManager.instance.PlaySFX(explosionEffect);
        Destroy(gameObject);
    }
}
