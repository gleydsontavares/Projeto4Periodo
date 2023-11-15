using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGarageScene()
    {
        SceneManager.LoadScene("Garage");
    }
}
