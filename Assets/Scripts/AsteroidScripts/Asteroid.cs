using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Asteroid : MonoBehaviour // наследуемый класс для астероидов а так же их асколков
{
    public delegate void AsteroidDestroy();
    [SerializeField] GameObject boom;
    private void OnDestroy() 
    {
        Instantiate(boom, this.gameObject.transform.position,Quaternion.identity); // создание взрыва
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage();
        }   
    }
}
