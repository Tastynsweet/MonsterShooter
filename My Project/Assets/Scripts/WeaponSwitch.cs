using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    [SerializeField] PlayerControl weapon1;
    [SerializeField] PlayerControl weapon2;
    [SerializeField] PlayerControl weapon3;

    [SerializeField] ProjectileSpawn bullet1;
    [SerializeField] ProjectileSpawn bullet2;
    [SerializeField] ProjectileSpawn bullet3;

    [SerializeField] GameObject Perspective;
    private float zPos = -0.7f;

    //private bool weapon1Active = true;



    // Start is called before the first frame update
    void Start()
    {
        weapon1.enabled = true;
        weapon2.enabled = false;
        weapon3.enabled = false;

        bullet1.enabled = true;
        bullet2.enabled = false;
        bullet3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon("Q");

            Perspective.transform.position = new Vector3(Perspective.transform.position.x, Perspective.transform.position.y, -30f + zPos);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SwitchWeapon("W");

            Perspective.transform.position = new Vector3(Perspective.transform.position.x, Perspective.transform.position.y, zPos);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchWeapon("E");

            Perspective.transform.position = new Vector3(Perspective.transform.position.x, Perspective.transform.position.y, 30f + zPos);
        }
    }
    
    void SwitchWeapon(string weaponLetter) //Chanhee made this
    {
        weapon1.enabled = false;
        weapon2.enabled = false;
        weapon3.enabled = false;
        bullet1.enabled = false;
        bullet2.enabled = false;
        bullet3.enabled = false;

        switch (weaponLetter)
        {
            case "Q" :
                weapon2.enabled = true;
                bullet2.enabled = true;
                break;
            case "W":
                weapon1.enabled = true;
                bullet1.enabled = true;
                break;
            case "E":
                weapon3.enabled = true;
                bullet3.enabled = true;
                break;
        }
    }

}
