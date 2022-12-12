using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator anim;

    #region properties
    public float hp = 100;
    #endregion
    #region Movement
    public Rigidbody rb;
    public float speed = 7;
    public float dashForce = 7;
    bool canPush = true;
    float dashTime = 1;
    bool dashing = false;
    public float left,rigth;
    float x;
    #endregion

    #region timer
    float timer = 0;
    #endregion

    #region Attack
    public List<Transform> firePoints;
    public GameObject bullet;
    public bool doubleAttack = false;
    public float timerShoot = 0;
    bool canShoot = true;
    #endregion

    #region Audio
    public AudioClip crashedSound, normalShoot, ketchupShoot, swooshSound;
    #endregion

    public Slider hpBar;

    void Start() 
    {
        hpBar.maxValue = hp;
    }
    void Update()
    {
        Move();
        CheckIfCanDash();
        Dash();
        CheckShoot();
        Shoot();
        //AddingScore();
    }



    void Move()
    {
        x = Input.GetAxis("Horizontal");
        Vector3 movementDirection = new Vector3(x, 0, 0);
        movementDirection.Normalize();
        if(transform.position.x >= left && transform.position.x <= rigth){
            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);//Moverse
            if(x >= 0.1 || x<= -0.1)
            {
                anim.SetFloat("rotate", x);
            }
           
        } else if(transform.position.x < left){
            transform.position = new Vector3(left,transform.position.y,transform.position.z);
           
        }else if(transform.position.x > rigth){
            transform.position = new Vector3(rigth,transform.position.y,transform.position.z);
         
        }
        

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
            GameManager.instance.PlaySFX(swooshSound);
        }
    }

    void Shoot(){
        if(Input.GetKeyDown(KeyCode.Mouse0) && canShoot){
            if(!doubleAttack){
                Instantiate(bullet,firePoints[0].position,firePoints[0].rotation);
                GameManager.instance.PlaySFX(normalShoot);
                anim.SetTrigger("shoot");
            }
            else
            {
                foreach(Transform a in firePoints){
                    Instantiate(bullet,a.position,a.rotation);
                    GameManager.instance.PlaySFX(ketchupShoot);
                }
            }
            canShoot = false;
        }
        
    }

    public void TakeDamage(float damage){
        hp -= damage;
        hpBar.value = hp;
        Debug.Log("Player dañado");

        GameManager.instance.PlaySFX(crashedSound);

        if (hp <= 0){
            SceneManager.LoadScene("LoseScreen");
        }
    }

    IEnumerator ActivateDash()
    {
        if (x >= 0.1)
        {
            anim.SetTrigger("dashR");
        }
        else if(x <= -0.1)
        {
            anim.SetTrigger("dashL");
        }
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
