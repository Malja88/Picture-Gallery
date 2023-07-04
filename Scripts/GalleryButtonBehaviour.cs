using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryButtonBehaviour : MonoBehaviour
{
public void LoadGallery()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
