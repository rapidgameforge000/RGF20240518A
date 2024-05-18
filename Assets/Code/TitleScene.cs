namespace Assets.Code
{
    internal class TitleScene : UnityEngine.MonoBehaviour
    {
        private void Awake()
        {
            UnityEngine.QualitySettings.vSyncCount = 0;
            UnityEngine.Application.targetFrameRate = 30;
        }

        private void Update()
        {
            if (UnityEngine.Input.anyKeyDown)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
            }
        }
    }
}