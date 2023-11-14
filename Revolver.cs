using UnityEngine;

public class Revolver : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(RevolverBullet, shootPoint.position, Quaternion.identity);
    }
}
