using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickDrop : MonoBehaviour
{

    [SerializeField] private Transform camera_pos;
    [SerializeField] private Transform grab_point;
    [SerializeField] private LayerMask grab_layer;

    private Grabbable grabbed_object;

    void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E)) {
            if (grabbed_object == null) {
                Physics.Raycast(camera_pos.position, camera_pos.forward, out hit, 15f, grab_layer);
                if (hit.transform.TryGetComponent(out grabbed_object)) {
                    grabbed_object.Grab(grab_point);
                }
            }
            else{
                grabbed_object.Drop();
                Debug.Log("Drop");
                grabbed_object = null;

            }
    }

    }
}