using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, 100))
        {
            Debug.DrawRay(transform.position, fwd, Color.green);
            Debug.Log("COLLISIONNNNNNNNNNNNNNNN");
            SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
        }
    }
}
