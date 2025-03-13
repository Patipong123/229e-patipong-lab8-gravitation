using System.Collections.Generic; //For List
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f;
    public static List<Gravity> gravityObjectsList;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (gravityObjectsList == null) 
        {
            gravityObjectsList = new List<Gravity>();
        }

        gravityObjectsList.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (Gravity obj in gravityObjectsList)
        {
            if (obj != this) 
            {
                Attract(obj);
            }
        }
    }

    void Attract(Gravity other) 
    {
        Rigidbody otherRb = other.rb;

        //find distance between two object
        Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;
        float forceMagnitude = G * (rb.mass * otherRb.mass / Mathf.Pow(distance, 2));
        Vector3 finalForce = forceMagnitude * direction.normalized;

        //addforce
        otherRb.AddForce(finalForce);


    }
        
}
