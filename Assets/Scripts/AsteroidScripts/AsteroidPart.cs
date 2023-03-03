using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPart : Asteroid, IDamageable
{
    public static AsteroidDestroy smallAsteroidDestroy;
    [SerializeField] Transform pointToMove;//точка, куда двигаться при отсоединении от родителя
    [SerializeField] Vector2 directionToMove;//Направление, куда двигаться при отсоединении от родителя
    [SerializeField] bool isMove;// начал ли самостоятельное движение
    [SerializeField] float speed;// то, с какой скоростью отлетает от родителя
    
    public void OnParentDestroy() //когда родительский объект-астероид уничтожен
    {
        transform.parent = null;
        GetComponent<CircleCollider2D>().enabled = true;// включаем коллайдер
        isMove = true;
        speed = Random.Range(0.03f,0.06f); // даем осколку случайную скорость
        directionToMove = (pointToMove.position - transform.position);//получаем направление движения
        Destroy(pointToMove.gameObject); //удаляем ненужное со сцены 
        Destroy(this.gameObject, 8);// самоуничтожаем осколок через время, чтобы не захламлять сцену
    }
    private void FixedUpdate() {
        if(isMove)
        {
            move();
        }
    }
    void move()// движение осколка
    {
        transform.Translate((directionToMove) * speed, Space.World);  
    }
    public void TakeDamage()
    {
        smallAsteroidDestroy.Invoke();
        Destroy(this.gameObject);
    }
}
