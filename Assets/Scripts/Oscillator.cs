using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startingPos;
    public Vector3 movementVector;
    float movementFactor;
    public float period = 2f;

    void Start()
    {
        startingPos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
