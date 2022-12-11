using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript : MonoBehaviour
{
    [SerializeField]
    private Text score;
    
    //score = GetComponent<UnityEngine.UI.Text>();
    // Start is called before the first frame update
    void Start()
    {

        score.text = "0";

    }

    public void UpdateScore(int playerscore)
    {
        score.text = playerscore.ToString();
    }

    public void ClearScore()
    {
        score.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}
