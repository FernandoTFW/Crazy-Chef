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
    public int typeAttack = 0;
    float quantity = 0;
    int i = 0;
    Transform target;
    public Animator anim;

    public AudioClip chopping;

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
                typeAttack = Random.Range(0,4);
                quantity = Random.Range(6,10);
                canSpawn = true;
            }
        }
    }
    void Spawn(){
        if (canSpawn){
            timerSpawn += Time.deltaTime;
            anim.SetTrigger("attack");
            
            if (timerSpawn >= Dificulty.timeBtwFood)
            {
                GameManager.instance.PlaySFX(chopping);
                timerSpawn = 0;
                if(type>=0 && type<=3 && Dificulty.dificultyMultiplier>=1.25){
                    switch (typeAttack)
                    {
                        case 0:
                            Instantiate(patternEnemies[0],spawnPoint.position,spawnPoint.rotation);
                            Instantiate(patternEnemies[1],spawnPoint.position,spawnPoint.rotation);
                        break;
                        case 1:
                            Instantiate(patternEnemies[2],spawnPoint.position,spawnPoint.rotation);
                            Instantiate(patternEnemies[3],spawnPoint.position,spawnPoint.rotation);
                        break;
                        case 2:
                            Instantiate(patternEnemies[1],spawnPoint.position,spawnPoint.rotation);
                            Instantiate(patternEnemies[3],spawnPoint.position,spawnPoint.rotation);
                        break;
                        case 3:
                            Instantiate(patternEnemies[type],spawnPoint.position,spawnPoint.rotation);
                        break;
                        
                    }
                }else{
                    Instantiate(patternEnemies[type],spawnPoint.position,spawnPoint.rotation);
                }
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
