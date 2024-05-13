using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected KeyCode leftkey;
    [SerializeField] protected KeyCode rightkey;
    [SerializeField] protected KeyCode Firekey;
    [SerializeField] protected GameObject Bullet;
    [SerializeField] protected GameObject Player;
    [SerializeField] protected float AttackcoolTime = 0.5f;
    [SerializeField] protected Transform[] PlayerPoint;
    [SerializeField] protected int PlayerPointindex;

    protected float AttackcurTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    protected void Move()
    {
        if (Input.GetKey(leftkey) && !Input.GetKey(rightkey))
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        else if (Input.GetKey(rightkey) && !Input.GetKey(leftkey))
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);

    }

    protected void Fire()
    {
        if (AttackcurTime <= 0)
        {
            if (Input.GetKey(Firekey))
            {
                Destroy(Instantiate(Bullet, transform.position + new Vector3(0, 1f, 0.5f), transform.rotation * Quaternion.Euler(90, 0, 0)),2f);
                AttackcurTime = AttackcoolTime;
            }
        }
        else
        {
            AttackcurTime -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Correctanswer"))
        {
            Instantiate(Player, PlayerPoint[PlayerPointindex].transform.position , transform.rotation);
            PlayerPointindex++;
        } 
        //if (other.gameObject.CompareTag("Notanswer"))
        //{
        //    Destroy(PlayerPoint[PlayerPointindex].gameObject);
        //    PlayerPointindex++;
        //}
    }
}
