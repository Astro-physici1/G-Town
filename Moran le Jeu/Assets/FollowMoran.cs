using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMoran : MonoBehaviour
{
    [SerializeField] Transform Moran;
    Vector3 offsetCamera;

    // Start is called before the first frame update
    void Start()
    {
        offsetCamera = transform.position - Moran.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = Moran.position + offsetCamera;
        transform.position = cameraPosition;
    }
}