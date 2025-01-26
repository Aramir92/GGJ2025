using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 0.5f;

    [SerializeField]
    private bool randomizeInitialValue = true;

    private void Start()
    {
        if(randomizeInitialValue)
        {
            Vector3 rotation = transform.localRotation.eulerAngles;
            rotation.z = Random.Range(0, 360);
            transform.localRotation = Quaternion.Euler(rotation);
        }
    }

    void Update()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.z += rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(rotation);
    }
}
