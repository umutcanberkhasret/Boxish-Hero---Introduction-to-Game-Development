using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float timeToLive;
    [SerializeField] float damage;
    
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
