using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed;
    public float CurHP;

    [SerializeField] private GameObject blood;
    [SerializeField] private GameObject deathEffect;
    
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
            Destroy(Instantiate(deathEffect, transform.position + new Vector3(0, 1, -1), transform.rotation), 2f);

        }
    }
    public void TakeDamage(float damage)
    {
        Destroy(Instantiate(blood,transform.position + new Vector3(0,1,-1),transform.rotation),2f);
        CurHP -= damage;
    }
}
