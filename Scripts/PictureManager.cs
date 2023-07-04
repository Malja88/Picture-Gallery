using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PictureManager : MonoBehaviour
{
    public Transform content;
    public GameObject imageTemplate;
    public GridLayoutGroup gridLayout;
    public string serverUrl = "https://data.ikppbb.com/test-task-unity-data/pics/";
    public int columns = 2;
    private int totalImages = 66;
    private int loadedImages = 0;
   
    private void Start()
    {
        StartCoroutine(LoadImages());
    }

    private IEnumerator LoadImages()
    {
        for (int i = 1; i <= totalImages; i++)
        {
            string imageUrl = serverUrl + i + ".jpg";
            yield return StartCoroutine(DownloadImage(imageUrl));
        }

        AdjustContentSize();
    }

    private IEnumerator DownloadImage(string url)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                CreateImage(texture);
            }
            else
            {
                Debug.LogError("Failed to download image: " + www.error);
            }
        }
    }

    private void CreateImage(Texture2D texture)
    {
        GameObject imageObject = Instantiate(imageTemplate, content);
        imageObject.SetActive(true);

        Image imageComponent = imageObject.GetComponent<Image>();
        imageComponent.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

        ImageItem imageItem = imageObject.AddComponent<ImageItem>();
        imageItem.imageIndex = loadedImages;

        loadedImages++;
    }

    private void AdjustContentSize()
    {
        int rows = Mathf.CeilToInt((float)totalImages / columns);
        int spacing = Mathf.CeilToInt(gridLayout.spacing.y);
        int cellSize = Mathf.CeilToInt((gridLayout.cellSize.y + spacing) * rows);
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, cellSize);
    }
}

