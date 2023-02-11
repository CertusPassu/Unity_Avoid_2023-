using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = "Highscore: " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
