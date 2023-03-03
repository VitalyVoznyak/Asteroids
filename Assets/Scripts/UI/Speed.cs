using UnityEngine;
using TMPro;
using System;
public class Speed : MonoBehaviour
{   [SerializeField] Player player;
    [SerializeField] TMP_Text tMP_Text;
    private void Update() {
        float speed = player.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        if (speed > player.maxSpeed)
        {
            speed = player.maxSpeed;
        } 
        tMP_Text.text = "Speed : " + Math.Round(speed,1,MidpointRounding.ToEven) + " Km/Sec";
    }
}
