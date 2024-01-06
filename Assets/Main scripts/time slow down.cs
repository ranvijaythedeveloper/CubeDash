using UnityEngine;
using System.Collections;

public class TimeSlowDown : MonoBehaviour
{
    
    public float SlowDownMagnitude = 0.5f;
    public float Timer = 3f;
    private void OnTriggerEnter()
    {
        
            // Decrease time scale
            Time.timeScale = 1f - SlowDownMagnitude;

             // Destroy the 
            
            // Start the restoration timer
            StartCoroutine(nameof(StartRestorationTimer));

            
        
    }

    private IEnumerator StartRestorationTimer()
    {
        yield return new WaitForSeconds(Timer);
        Time.timeScale = 1f;
    }

}