using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform PivotPoint;
    public GameObject Bullet;
    public int StartAmmo;

    public int dmg;
    public int speed;
    public float bullLifeTime;
    public float reloadTime;

    [HideInInspector]//����� ����������, �� � �����, ���� �� ���������
    public bool CanShoot = true;
    public int Ammo;
    public int ammoInColler;

    private void Start()
    {
        StartAmmo -= ammoInColler;
        Ammo = ammoInColler;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && CanShoot && Ammo > 0)
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
    public IEnumerator Reload(float _time)//����� �������� ��� �� ����� ��������, � � ��� ����� ���������� �����, ������� �����������
    {
        yield return new WaitForSeconds(_time);
        if (StartAmmo > 0)
        {
            if (StartAmmo >= ammoInColler)
            {
                StartAmmo -= ammoInColler;
                Ammo = ammoInColler;
            }
            else
            {
                Ammo = StartAmmo;
                StartAmmo -= StartAmmo;
            }
        }
        
        CanShoot = true;
    }
    public IEnumerator WaitTillShoot(float _time)//����� ���� ����� �������� ������ � ����� � ���
    {
        yield return new WaitForSeconds(_time);
        CanShoot = true;
    }

    public virtual void Shoot()
    {
        Ammo--;
        Instantiate(Bullet, PivotPoint.position, PivotPoint.rotation);
        //TODO: ���� �������� � ����� ������� ��������
        CanShoot = false;
        StartCoroutine(WaitTillShoot(0.1f));
    }

    public virtual void AltShoot()
    {
        int bullets = 3;

        if (Ammo < 3)
        {
            bullets = Ammo;
        }

        for (int i = 0; i < bullets; i++)
        {
            Ammo--;
            Instantiate(Bullet, PivotPoint.position - new Vector3(0, 0, 0.1f * i), PivotPoint.rotation);
        }
        
        //TODO: ���� �������� � ����� ������� ��������
        CanShoot = false;
        StartCoroutine(WaitTillShoot(1f));
    }
}
