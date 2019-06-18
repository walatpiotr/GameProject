using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1000f;
    Transform fire_point;
    Camera cam;
    Transform my;
    Rigidbody2D rb;
    void Start()
    {
        
        my = GetComponent<Transform>();
        cam = Camera.main;

        rb = this.gameObject.GetComponent<Rigidbody2D>();
        
        float camDis = cam.transform.position.y - my.position.y;
        
        Vector2 normalized_vector_mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 normalized_vector_mouse3d = new Vector3(normalized_vector_mouse[0], normalized_vector_mouse[1], 0);
        Vector3 mouse = cam.ScreenToWorldPoint(normalized_vector_mouse3d);
        //Debug.Log(normalized_vector_mouse3d);
        mouse[2] = 0;

        Transform fire_point = GameObject.FindWithTag("firepoint").GetComponent<Transform>();
        
        var heading = mouse - fire_point.position;
        //Debug.Log("Wektor roznicowy: "+heading);
        var distance = heading.magnitude;
        //Debug.Log("Dystans: " +distance);
        var direction = heading / distance;
        //Debug.Log("Kierunek: " +direction);

        Vector2 bullet_real_speed = direction.normalized * speed ;
        rb.velocity = bullet_real_speed;
        //Debug.Log("velocity: " + Mathf.Sqrt(Mathf.Pow(rb.velocity[0],2) + Mathf.Pow(rb.velocity[1],2)));
    }


    

    
}
