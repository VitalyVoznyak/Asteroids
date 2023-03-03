using UnityEngine;
using System;

public class Player : SpaceShip , IDamageable
{
    public delegate void PlayersEvent();
    public static PlayersEvent onDestroy; 
    [SerializeField] Laser laser; // наш лазер
    [SerializeField] GameObject bullet; // префаб пули
    [SerializeField] PlayerMove playerMove;// скрипт, отвечающий за движение корабля
    [SerializeField] Vector2 edge;// границы экрана
    [SerializeField] float accelerationSpeed;// скорость разгона
    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite idleSprite; // обычный спрайт
    [SerializeField] Sprite moveForwardSprite;// спрайт при движении вперед
    [SerializeField] AudioSource moveSound;
    public float maxSpeed; // макс. скорость
    [SerializeField] float rotSpeed; // скорость поворота
    new Rigidbody2D rigidbody;
    
    private void Start() 
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerMove = new PlayerMove(this.gameObject,accelerationSpeed,rotSpeed,maxSpeed);// задаем характеристики корабля
    }
    private void Update() 
    {
        InputCheck(); //проверка нажатий на клавиши
        EdgeCheck();  //проверяем, не вышли ли мы за границы экрана
    }

    void InputCheck()
    {
        if (Input.GetKey(KeyCode.W)){
            playerMove.Forward();
        }
        if (Input.GetKeyDown(KeyCode.W)){
            spriteRenderer.sprite = moveForwardSprite;
            moveSound.volume = 1;
        }
        if (Input.GetKeyUp(KeyCode.W)){
            spriteRenderer.sprite = idleSprite;
            moveSound.volume = 0;
        }
        if (Input.GetKey(KeyCode.D)){
            playerMove.RotRight();
        }
        if (Input.GetKey(KeyCode.A)){
            playerMove.RotLeft();
        }
        if (Input.GetMouseButtonDown(0)){
            Bulletshot();
        }
        if (Input.GetMouseButtonDown(1)){
            laser.Shoot();
        }
    }
    void EdgeCheck()
    {
        if (Mathf.Abs(transform.position.x) >= edge.x)
        {
            transform.position = new Vector2(
                - transform.position.x + (Math.Sign(transform.position.x) * 0.1f),
                transform.position.y
            );
        }
        if (Mathf.Abs(transform.position.y) >= edge.y)
        {
            transform.position = new Vector2(
                transform.position.x,
                - transform.position.y + (Math.Sign(transform.position.y) * 0.1f)
            );
        }
    }
    public void TakeDamage()
    {
        onDestroy.Invoke();
        Destroy(this.gameObject);
    }
    public void Bulletshot()
    {
        GameObject newBullet = Instantiate(bullet,this.gameObject.transform.position,this.gameObject.transform.rotation);                                      
        newBullet.GetComponent<Bullet>().sourseOfTheShoot = this.gameObject;//объясняем создаваемой пуле, кто ее выстрелил 
    }
}
