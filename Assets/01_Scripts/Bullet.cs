using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public float damage = 10;
    public float timeToDestroy = 10;
    //public AudioClip Sound;
    // Start is called before the first frame update
    void Start()
    {
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
            Enemy e = other.gameObject.GetComponent<Enemy>();
            e.TakeDamage(damage);
            Debug.Log("enemigo dañado");
            Destroyer();
        }
    }

    void Destroyer()
    {
        //GameManager.instance.PlaySFX(Sound);
        //Instantiate(explosionEffect, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
        Destroy(gameObject);
    }
}
