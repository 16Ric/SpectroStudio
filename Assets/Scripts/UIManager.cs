using UnityEngine;
using TMPro;  // Make sure to include the TextMeshPro namespace

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI booksReadText;  // Drag your TextMesh Pro UGUI component here from the inspector

    public void UpdateBooksRead(int booksRead, int totalBooks)
    {
        if (booksReadText != null)
        {
            booksReadText.text = booksRead + "/" + totalBooks + " books read";
        }
    }
}
