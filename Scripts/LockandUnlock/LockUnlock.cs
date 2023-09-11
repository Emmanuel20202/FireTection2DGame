using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LockUnlock : MonoBehaviour
{
    public Button[] levelButtons; // The UI buttons for each level
    public string[] sceneNames; // The names of the scenes corresponding to each level
    public Image lockImagePrefab; // Reference to the lock image UI prefab

    private Image[] lockImages; // Array to hold references to the lock images

    private void Start()
    {
        // Disable all level buttons by default
        foreach (Button button in levelButtons)
        {
            button.interactable = false;
        }

        // Unlock the first level
        PlayerPrefs.SetInt(sceneNames[0] + "Unlocked", 1);

        // Create lock images for locked buttons and enable unlocked buttons
        lockImages = new Image[levelButtons.Length];

        for (int i = 0; i < levelButtons.Length; i++)
        {
            bool isUnlocked = PlayerPrefs.GetInt(sceneNames[i] + "Unlocked", 0) == 1;

            if (isUnlocked)
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                // Instantiate the lock image prefab and set it as a child of the button
                Image lockImage = Instantiate(lockImagePrefab, levelButtons[i].transform);
                lockImage.transform.localPosition = Vector3.zero;

                // Add the lock image to the lockImages array
                lockImages[i] = lockImage;
            }
        }
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
