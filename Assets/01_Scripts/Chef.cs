using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : MonoBehaviour
{
    public GameObject linealEnemy;
    public List<GameObject> patternEnemies;
    public Transform spawnPoint;
    public bool canSpawn = false;
    public float timer = 0;
    public float timerSpawn = 0;
    public int type = 0;
    float quantity = 0;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCanSpawn();
        Spawn();
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
            if (timerSpawn >= 0.1)
            {
                timerSpawn = 0;
                Instantiate(patternEnemies[type],spawnPoint.position,spawnPoint.rotation);
                i++;
                if(i>= quantity){
                    canSpawn = false;
                    i=0;
                }
            }
            
        }
        

    }
}
