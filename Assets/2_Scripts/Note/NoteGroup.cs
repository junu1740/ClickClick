using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxMum = 5;
    [SerializeField] private GameObject notePrefab;
    void Start()
    {
        GameObject noteGameObj = Instantiate(notePrefab);
        Note note = noteGameObj.GetComponent<Note>();
        
    }

    void Update()
    {
        
    }
}
