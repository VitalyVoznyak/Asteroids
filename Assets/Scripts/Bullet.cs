using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public delegate void BulletShot();
    public static BulletShot onBulletShot;
    [SerializeField] float speed;
    public GameObject sourseOfTheShoot;// источник выстрела
    
    private void Start() 
    {
        onBulletShot.Invoke();
        Destroy(this.gameObject,4); // со временем пуля удаляется со сцены
        transform.Translate(Vector3.up * 0.5f);// чтобы пуля спаунилась не прям в корабле который его стреляет
    }
    private void FixedUpdate() {
        transform.Translate(Vector3.up * speed);   
    }
    private void OnCollisionEnter2D(Collision2D collider) 
    {
        collider.gameObject.TryGetComponent(out IDamageable damageable);

        if (collider.gameObject != sourseOfTheShoot)
        {
            damageable.TakeDamage();
            Destroy(this.gameObject);
        } 
    }
}
