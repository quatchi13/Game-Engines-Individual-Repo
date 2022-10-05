using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public Canvas editorUI;

    bool editorMode;


    // Start is called before the first frame update
    void Start()
    {
        editorMode = GetComponent<EditorManager>().isEditing;

        if(editorMode == false)
        {
            editorUI.enabled = false;
        }
    }

    public void ToggleEditorUI()
    {
        editorUI.enabled = !editorUI.enabled;
    }
}
