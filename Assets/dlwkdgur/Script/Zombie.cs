using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed;
    public float CurHP;
    
    void Start()
    {
        transform.Rotate(new Vector3(0f, 180f, 0f));
    }

    void Update()
    {
      
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (CurHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        CurHP -= damage;
    }
}
