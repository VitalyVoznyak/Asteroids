using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    TMP_Text tMP_Text;
    public int score;

    private void Start() 
    {
        tMP_Text = gameObject.GetComponent<TMP_Text>();
        BigAsteroid.bigAsteroidDestroy += OnBigAsteroidBoom;
        AsteroidPart.smallAsteroidDestroy += OnSmallAsteroidBoom;
        Player.onDestroy += OnPlayerDestroy;
    }
    void OnBigAsteroidBoom(){
        score += 5;
        ScoreUpdate();
    }
    void OnSmallAsteroidBoom(){
        score += 7;
        ScoreUpdate();
    }
    void OnUfoBoom(){
        score += 25;
        ScoreUpdate();
    }
    void ScoreUpdate(){
        tMP_Text.text = "Score : " + score;
    }
    void OnPlayerDestroy()
    {
        PlayerPrefs.SetInt("LastScore",score);
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore",score);
        }
        else
        {
            if (PlayerPrefs.GetInt("BestScore") < score)
            {
                PlayerPrefs.SetInt("BestScore",score);
            }
        }
    }
}
