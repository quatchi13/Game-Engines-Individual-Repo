using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorManager : MonoBehaviour
{

    PlayerControls inputActions;

    [SerializeField]
    private GameObject prefab1;

    [SerializeField]
    private GameObject prefab2;

    GameObject item;

    bool instiated = false;

    public Camera gameCam;
    public Camera editorCam;

    public bool isEditing = false;

    private void OnEnable() {
        inputActions.Enable();
    }

    private void OnDisable() {
        inputActions.Disable();
    }

    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new PlayerControls();

        inputActions.Editor.Activate.performed += cntxt => SwitchCam();

        inputActions.Editor.AddItem1.performed += cntxt => AddItem(1);

        inputActions.Editor.AddItem2.performed += cntxt => AddItem(2);

        inputActions.Editor.Confirm.performed += cntxt => ConfirmPlacement();

        gameCam.enabled = true;
        editorCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneControl.instance.GetCurrentScene() == 1)
        {
            if (gameCam.enabled == false && editorCam.enabled == true)
            {

                isEditing = true;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                isEditing = false;
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
    }

    private void SwitchCam()
    {
        gameCam.enabled = !gameCam.enabled;
        editorCam.enabled = !editorCam.enabled;
    }

    private void AddItem(int itemNumber)
    {
        if(isEditing && !instiated)
        {

            if(itemNumber == 1)
            {
                item = Instantiate(prefab1);

            }
            else if (itemNumber == 2)
            {
                item = Instantiate(prefab2);
            }
            else
            {
                return;
            }

            instiated = true;
        }
    }

    private void ConfirmPlacement()
    {


    }
}
