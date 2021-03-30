using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rgb;
    public Transform ftr;

    void Start()
    {
        this.GetComponent<Rigidbody>().centerOfMass = ftr.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
