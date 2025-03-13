using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f;
    public static List<Gravity> otherObjectsList;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        /*if (otherObjectsList == null) 
        {
            otherObjectsList = new List<Gravity>();
        }

        otherObjectsList.Add(this);*/
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
