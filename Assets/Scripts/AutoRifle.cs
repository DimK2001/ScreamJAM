using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRifle : Shooting
{
    private void Update()
    {
        if (Input.GetButton("Fire1") && CanShoot && Ammo > 0)
        {
            Bullet.GetComponent<Bullet>().Dmg = dmg;
            Bullet.GetComponent<Bullet>().Speed = speed;
            Bullet.GetComponent<Bullet>().lifeTime = bullLifeTime;
            Shoot();
        }
        else if (Input.GetButtonDown("Fire2") && CanShoot && Ammo > 0)
        {
            Bullet.GetComponent<Bullet>().Dmg = dmg;
            Bullet.GetComponent<Bullet>().Speed = speed;
            Bullet.GetComponent<Bullet>().lifeTime = bullLifeTime;
            AltShoot();
        }
        else if ((Input.GetKeyDown(KeyCode.R)/*�������� �� ������*/ || ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Ammo <= 0)) && CanShoot)
        {
            //if (CanShoot)
            StartCoroutine(Reload(reloadTime));
            CanShoot = false;
        }
    }

    public override void AltShoot()
    {
        Ammo--;
        Instantiate(Bullet, PivotPoint.position, PivotPoint.rotation);


        //TODO: ���� �������� � ����� ������� ��������
        CanShoot = false;
        StartCoroutine(WaitTillShoot(altShootTime));
    }
}
