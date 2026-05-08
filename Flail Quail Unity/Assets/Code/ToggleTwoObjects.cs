using UnityEngine;

public class ToggleTwoObjects : MonoBehaviour
{
    [Header("Two GameObjects to toggle")]
    public GameObject objectA;
    public GameObject objectB;

    [Header("PlayerPrefs Key")]
    public string prefsKey = "LastUsedObject"; // Change if needed

    private void Awake()
    {
        // This runs every time the scene loads
        ToggleObjects();
    }

    private void ToggleObjects()
    {
        if (objectA == null || objectB == null)
        {
            Debug.LogWarning("ToggleTwoObjects: One or both GameObjects are not assigned!");
            return;
        }

        // Read current state from PlayerPrefs (default to 0 if not set)
        int lastUsed = PlayerPrefs.GetInt(prefsKey, 0);

        // Toggle logic
        if (lastUsed == 0)
        {
            objectA.SetActive(true);
            objectB.SetActive(false);
            PlayerPrefs.SetInt(prefsKey, 1); // Next time use B
        }
        else
        {
            objectA.SetActive(false);
            objectB.SetActive(true);
            PlayerPrefs.SetInt(prefsKey, 0); // Next time use A
        }

        PlayerPrefs.Save();
    }
}