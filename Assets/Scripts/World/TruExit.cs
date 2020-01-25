using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TruExit : MonoBehaviour
{
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            
                SceneManager.LoadScene(1);
                
            
        }
        
    }
}
