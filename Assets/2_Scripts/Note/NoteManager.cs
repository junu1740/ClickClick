using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private GameObject noteGroupPrefab;
    [SerializeField] private float noteGroupGap = 1f;
    [SerializeField]
    private KeyCode[] wholeKeyCodeArr = new KeyCode[]
    {
        KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G,
        KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L
    };
    [SerializeField] private int initNoteGroupNum = 2;

    public static NoteManager Instance;
    private List<NoteGroup> noteGroupList = new List<NoteGroup>();
    private void Awake()
    {
        Instance = this;
    }
    public void Create()
    {
        for (int i = 0; i < initNoteGroupNum; i++)
        {
            CreateNoteGroup(wholeKeyCodeArr[i]);
        }
    }




    public void CreateNoteGroup()
    {
        SoundMAnager.Instance.Sound(2);
        Debug.Log("succes");
        int noteGroupCount = noteGroupList.Count;
        if (wholeKeyCodeArr.Length <= noteGroupCount)
            return;
        KeyCode keyCode = wholeKeyCodeArr[noteGroupCount];
        CreateNoteGroup(keyCode);
    }


    public void CreateNoteGroup(KeyCode keyCode)
    {
        GameObject noteGroupObj = Instantiate(noteGroupPrefab);
        noteGroupObj.transform.position = Vector3.right * noteGroupList.Count * noteGroupGap;


        NoteGroup noteGroup = noteGroupObj.GetComponent<NoteGroup>();
        noteGroup.Create(keyCode);

        noteGroupList.Add(noteGroup);
    }

    public void OnInput(KeyCode keyCode)
    {
        int randld = Random.Range(0, 2);
        bool isApple = randld == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keyCode == noteGroup.KeyCode)
            {
                noteGroup.OnInput(isApple);
                break;
            }
        }
    }
}
