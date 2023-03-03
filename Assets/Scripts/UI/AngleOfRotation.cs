using UnityEngine;
using TMPro;
using System;

public class AngleOfRotation : MonoBehaviour
{
    [SerializeField] TMP_Text tMP_Text;
    [SerializeField] Transform playerTransform;
    float rotation;
    private void Update() 
    {
        tMP_Text.text = "Rotation : " + (360-Math.Round(playerTransform.eulerAngles.z)) + "°";
    }
}
