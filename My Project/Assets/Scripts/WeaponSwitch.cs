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
    public CameraShake cameraShake;
    //private bool weapon1Active = true;

    void Start()
    {
        weapon1.enabled = true;        //Players start with the middle cannon
        weapon2.enabled = false;
        weapon3.enabled = false;

        bullet1.isActiveWeapon = true;
        bullet2.isActiveWeapon = false;
        bullet3.isActiveWeapon = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))    //Switch between usable weapons via camera
        {
            SwitchWeapon("Q");

            Perspective.transform.position = new Vector3(Perspective.transform.position.x, Perspective.transform.position.y, -30f + zPos);
            cameraShake.UpdateOriginalPosition(Perspective.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SwitchWeapon("W");

            Perspective.transform.position = new Vector3(Perspective.transform.position.x, Perspective.transform.position.y, zPos);
            cameraShake.UpdateOriginalPosition(Perspective.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchWeapon("E");

            Perspective.transform.position = new Vector3(Perspective.transform.position.x, Perspective.transform.position.y, 30f + zPos);
            cameraShake.UpdateOriginalPosition(Perspective.transform.position);
        }
    }
    
    void SwitchWeapon(string weaponLetter) //Chanhee made this
    {
        weapon1.enabled = false;
        weapon2.enabled = false;
        weapon3.enabled = false;
        bullet1.isActiveWeapon = false;
        bullet2.isActiveWeapon = false;
        bullet3.isActiveWeapon = false;

        switch (weaponLetter)                                   //Disable weapons when not in use but keep cooldown on
        {
            case "Q" :
                weapon2.enabled = true;
                bullet2.isActiveWeapon = true;
                break;
            case "W":
                weapon1.enabled = true;
                bullet1.isActiveWeapon = true;
                break;
            case "E":
                weapon3.enabled = true;
                bullet3.isActiveWeapon = true;
                break;
        }
    }

}
