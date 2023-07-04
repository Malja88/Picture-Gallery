using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageItem : MonoBehaviour
{
    public int imageIndex;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OpenFullScreen);
    }
    public void OpenFullScreen()
    { 
        FullScreenImageController.SelectedImageIndex = imageIndex;
        SceneManager.LoadScene("EnlargedScene");
    }
}
