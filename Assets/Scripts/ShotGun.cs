using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Shooting
{
    Quaternion angle = new Quaternion();
    public override void Shoot()
    {
        for (int i = 0; i < 30; i++)
        {
            angle.eulerAngles = PivotPoint.rotation.eulerAngles + new Vector3(Random.Range(0, 30), Random.Range(0, 30), 0);
            Instantiate(Bullet, PivotPoint.position, angle);
        }
        Ammo--;

        //TODO: ���� �������� � ����� ������� ��������
        CanShoot = false;
        StartCoroutine(WaitTillShoot(1f));
    }
}