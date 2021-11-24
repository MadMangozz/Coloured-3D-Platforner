using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
   private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
