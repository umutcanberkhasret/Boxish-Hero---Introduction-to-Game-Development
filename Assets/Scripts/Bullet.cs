using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float timeToLive;
    [SerializeField] float damage;

    public float Speed { get => speed; set => speed = value; }
    public float TimeToLive { get => timeToLive; set => timeToLive = value; }
    public float Damage { get => damage; set => damage = value; }

    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject smt = other.gameObject;

        if (smt != null && smt.tag == "Enemy")
        {
            other.gameObject.GetComponent<Health>().takeDamage(damage);
        }
        
        Destroy(gameObject);
    }
   

}
