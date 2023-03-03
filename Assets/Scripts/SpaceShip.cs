using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceShip : MonoBehaviour
{
    [SerializeField] GameObject boom;
    
    public void Boom()
    {
        Instantiate(boom, this.gameObject.transform.position, Quaternion.identity); // создание взрыва при уничтожении
    }
}
