using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform PivotPoint;
    public GameObject Bullet;
    public int StartAmmo = 30;

    [HideInInspector]//����� ����������, �� � �����, ���� �� ���������
    public bool CanShoot = true;
    public int Ammo;

    private void Start()
    {
        Ammo = StartAmmo;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && CanShoot && Ammo > 0)
        {
            Ammo--;
            Instantiate(Bullet, PivotPoint.position, PivotPoint.rotation);
            //TODO: ���� �������� � ����� ������� ��������
            CanShoot = false;
            StartCoroutine(WaitTillShoot(0.1f));
        }
        else if (Input.GetKeyDown(KeyCode.R)/*�������� �� ������*/ || (Input.GetButtonDown("Fire1") && Ammo <= 0))
        {
            StartCoroutine(Reload(2f));
            CanShoot = false;
        }
    }
    private IEnumerator Reload(float _time)//����� �������� ��� �� ����� ��������, � � ��� ����� ���������� �����, ������� �����������
    {
        yield return new WaitForSeconds(_time);
        Ammo = StartAmmo;
        CanShoot = true;
    }
    private IEnumerator WaitTillShoot(float _time)//����� ���� ����� �������� ������ � ����� � ���
    {
        yield return new WaitForSeconds(_time);
        CanShoot = true;
    }
}
