using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneLoader : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Homebase", LoadSceneMode.Single);
    }

}
