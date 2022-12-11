using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalMovement : MonoBehaviour
{
    public float moveSpeed = 20;
    public bool right;
    private void FixedUpdate() {
        DiagonalMove();
    }

    void DiagonalMove(){
        if(!right){
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        } else{
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Scenary")){
            if(right){
                right = false;
                
            }else{
                right = true;
            }

        }
    }
}
