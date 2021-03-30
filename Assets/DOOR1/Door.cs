using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public float force = 0, range = 0.5f, sdd=0.2f;
    Collider[] hitColliders;
    public ForceMode velo = ForceMode.Force;
    public ForDoor2 dd;
    public KeyCode gk;
    public bool OPA, OPA2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position += new Vector3(Input.GetAxis("Mouse X") * sdd, 0, Input.GetAxis("Mouse Y") * sdd);

        ///

        hitColliders = Physics.OverlapSphere(transform.position, range);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<ForDoor2>() != null)
            {
                if (Input.GetKey(gk))
                {
                    hitCollider.GetComponent<ForDoor2>().B_l = true;
                    hitCollider.GetComponent<ForDoor2>().lastB_l = true;
                    hitCollider.transform.position = this.transform.position;
                }
                else
                {
                    hitCollider.GetComponent<ForDoor2>().B_l = false;
                }
            }
        }
    }
}
