using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource bigAsteroidBoomSound;
    [SerializeField] AudioSource smallAsteroidBoomSound;
    [SerializeField] AudioSource bulletShootSound;
    private void Start() 
    {
        BigAsteroid.bigAsteroidDestroy += OnBigAsteroidBoom;
        AsteroidPart.smallAsteroidDestroy += OnSmallAsteroidBoom;
        Bullet.onBulletShot += OnBulletShot;
    }
    void OnBigAsteroidBoom(){
        bigAsteroidBoomSound.Play();
    }
    void OnSmallAsteroidBoom(){
        smallAsteroidBoomSound.Play();
    }
    void OnBulletShot(){
        bulletShootSound.Play();
    }
}
