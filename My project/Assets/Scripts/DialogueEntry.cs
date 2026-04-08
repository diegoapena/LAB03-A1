using UnityEngine;

[System.Serializable]
public class DialogueEntry
{
    public string personaje;
    public string animo;        
    public string lineaDialogo;
    public string lugar;

    public DialogueEntry(string personaje, string animo, string linea, string lugar)
    {
        this.personaje = personaje;
        this.animo = animo;
        this.lineaDialogo = linea;
        this.lugar = lugar;
    }
}
