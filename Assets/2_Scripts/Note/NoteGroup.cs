using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxMum = 5;
    [SerializeField] private GameObject notePrefab;

    private List<Note> noteList = new List<Note>();
    void Start()
    {
        for(int i = 0; i < noteMaxMum; i++)
        {
            GameObject noteGameObj = Instantiate(notePrefab);
            Note note = noteGameObj.GetComponent<Note>();
            noteList.Add(note);
        }
       
        
    }

    void Update()
    {
        
    }
}
