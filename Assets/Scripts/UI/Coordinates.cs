using UnityEngine;
using TMPro;
using System;

public class Coordinates : MonoBehaviour
{
    [SerializeField] TMP_Text tMP_Text;
    [SerializeField] Transform playerTransform;
    
    private void Update() {
        tMP_Text.text = "Coordinates : " + Math.Round(playerTransform.position.x,1) + " : " +  Math.Round(playerTransform.position.y,1);
    }
}
