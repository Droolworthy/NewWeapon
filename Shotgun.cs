using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int _amountOfBullets;
    [SerializeField] private int _angle;

    public override void Shoot(Transform shootPoint)
    {
        for (int i = 0; i < _amountOfBullets; i++)
        {
            Instantiate(ShotgunBullet, shootPoint.position, Quaternion.AngleAxis(_angle, Vector3.forward));
        }
    }  
}
