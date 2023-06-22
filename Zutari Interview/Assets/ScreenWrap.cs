using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private float leftConstraint = Screen.width;
    private float rightConstraint = Screen.width;
    private float topConstraint = Screen.height;
    private float bottomConstraint = Screen.height;
    [SerializeField] float offset = 1f;
    Camera mainCamera;
    private float distanceZ;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        distanceZ = Mathf.Abs(mainCamera.transform.position.z + transform.position.z);
        leftConstraint = mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, distanceZ)).x;
        rightConstraint = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, distanceZ)).x;
        bottomConstraint = mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, distanceZ)).y;
        topConstraint = mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height, distanceZ)).y;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.x < leftConstraint - offset)
        {
            transform.position = new Vector3(rightConstraint - 0.1f, transform.position.y, transform.position.z);
        }
        if(transform.position.x > rightConstraint)
        {
            transform.position = new Vector3(rightConstraint, transform.position.y, transform.position.z);
        }
        if(transform.position.y < bottomConstraint - offset)
        {
            transform.position = new Vector3(transform.position.x, topConstraint + offset, transform.position.z);
        }
        if(transform.position.y > topConstraint + offset)
        {
            transform.position = new Vector3(transform.position.x, bottomConstraint - offset, transform.position.z);
        }
    }
}
