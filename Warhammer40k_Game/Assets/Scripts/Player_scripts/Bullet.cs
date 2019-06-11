using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Debug.Log(player);
        float z = player.transform.rotation[2];
        Debug.Log(z);

        rb.velocity = Vectormaker(z) * speed;
        //Debug.Log("Vector rotacji pocisku: "+Vectormaker(z));
    }


    Vector3 Vectormaker(float z)
    {
        float rad = z * Mathf.Deg2Rad;
        //Debug.Log("wartosc w radianach: "+rad);
        float x = Mathf.Sin(rad);
       // Debug.Log("sinus: "+x);
        float y = Mathf.Cos(rad);
        //Debug.Log("cosinus: "+y);
        return new Vector3(x, y, 0);
    }

    
}
