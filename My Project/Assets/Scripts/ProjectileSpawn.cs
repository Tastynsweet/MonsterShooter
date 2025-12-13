using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public GameObject projectilePrefab;
    [SerializeField] float fireCooldown = 1;
    private float timer = 100.0f;
    private string targetWord = "loading";
    private string userInput = "";

    public CameraShake shake;
    public bool isActiveWeapon = false;

    [SerializeField] private bool firstShots = true;
    [SerializeField] private int startingAmmo = 5;

    void Update()
    {
        timer += Time.deltaTime;
        if (!isActiveWeapon) return;                                                                    //Only one weapon at a time

        if (timer >= fireCooldown)
        {

            foreach (char c in Input.inputString)
            {
                if (char.IsLetter(c))
                {
                    userInput += char.ToLower(c);
                }
            }

            if (userInput.Length > targetWord.Length)                                                   //only compare the last couple inputs from user
            {
                userInput = userInput.Substring(userInput.Length - targetWord.Length);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (firstShots)                                                                          //Fire without typing only the first n times
                {
                    FireProjectile();
                    startingAmmo--;
                    if (startingAmmo <= 0)
                    {
                        firstShots = true;                                                              //Temporary: No reloading yet
                        //Debug.Log("Start Reloading");
                    }
                }
                else if (userInput.Equals(targetWord, System.StringComparison.OrdinalIgnoreCase))
                {
                    startingAmmo = 5;
                    firstShots = true;
                    userInput = "";                                                                     //reset user input
                }
                
            }
        }
    }

    private void FireProjectile()
    {
        StartCoroutine(shake.ScreenShake());                                                            //Shake camera when firing
        Instantiate(projectilePrefab, transform.position, transform.rotation);
        timer = 0;                                                                                      //Set firing delay

    }
}
