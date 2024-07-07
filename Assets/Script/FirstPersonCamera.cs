using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonCamera : MonoBehaviour
{   
    CC player; 

    public float sensitivity;
    public float smoothness;

    float camHorizontal;
    float camVertical;

    public Vector2 smoothVelocity;
    public Vector2 currentLooking;

    void Start()
    {
        player = FindObjectOfType<CC>();
    }

    public void Update()
    {
        if (currentLooking.y > 75)
            currentLooking.y = 75;

        if (currentLooking.y < -75)
            currentLooking.y = -75;
    }

    public void FixedUpdate()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        Vector2 inputValues = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        inputValues = Vector2.Scale(inputValues, new Vector2(sensitivity * smoothness, sensitivity * smoothness));
        smoothVelocity.x = Mathf.Lerp(smoothVelocity.x, inputValues.x, 1f / smoothness);
        smoothVelocity.y = Mathf.Lerp(smoothVelocity.y, inputValues.y, 1f / smoothness);

        currentLooking += smoothVelocity;

        transform.localRotation = Quaternion.AngleAxis(-currentLooking.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(currentLooking.x, player.transform.up);
    }
}