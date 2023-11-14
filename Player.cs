using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private int _currentNumberWeapon = 0;

    public int Money { get; private set; }

    private void Start()
    {
        _currentHealth = _health;
        _currentWeapon = _weapons[_currentNumberWeapon];
    }

    private void Update()
    {
        int button = 1;

        if (Input.GetMouseButtonDown(button))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if(_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddMoney(int money)
    {
        Money += money;
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;

        _weapons.Add(weapon);
    }

    public void NextWeapon()
    {
        _currentWeapon.gameObject.SetActive(false);

        if (_currentNumberWeapon == _weapons.Count - 1)
            _currentNumberWeapon = 0;
        else
            _currentNumberWeapon++;

        ChangeWeapon(_weapons[_currentNumberWeapon]);

        _currentWeapon.gameObject.SetActive(true);
    }

    public void PreviousWeapon()
    {
        _currentWeapon.gameObject.SetActive(false);

        if (_currentNumberWeapon == 0)
            _currentNumberWeapon = _weapons.Count - 1;
        else
            _currentNumberWeapon--;

        ChangeWeapon(_weapons[_currentNumberWeapon]);

        _currentWeapon.gameObject.SetActive(true);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}
