using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public float lineDisplayDuration = 2.0f; // Time to display each line before moving to the next
    private int index;
    private float timer;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (textComponent.text == lines[index])
        {
            timer += Time.deltaTime;
            // Check if the timer has reached the display duration
            if (timer >= lineDisplayDuration)
            {
                NextLine();
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        timer = 0f; // Reset the timer
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)  // Corrected 'length' to 'Length'
        {
            index++;
            textComponent.text = string.Empty;
            timer = 0f; // Reset the timer for the next line
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
