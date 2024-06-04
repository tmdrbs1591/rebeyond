using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float Speed;

    protected void Update()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    }
}
