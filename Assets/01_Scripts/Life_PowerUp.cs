using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_PowerUp : MonoBehaviour
{
    public AudioClip sound;
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
            Debug.Log("Life powerUp active");
            if(Player.hp < 100){
                Player.hp += 10;
                GameManager.instance.PlaySFX(sound);
                if (Player.hp > 100)
                Player.hp = 100;
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
