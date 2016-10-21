using UnityEngine;
using System.Collections;

public class CameraCollisionTester : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("We have a collision");
        GameObject hitObject = collision.gameObject;
            
        if (!hitObject.GetComponent<Rigidbody>())
        {
            var rigidbody = hitObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        } 
             
    }
}