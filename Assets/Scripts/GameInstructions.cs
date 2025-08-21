using System.Collections;
using UnityEngine;
using TMPro; // If using TextMeshPro

public class GameInstructions : MonoBehaviour
{
    public TextMeshProUGUI instructionText; 
    public string[] instructions; 
    public float displayTime = 3f; 

    private int currentInstruction = 0;

    void Start()
    {
        StartCoroutine(DisplayInstructions());
    }

    IEnumerator DisplayInstructions()
    {
        // Loop through each instruction
        while (currentInstruction < instructions.Length)
        {
            instructionText.text = instructions[currentInstruction]; 
            yield return new WaitForSeconds(displayTime); 
            currentInstruction++; 
        }
        
        instructionText.text = ""; 
    }
}
