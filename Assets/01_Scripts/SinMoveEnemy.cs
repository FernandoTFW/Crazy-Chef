using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMoveEnemy : MonoBehaviour
{
    float centerZ;
    public float amplitude = 7;
    public float frequency = 0.5f;
    public bool inverted = false;
    // Start is called before the first frame update
    void Start()
    {
        centerZ = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        SinMove();
    }

    void SinMove(){
        Vector3 pos = transform.position;
        float sin = Mathf.Sin(pos.z * frequency) * amplitude;
        if(inverted){
            sin *= -1;
        }
        pos.x = centerZ + sin;
        transform.position = pos;
    }
}
