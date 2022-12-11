using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : MonoBehaviour
{
    public GameObject spawnEffect;
    public List<GameObject> patternEnemies;
    public Transform spawnPoint;
    public bool canSpawn = false;
    public float timer = 0;
    public float timerSpawn = 0;
    public int type = 0;
    float quantity = 0;
    int i = 0;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3  pos = new Vector3(target.position.x,spawnPoint.position.y,spawnPoint.position.z);
        spawnPoint.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckIfCanSpawn();
        Spawn();
    }

    void Move(){
        Vector3  pos = new Vector3(target.position.x,transform.position.y,transform.position.z);
        transform.position = pos;
    }

    void CheckIfCanSpawn()
    {
        if (!canSpawn)
        {
            timer += Time.deltaTime;
            if (timer >= 6)
            {
                timer = 0;
                type = Random.Range(0,patternEnemies.Count);
                quantity = Random.Range(6,10);
                canSpawn = true;
            }
        }
    }
    void Spawn(){
        if(canSpawn){
            timerSpawn += Time.deltaTime;
            if (timerSpawn >= 0.2)
            {
                timerSpawn = 0;
                Instantiate(patternEnemies[type],spawnPoint.position,spawnPoint.rotation);
                Instantiate(spawnEffect,spawnPoint.position,spawnPoint.rotation);
                i++;
                if(i>= quantity){
                    canSpawn = false;
                    i=0;
                }
            }
            
        }
        

    }
}
