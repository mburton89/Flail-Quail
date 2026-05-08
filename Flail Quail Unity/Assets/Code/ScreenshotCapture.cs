using UnityEngine;

public class ScreenshotCapture : MonoBehaviour
{
    [Header("Screenshot Settings")]
    [Tooltip("Key to press for screenshot")]
    public KeyCode screenshotKey = KeyCode.P;

    [Tooltip("Base filename (numbers will be added automatically)")]
    public string fileName = "Screenshot";

    [Tooltip("Folder where screenshots will be saved (relative to project root in Editor)")]
    public string folderName = "Screenshots";

    [Tooltip("Apply 2x or 4x super sampling for higher quality")]
    [Range(1, 4)]
    public int superSize = 1;

    private int screenshotCount = 0;
    private string fullPath;

    private void Start()
    {
        // Create the screenshots folder if it doesn't exist
        fullPath = System.IO.Path.Combine(Application.persistentDataPath, folderName);

#if UNITY_EDITOR
        fullPath = System.IO.Path.Combine(Application.dataPath, "..", folderName);
#endif

        if (!System.IO.Directory.Exists(fullPath))
        {
            System.IO.Directory.CreateDirectory(fullPath);
            Debug.Log("Screenshots folder created at: " + fullPath);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(screenshotKey))
        {
            TakeScreenshot();
        }
    }

    public void TakeScreenshot()
    {
        screenshotCount++;

        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string finalFileName = $"{fileName}_{timestamp}_{screenshotCount}.png";
        string fullFilePath = System.IO.Path.Combine(fullPath, finalFileName);

        ScreenCapture.CaptureScreenshot(fullFilePath, superSize);

        Debug.Log($"✅ Screenshot saved: <color=green>{fullFilePath}</color>");

        // Optional: Show on-screen message
        ShowScreenshotMessage();
    }

    private void ShowScreenshotMessage()
    {
        // You can replace this with a proper UI notification later
        Debug.Log("📸 Screenshot taken!");
    }

    // Optional: Public method so other scripts can trigger it
    public void CaptureNow()
    {
        TakeScreenshot();
    }
}