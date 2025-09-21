using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;
    private float horizontalInput;
    
    void Update()
    {
        float originalXrot = transform.eulerAngles.x;   //Save x and z rotation
        float originalZrot = transform.eulerAngles.z;
        float rotateAmount = Time.deltaTime * horizontalInput * speed;
        float rotLimit = 35.0f;

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotateAmount);
        
        float currentRotation = transform.eulerAngles.y;
 
        if (currentRotation < 360 - rotLimit && currentRotation > 180)   //rotation limit
        {
            transform.rotation = Quaternion.Euler(originalXrot, 360 - rotLimit, originalZrot);
        }
        else if (currentRotation > rotLimit && currentRotation <= 180)
        {
            transform.rotation = Quaternion.Euler(originalXrot, rotLimit, originalZrot);
        }
  

    }
}
