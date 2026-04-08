using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text txtPersonaje;
    [SerializeField] private TMP_Text txtAnimo;
    [SerializeField] private TMP_Text txtLugar;
    [SerializeField] private TMP_Text txtDialogo;

    private SimpleLinkedList<DialogueEntry> dialogueList = new SimpleLinkedList<DialogueEntry>();
    private bool isPlaying = false;

    private void Start()
    {
       
        dialogueList.Add(new DialogueEntry("Sans", "...", "Y tu , uno humano...?", "City"));
        dialogueList.Add(new DialogueEntry("Sans", "Serio", "Hace mucho que no viene alguien como tú...", "City"));
        dialogueList.Add(new DialogueEntry("Sans", "Serio", "Quisiera recordar que le paso al ultimo humano que aparecio en estas tierras", "City"));
        dialogueList.Add(new DialogueEntry("Sans", "Intrigado", "Pero , a que haz venido aqui...?", "city"));
        dialogueList.Add(new DialogueEntry("Sans", "Intrigado", "A dar un paseo turistico..?", "city"));
        dialogueList.Add(new DialogueEntry("Sans", "Intrigado", "visitar familiares de por aqui...?", "city"));
        dialogueList.Add(new DialogueEntry("Sans", "Serio", "No , no lo creo verdad..?", "city"));
        dialogueList.Add(new DialogueEntry("Me", "Asustado", "No se como llegue aqui...", "city"));
        dialogueList.Add(new DialogueEntry("Me", "Asustado", "Pero ,quiero saber como vuelvo a casa", "city"));
        dialogueList.Add(new DialogueEntry("Sans", "Serio", "El como llegaste no lo se..", "city"));
        dialogueList.Add(new DialogueEntry("Sans", "Serio", "Pero, puedo ayudarte a encontrar la salida...", "city"));
        dialogueList.Add(new DialogueEntry("Me", "entuciasmado", "!¿Lo dices enserio..!?", "city"));
        dialogueList.Add(new DialogueEntry("Me", "entuciasmado", "!Muchas gracias por la ayuda.!!", "city"));

        dialoguePanel.SetActive(false);
    }

   
   
    public void IniciarDialogoAutomatico()
    {
        if (isPlaying) return;
        isPlaying = true;
        dialoguePanel.SetActive(true);
        StartCoroutine(AutoPlayDialogue());
    }

    private IEnumerator AutoPlayDialogue()
    {
        Node<DialogueEntry> current = dialogueList.head;

        while (current != null)
        {
            DialogueEntry entry = current.Value;

          
            txtPersonaje.text = entry.personaje;
            txtAnimo.text = $"[{entry.animo}]";
            txtLugar.text = entry.lugar;

            
            yield return StartCoroutine(TypeDialogue(entry.lineaDialogo));

            
            yield return new WaitForSeconds(2.5f);

            current = current.Next;
        }

       
        yield return new WaitForSeconds(1f);
        dialoguePanel.SetActive(false);
        isPlaying = false;

        Debug.Log(" Diálogo automático terminado");
    }

    
    private IEnumerator TypeDialogue(string fullText)
    {
        txtDialogo.text = "";
        foreach (char letter in fullText)
        {
            txtDialogo.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }
}
