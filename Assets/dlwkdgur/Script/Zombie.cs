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
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueBullet"))
        {
            TakeDamage(1);
            Debug.Log("Take Damage");
            if (CurHP <= 0)
            {
                ScoreManager.Instance.Player1ScoreUp();
                Destroy(gameObject);
                Destroy(Instantiate(deathEffect, transform.position + new Vector3(0, 1, -1), transform.rotation), 2f);
                Debug.Log("Die");
            }
        }
        if (other.gameObject.CompareTag("RedBullet"))
        {
            TakeDamage(1);
            Debug.Log("Take Damage");
            if (CurHP <= 0)
            {
                ScoreManager.Instance.Player2ScoreUp();
                Destroy(gameObject);
                Destroy(Instantiate(deathEffect, transform.position + new Vector3(0, 1, -1), transform.rotation), 2f);
                Debug.Log("Die");
            }
        }
    }
    public void TakeDamage(float damage)
    {
        Destroy(Instantiate(blood,transform.position + new Vector3(0,1,-1),transform.rotation),2f);
        CurHP -= damage;
    }
}
