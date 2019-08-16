using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject ThanksText;

    public void Start()
    {
        if (GameManager.GameWon == true)
        {
            ThanksText.SetActive(true);
        }
    }

    public void LoadLevel()
    {
        GameManager.Score = 0;
        GameManager.Lives = 3;
        SceneManager.LoadScene(1);
    }
}
