using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 ) ; 
    }

}
