using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Image backgroundImage;
    private bool isShowing;
    private float transition = 0.0f;

    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShowing)
            return;
        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
    }
    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = "You scored: " + ((int)score).ToString();
        isShowing = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
