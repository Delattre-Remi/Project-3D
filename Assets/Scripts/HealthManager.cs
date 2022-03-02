using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    TextMesh Health;
    int healthvalue = 10;
    private void OnCollisionEnter(Collision collision)
    {
        Health.text = "HP :" + healthvalue;
    }
}
