using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehavior : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject tokenPrefab;
    private float ypos = 0.5f;
    public float smooth = 0.00001f;
    private bool goingLeft = true;
    private Vector3 desiredPosition = new Vector3();
    
    //private Transform.position posOriginal = transform.position;
    void Start()
    {

        
        for (var i = 0; i < 50; i++)
        {
            for (var j = 0; j < 11; j++)
            {
                var rand = Random.value;
                if (rand < 0.1f)
                {
                    Instantiate(myPrefab, new Vector3(j-5, ypos*-1, i+20), transform.rotation * Quaternion.Euler(00, 0, 00));
                    
                } else if (rand > 0.975f)
                {
                    Instantiate(tokenPrefab, new Vector3(j - 5, ypos/2, i + 20), transform.rotation * Quaternion.Euler(00, 0, 00));
                }
              

            }
        }
        for (var i = 0; i < 10; i ++)
        {
            
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        if (goingLeft)
        {
            desiredPosition = transform.position - new Vector3(1.0f, 0, 0);
        } else
        {
            desiredPosition = transform.position + new Vector3(1.0f, 0, 0);
        }
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smooth);
        transform.position = smoothedPosition;
    }
}
