using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighscoreManager.Instance.LoadHighscore();
        scoreText.text = HighscoreManager.Instance.GetScoreText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        HighscoreManager.Instance.currentUsername = nameField.text;
        SceneManager.LoadScene(0);
    }

    public void QuitApp()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    }
    #endif
    }
}
