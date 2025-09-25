using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;
    private float horizontalInput;
    private ObjectShake shake;

    private void Start()
    {
        shake = GetComponent<ObjectShake>();
    }

    void Update()
    {
        float originalXrot = transform.eulerAngles.x;   //Save x and z rotation
        float originalZrot = transform.eulerAngles.z;
        //float rotateAmount = Time.deltaTime * horizontalInput * speed;
        float rotateAmount = 0f;
        float rotLimit = 35.0f;

        //horizontalInput = Input.GetAxis("Horizontal");
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotateAmount = -speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotateAmount = speed * Time.deltaTime;
        }

        transform.Rotate(Vector3.up, rotateAmount);
        
        float currentRotation = transform.eulerAngles.y;
 
        if (currentRotation < 360 - rotLimit && currentRotation > 180)   //rotation limit
        {
            transform.rotation = Quaternion.Euler(originalXrot, 360 - rotLimit, originalZrot);
            shake.ShakeObject();
        }
        else if (currentRotation > rotLimit && currentRotation <= 180)
        {
            transform.rotation = Quaternion.Euler(originalXrot, rotLimit, originalZrot);
            shake.ShakeObject();
        }
  

    }
}
