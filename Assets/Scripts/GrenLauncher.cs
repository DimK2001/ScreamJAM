using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenLauncher : Shooting
{
    //public GameObject Bullet;
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && CanShoot && Ammo > 0)
        {
            Bullet.GetComponent<GrenBullet>().Dmg = dmg;
            Bullet.GetComponent<GrenBullet>().Speed = speed;
            Bullet.GetComponent<GrenBullet>().lifeTime = bullLifeTime;
            Shoot();
        }
        else if (Input.GetButtonDown("Fire2") && CanShoot && Ammo > 0)
        {
            Bullet.GetComponent<GrenBullet>().Dmg = dmg;
            Bullet.GetComponent<GrenBullet>().Speed = speed;
            Bullet.GetComponent<GrenBullet>().lifeTime = bullLifeTime;
            AltShoot();
        }
        else if ((Input.GetKeyDown(KeyCode.R)/*�������� �� ������*/ || ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Ammo <= 0)) && CanShoot)
        {
            //if (CanShoot)
            StartCoroutine(Reload(reloadTime));
            CanShoot = false;
        }
    }
    public override void Shoot()
    {
        
        Instantiate(Bullet, PivotPoint.position, PivotPoint.rotation);
        Ammo--;

        //TODO: ���� �������� � ����� ������� ��������
        CanShoot = false;
        StartCoroutine(WaitTillShoot(5f));
    }

    public override void AltShoot()
    {

    }
}
