using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsPineDown()
    {
        if (gameObject.transform.rotation.x > 50 || gameObject.transform.rotation.x < -50 ||
           gameObject.transform.rotation.z > 50 || gameObject.transform.rotation.z < -50)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
