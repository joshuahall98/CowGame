using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    GameObject farmer;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        farmer = GameObject.Find("Farmer");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(farmer != null)
        {
            transform.position = new Vector3(farmer.transform.position.x + offset.x, farmer.transform.position.y + offset.y, -10);
        }
        
    }
}
