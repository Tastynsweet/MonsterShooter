using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed = 15.0f;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rotateAmount = Time.deltaTime * horizontalInput * speed;
        float rotLimit = 60.0f;

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotateAmount);
        
        float currentRotation = transform.eulerAngles.y;
 
        if (currentRotation < 360 - rotLimit && currentRotation > 180)
        {
            transform.rotation = Quaternion.Euler(0, 360 - rotLimit, 0);
        }
        else if (currentRotation > rotLimit && currentRotation <= 180)
        {
            transform.rotation = Quaternion.Euler(0, rotLimit, 0);
        }
  

    }
}
