using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if(!Player.doubleAttack){
                Player.doubleAttack = true;
                Debug.Log("Bullet powerUp active");
            }
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
