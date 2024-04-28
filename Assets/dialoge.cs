using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dialoge : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] dialogueLines;
    public TextMeshProUGUI dialogueText; // Referencia al componente TextMeshPro
    private List<string> currentPages; // Lista para guardar las p�ginas del di�logo actual
    private int currentPageIndex; // �ndice de la p�gina actual
    private int currentLineIndex = 0;
    private bool displayingDialogue = false;

    public string nextSceneName; // Nombre de la pr�xima escena a cargar

    void Start()
    {
        currentPages = new List<string>();
    }

    void OnMouseEnter()
    {
        if (!displayingDialogue)
        {
            displayingDialogue = true;
            currentLineIndex = 0;
            SetupPages(dialogueLines[currentLineIndex]);
            DisplayCurrentPage();
        }
    }

    void Update()
    {
        if (displayingDialogue && Input.GetMouseButtonDown(0)) // Cambiar a clic para avanzar
        {
            currentPageIndex++;
            if (currentPageIndex < currentPages.Count)
            {
                DisplayCurrentPage();
            }
            else
            {
                currentLineIndex++;
                if (currentLineIndex < dialogueLines.Length)
                {
                    SetupPages(dialogueLines[currentLineIndex]);
                    DisplayCurrentPage();
                }
                else
                {
                    displayingDialogue = false;
                    dialogueText.text = "";
                    SceneManager.LoadScene(nextSceneName); // Cargar la pr�xima escena
                }
            }
        }
    }

    void SetupPages(string dialogue)
    {
        currentPages.Clear();
        currentPageIndex = 0;
        const int maxCharacters = 200; // M�ximo de caracteres por p�gina

        for (int i = 0; i < dialogue.Length; i += maxCharacters)
        {
            if (i + maxCharacters < dialogue.Length)
                currentPages.Add(dialogue.Substring(i, maxCharacters));
            else
                currentPages.Add(dialogue.Substring(i));
        }
    }

    void DisplayCurrentPage()
    {
        dialogueText.text = currentPages[currentPageIndex];
    }

    void OnMouseExit()
    {
        displayingDialogue = false;
        dialogueText.text = "";
    }
}
