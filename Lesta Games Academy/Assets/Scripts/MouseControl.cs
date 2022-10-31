using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mouse = new(Input.GetAxis("Mouse X") * speed * Time.deltaTime, Input.GetAxis("Mouse Y") * speed * Time.deltaTime);
            transform.Translate(mouse * speed);
        }
    }
}
