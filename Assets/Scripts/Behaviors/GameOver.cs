using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void Start() {
        AudioManager.instance.PlaySFX(AudioManager.instance.death);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
