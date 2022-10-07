using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    // Movement Speed
    public float speed = 100.0f;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        // Hit the Racket?
        if (col.gameObject.name == "racket") 
        {
            // Calculate hit Factor
            float x=hitFactor(transform.position,col.transform.position,col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,float racketWidth) 
    {

        return (ballPos.x - racketPos.x) / racketWidth;
    }


}
