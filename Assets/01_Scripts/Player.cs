using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Movement
    public Rigidbody rb;
    public float speed = 7;
    public float dashForce = 7;
    bool canPush = true;
    float dashTime = 1;
    bool dashing = false;
    #endregion

    #region timer
    float timer = 0;
    #endregion

    #region Attack
    public List<Transform> firePoints;
    public GameObject bullet;
    bool doubleAttack = false;
    public float timerShoot = 0;
    bool canShoot = true;
    #endregion

    void Update()
    {
        Move();
        CheckIfCanDash();
        Dash();
        CheckShoot();
        Shoot();
    }



    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 movementDirection = new Vector3(x, 0, 0);
        movementDirection.Normalize();
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);//Moverse

    }

    void CheckIfCanDash()
    {
        if (!canPush)
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                timer = 0;
                canPush = true;
            }
        }
    }

    void Dash(){
        if(canPush && Input.GetKeyDown(KeyCode.E)){
            StartCoroutine(ActivateDash());
        }
    }

    void Shoot(){
        if(Input.GetKeyDown(KeyCode.Mouse0) && canShoot){
            if(!doubleAttack){
                Instantiate(bullet,firePoints[0].position,firePoints[0].rotation);
            }
            canShoot = false;
        }
        
    }

    IEnumerator ActivateDash()
    {
        speed *= 4;
        canPush = false;
        dashing = true;
        yield return new WaitForSeconds(dashTime);
        speed /= 4;
        dashing = false;
    }

    public void CheckShoot()
    {
        if(!canShoot){
            timerShoot += Time.deltaTime;
            if (timerShoot >= 0.3)
            {
                canShoot = true;
                timerShoot = 0;
            }
        }
        
    }


}
