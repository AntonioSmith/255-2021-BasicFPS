using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))] // Script requires a camera component to work
public class RayCaster : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // did user click on this game tick?
        if (cam != null && Input.GetButtonDown("Fire1"))
        {
            // shoot a ray into the scene
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hit;

            // draw ray
            // Debug.DrawRay(ray.origin, ray.direction, Color.black, .5f);           // Debugger to draw a ray

            if (Physics.Raycast(ray, out hit))
            {
                // ray hits something
                var door = hit.transform.GetComponentInParent<DoorController>();
                if (door != null)
                {
                    door.PlayerInteract(transform.parent.position);
                }
            }
        }
    }
}
