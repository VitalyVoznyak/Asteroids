using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public delegate void Shooting();
    public static Shooting onShoot;
    public static Shooting onRechargeComplete;
    [SerializeField] BoxCollider2D laserCollider;
    [SerializeField] Color colorThenLaserOn = new Color (1,1,1,1);// цвет лазера в начале выстрела
    [SerializeField] SpriteRenderer spriteRenderer; 
    [SerializeField] GameObject sourseOfTheShoot;//источник выстрела
    [SerializeField] Transform laserPos; //позиция лазера
    [SerializeField] AudioSource audioSource; // звук выстрела
    public int numberOfProjectiles; // количество снарядов
    public int MaxNumberOfProjectiles;// количество вмещаемых снарядов
    public float rechargeTime; //время перезарядки в секундах
    public float rechargeTimeLeft; //время перезарядки в секундах (Осталось)
    public bool isRecharging; //идет ли уже перезарядка?

    public void Shoot() // выстрел
    {
        if(numberOfProjectiles >= 1 && spriteRenderer.color.a <1)
        {   
            transform.position = laserPos.position;
            transform.rotation = laserPos.rotation;
            numberOfProjectiles --;
            laserCollider.enabled = true;
            spriteRenderer.color = colorThenLaserOn;
            StartCoroutine(ShootFade()); 
            if (!isRecharging) StartCoroutine(Recharge());
            audioSource.Play();
            onShoot.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D collider) // при соприкосновении наносит урон объекту
    {
        collider.gameObject.TryGetComponent(out IDamageable damageable);

        if (collider.gameObject != sourseOfTheShoot && spriteRenderer.color.a > 0)
        {
            damageable.TakeDamage();
        } 
    }
    IEnumerator Recharge()//перезарядка
    {   
        isRecharging = true;
        for (rechargeTimeLeft = rechargeTime; rechargeTimeLeft > 0; rechargeTimeLeft -= 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
        }
        numberOfProjectiles ++;
        onRechargeComplete.Invoke();
        if (numberOfProjectiles < MaxNumberOfProjectiles)
        {
            StartCoroutine(Recharge()); //вызываем перезарядку до тех пор, пока не наберем полную обойму.
        } else
        {
            isRecharging = false;
        }
    }
    IEnumerator ShootFade() // утихание лазера после выстрела
    {
        for (float a = 1; a > 0; a -= 0.02f)
        {
            spriteRenderer.color = new Color(1,1,1,a);
            yield return new WaitForSeconds(0.01f);
        }
        laserCollider.enabled = false;
    }
}
