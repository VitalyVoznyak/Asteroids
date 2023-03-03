using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : SpaceShip ,IDamageable
{
    [SerializeField] GameObject bullet;
    [SerializeField] float speed;
    private GameObject player;
    private void FixedUpdate() {
        Move();
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage();
        }
    }
    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Shoot();
    }
    void Move()
    {
        transform.transform.Translate((player.transform.position - transform.position) * speed);
    }
    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet,transform.position, Quaternion.identity);                           
        newBullet.GetComponent<Bullet>().sourseOfTheShoot = this.gameObject;//объясняем создаваемой пуле, кто ее выстрелил 
        newBullet.transform.LookAt(player.transform.position);
    }
    public void TakeDamage ()
    {
        Destroy(this.gameObject);
    }
}
