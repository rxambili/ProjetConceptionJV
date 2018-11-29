using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

    public GameObject[] weapons;

    public int selectedWeapon = 0;

    public bool isSwitching;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        EnsureWeapon();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetButtonDown("Switch") && !isSwitching)
        {
            ChangeWeapon();
        }
    }

    void ChangeWeapon()
    {
        anim.SetTrigger("SwitchStyle");
    }

    public void StartChangingWeapon()
    {
        isSwitching = true;
        selectedWeapon = (selectedWeapon + 1) % 2;

    }

    public void EnsureWeapon()
    {
        int i = 0;
        foreach (GameObject weapon in weapons)
        {
            if (i == selectedWeapon)
            {
                weapon.SetActive(true);
            }
            else
            {
                weapon.SetActive(false);
            }
            i++;
        }
    }

    public void EndSwitching()
    {
        isSwitching = false;
    }
}
