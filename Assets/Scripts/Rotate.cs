using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float baseAngle = 0.0f;
    private Vector3 initialDragDirection;
    private int turningDirection = 0; // 0 = no direction, 1 = clockwise, -1 = counterclockwise

    private float Speed = 0.0f;
    private bool isMouseDown = false;
    void OnMouseDown()
    {
        Speed = 0.0f;
        turningDirection = 0;
        isMouseDown = true;
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;

        baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;

        initialDragDirection = Vector3.zero; // Initialize the initial drag direction vector.
    }
    void OnMouseUp()
    {
        isMouseDown = false;
        if (turningDirection == 1)
        {
            Speed = -20.0f;
        }
        else if (turningDirection == -1)
        {
            Speed = 20.0f;
        }
    }

    void OnMouseDrag()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);

        // Calculate the drag direction as the vector from the starting position to the current position.
        Vector3 dragDirection = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)).normalized;

        // Calculate the angle between the initial drag direction and the current drag direction.
        float angle = Vector3.SignedAngle(initialDragDirection, dragDirection, Vector3.forward);

        // Determine whether it was dragged clockwise or counterclockwise.
        if (angle > 0)
        {
            turningDirection = -1;
            Debug.Log("Dragged counterclockwise");
        }
        else if (angle < 0)
        {
            turningDirection = 1;
            Debug.Log("Dragged clockwise");
        }
        // Update the initial drag direction for the next frame.
        initialDragDirection = dragDirection;
    }

    void Update()
    {

        if (!isMouseDown && turningDirection != 0)
        {
            transform.RotateAround(Vector3.forward, Speed * Time.deltaTime);
            Speed = Mathf.Lerp(Speed, 0.0f, Time.deltaTime);
        }
    }

}
