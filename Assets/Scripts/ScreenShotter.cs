#if (UNITY_EDITOR)

using System.IO;
using UnityEngine;

public class ScreenShotter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            DirectoryInfo di = new DirectoryInfo("Screenshots");
            int i = di.GetFiles().Length + 1;
            
            ScreenCapture.CaptureScreenshot($"Screenshots/screen_{i}.png");
        }
    }
}

#endif
