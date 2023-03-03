using UnityEngine;

class BigAsteroid : Asteroid ,IDamageable
{
    public static AsteroidDestroy bigAsteroidDestroy;
    [SerializeField] AsteroidPart[] asteroidParts;
    float speed; //скорость движения астеройда
    public Vector2 vectorToMove; // в какую сторону лететь
    private void Start() 
    {
        transform.Rotate(0,0,new System.Random().Next(1,360));// даем случайный повород при создании
        transform.localScale = new Vector3(Random.Range(1f,4f),Random.Range(1f,4f),Random.Range(1f,4f)); //даем случайный размер астероиду
        Destroy(this.gameObject,15);
    }
    private void FixedUpdate() 
    {
        transform.Translate(vectorToMove * 0.005f,Space.World);
    }
    public void TakeDamage()
    {
        foreach (AsteroidPart asteroidPart in asteroidParts)
        {
            asteroidPart.OnParentDestroy();
        }
        bigAsteroidDestroy.Invoke();
        Destroy(this.gameObject);
    }
}
