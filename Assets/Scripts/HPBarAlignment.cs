using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarAlignment : MonoBehaviour
{
    [SerializeField]
    Transform humanoidObject;
    
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = humanoidObject.position;
  
    }
}
