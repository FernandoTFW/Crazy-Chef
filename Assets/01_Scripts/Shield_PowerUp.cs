using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_PowerUp : MonoBehaviour
{
    public AudioClip sound;
    public static bool shieldOn = false;
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
            GameManager.instance.PlaySFX(sound);
            shieldOn = true;
            if (Player.shield_PowerUp < 5){
                Player.shield_PowerUp = 5;
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
