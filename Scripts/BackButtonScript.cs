using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButtonScript : MonoBehaviour
{
    public Button backButton;
    void Start()
    {
        backButton.onClick.AddListener(Back);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
