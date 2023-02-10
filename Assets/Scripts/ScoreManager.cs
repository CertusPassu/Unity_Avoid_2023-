using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    private float score = 0.0f;
    [SerializeField] TMP_Text scoreText;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 15;
    private int scoreToNextLevel = 10;
    private bool isDead;

    [SerializeField] DeathMenu deathMenu;
    void Start()
    {
        
    }


    void Update()
    {
        if (isDead)
            return;
        if (score >= scoreToNextLevel)
            LevelUp();
        ScorePoint();
    }

    private void ScorePoint ()
    {
        score += Time.deltaTime * difficultyLevel;
        scoreText.text = "Score: " + ((int)score).ToString();
    }

    private void LevelUp()
    {
        scoreToNextLevel *= 2;
        difficultyLevel++;
        GetComponent<PlayerController>().SetSpeed(difficultyLevel);
    }
    public void OnDie()
    {
        isDead = true;
        deathMenu.ToggleEndMenu(score);
    }
}
