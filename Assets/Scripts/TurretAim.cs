using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TurretAim : MonoBehaviour
{
    public Transform basePivot;
    public Transform gunsPivot;
    public float rayDistance = 50;
    public GameObject bulletPrefab;
    public LayerMask raycastLayer;

    RaycastHit hit;

    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 basePos;
        Vector3 gunPos;

        Quaternion baseRotation;
        Quaternion gunRotation;

        Vector3 mousePos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePos);
        
        basePos = (mousePos - basePivot.position);
        baseRotation = Quaternion.LookRotation(basePos);
        basePos.y = 0f;

        gunPos = (mousePos - gunsPivot.position);
        gunRotation = Quaternion.LookRotation(gunPos);

        gunsPivot.rotation = Quaternion.Lerp(gunsPivot.rotation, gunRotation, 1);
        basePivot.rotation = Quaternion.Lerp(basePivot.rotation, baseRotation, 1);

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, raycastLayer))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.white);
        }

        Debug.DrawRay(gunsPivot.transform.position, gunsPivot.forward * rayDistance, Color.red);
        
        /*Need to work on shooting
         * if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                GameObject go = Instantiate(bulletPrefab, gunsPivot.transform.position, gunsPivot.transform.rotation);
                go.GetComponent<Rigidbody>().AddForce(gunsPivot.forward * 500);
            }
        }*/
    }
}
