using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dificulty : MonoBehaviour
{
    public static float dificultyMultiplier = 1;
    public static float damageMultiplier = 1;
    public static double timeBtwFood = 0.2;
    float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 60)
        {
            timer = 0;
            dificultyMultiplier += 0.25f;
            if(dificultyMultiplier>= 1.50){
                damageMultiplier += 0.75f; 
            }
            if(timeBtwFood >=0.1)
            {
                timeBtwFood -= 0.05;
            }
            
        }
    }
}
