using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour {
    
    public void LoadScene(int c)
    {
        SceneManager.LoadScene(c);
    }

    
}
