using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    void Update()
    {
        transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        if (transform.position.z < -50)
        {
            transform.position += new Vector3(0, 0, 150f);
        }
    }
}