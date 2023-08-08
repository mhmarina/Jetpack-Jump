using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody myRigidBody;
    public float jumpSpeed = 1;
    public float rotationSpeed = 1;
    AudioSource thrustSFX;
    bool thrustSFXisPlaying = false;
    public AudioClip thrusters;
    public ParticleSystem mainBooster;
    public ParticleSystem leftBooster;
    public ParticleSystem rightBooster;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        thrustSFX = GetComponent<AudioSource>();
        thrustSFX.volume = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Thrusting");
            myRigidBody.AddRelativeForce(0, (jumpSpeed * Time.deltaTime), 0);
            mainBooster.Play();
            if (!thrustSFXisPlaying)
            {
                thrustSFX.PlayOneShot(thrusters);
                thrustSFXisPlaying = true;
            }
        }
        else
        {
            thrustSFX.Stop();
            thrustSFXisPlaying = false;
        }
    }
    void ProcessRotation() {
        if (Input.GetKey(KeyCode.A))
        {
            leftBooster.Play();
            RotationMech(1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rightBooster.Play();
            RotationMech(-1); 
        }
    }
    public void RotationMech(float direction) {
        myRigidBody.freezeRotation = true; // freezing rotation on obstacles to manually rotates
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * direction);
        myRigidBody.freezeRotation = false;
    }
}
