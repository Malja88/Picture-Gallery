using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FullScreenImageController : MonoBehaviour
{
    public RawImage imageDisplay;
    private Texture2D selectedTexture;

    public static int SelectedImageIndex { get; set; }

    private void Start()
    {
        StartCoroutine(LoadTexture(SelectedImageIndex));
    }

    private IEnumerator LoadTexture(int imageIndex)
    {
        string imageUrl = "https://data.ikppbb.com/test-task-unity-data/pics/" + (imageIndex + 1) + ".jpg";
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                selectedTexture = texture;

                if (selectedTexture != null)
                {
                    imageDisplay.texture = selectedTexture;
                }
            }
            else
            {
                Debug.LogError("Failed to download image: " + www.error);
            }
        }
    }
}
