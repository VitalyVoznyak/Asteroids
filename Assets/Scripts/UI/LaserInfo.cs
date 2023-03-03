
using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class LaserInfo : MonoBehaviour
{
    [SerializeField] Laser laser;
    [SerializeField] TMP_Text tmpLaserProgectiles;
    [SerializeField] TMP_Text tmpLaserRecharge;
    
    private void Start() 
    {
        Laser.onShoot += OnLaserShoot;
        Laser.onRechargeComplete += OnRechargeComplete; 
    }
    void OnLaserShoot()
    {
        tmpLaserProgectiles.text = "Laser Projectiles : " + laser.numberOfProjectiles;
        StartCoroutine(RechargeUpdate());
    }
    void OnRechargeComplete()
    {
        tmpLaserProgectiles.text = "Laser Projectiles : " + laser.numberOfProjectiles;
    }
    IEnumerator RechargeUpdate()
    {
        while (laser.isRecharging)
        {
            tmpLaserRecharge.text = "Recharge : " + Math.Round(laser.rechargeTimeLeft,2);
            yield return new WaitForSeconds(0.1f);
        }
        tmpLaserRecharge.text = "Recharge : -";
    }
}
