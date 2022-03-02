using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector3 deltaPosition = transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * 25f + transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * 25f;
        deltaPosition.y = 0f;
        transform.position += deltaPosition;
    }
}
