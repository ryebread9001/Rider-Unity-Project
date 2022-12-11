using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBehavior : MonoBehaviour
{
    float speed;
    float acceleration = 0.001f;
    

    // Update is called once per frame
    void Update()
    {
        //speed += time.deltatime * acceleration;
        //if (8f * speed < 16f)
        //{
        //    transform.position -= new vector3(0, 0, 8f * speed);
        //} else
        //{
        //    transform.position -= new vector3(0, 0, 16f);
        //}

        transform.position -= new Vector3(0, 0, 16f * Time.deltaTime);


        if (transform.position.z < -50)
        {
            
            if (transform.position.y == 0.5/2f)
            {
                transform.position = new Vector3(Random.Range(-5, 5), 0.25f, 51.0f);
            } else
            {
                transform.position = new Vector3(Random.Range(-5, 5), -0.5f, 51.0f);
            }
            
            
        }

    }
}
