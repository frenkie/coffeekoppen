using UnityEngine;
using System.Collections;

public class ProjectileManager : MonoBehaviour {

    public GameObject projectile;
    AudioSource audioSource = null;

    // Use this for initialization
    void Start () {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialize = true;
        audioSource.spatialBlend = 1.0f;
        audioSource.dopplerLevel = 0.0f;
        audioSource.maxDistance = 7.0f;
        audioSource.rolloffMode = AudioRolloffMode.Custom;
        audioSource.clip = Resources.Load<AudioClip>("Tossing");
    }
	
    void OnLaunch ()
    {
        // clone a coffee mug and launch it towards the camera
        if (projectile != null) {
            if (!projectile.GetComponent<Rigidbody>())
            {
                GameObject projectileInstance = Instantiate(projectile) as GameObject;
                var rigidbody = projectileInstance.AddComponent<Rigidbody>();               

                projectileInstance.transform.position = projectile.transform.position;
                projectileInstance.transform.position = projectileInstance.transform.position + new Vector3(0.3f, 0.0f, 0.0f);

                Vector3 aim = Camera.main.transform.position - projectileInstance.transform.position;

                // aim with an arc to try and reach the camera
                var right = Vector3.Cross(aim, Vector3.up); 
                aim = Quaternion.AngleAxis(50, right) * aim;

                aim.Normalize();

                rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
                rigidbody.mass = 0.3f;

                float multiplier = Random.Range( 0.6f, 0.7f );
                float force = multiplier * Vector3.Distance(Camera.main.transform.position, projectileInstance.transform.position);
                
                audioSource.Play();


                rigidbody.AddForce(aim * force, ForceMode.Impulse );
            }
        }
    }
}
