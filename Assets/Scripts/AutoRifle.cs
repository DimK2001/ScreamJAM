using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRifle : Shooting
{
    [SerializeField]
    private GameObject altBullet;

    private void Update()
    {
        if (Input.GetButton("Fire1") && CanShoot && Ammo > 0)
        {
            Bullet.GetComponent<Bullet>().Dmg = dmg;
            Bullet.GetComponent<Bullet>().Speed = speed;
            Bullet.GetComponent<Bullet>().lifeTime = bullLifeTime;
            Shoot();
            Flash();
        }
        else if (Input.GetButtonDown("Fire2") && CanShoot && Ammo > 0)
        {
            altBullet.GetComponent<AltAutorifleBullet>().Dmg = altDmg;
            altBullet.GetComponent<AltAutorifleBullet>().Speed = speed;
            altBullet.GetComponent<AltAutorifleBullet>().lifeTime = bullLifeTime;
            AltShoot();
            Flash();
        }
        else if ((Input.GetKeyDown(KeyCode.R)/*�������� �� ������*/ || ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Ammo <= 0)) && CanShoot)
        {
            //if (CanShoot)
            Reload();
            CanShoot = false;
        }
    }

    public override void AltShoot()
    {
        Ammo--;
        Instantiate(altBullet, PivotPoint.position, PivotPoint.rotation);
        if (anim != null)
        {
            anim.SetTrigger("AltShot");
        }
        PlayShot();
        //TODO: ���� �������� � ����� ������� ��������
        CanShoot = false;
        //StartCoroutine(WaitTillShoot(altShootTime));
    }
    public override void Shoot()
    {
        Ammo--;
        Instantiate(Bullet, PivotPoint.position, PivotPoint.rotation);
        if (anim != null)
        {
            anim.SetTrigger("Shot");
        }
        PlayShot();
        //TODO: ���� �������� � ����� ������� ��������
        CanShoot = false;
        StartCoroutine(WaitTillShoot(shootTime));
    }
}
