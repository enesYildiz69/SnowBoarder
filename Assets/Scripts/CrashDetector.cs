using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delay;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground")
            Invoke("reloadScene", delay);
    }

    void reloadScene () {
        SceneManager.LoadScene(0);
    }
}
