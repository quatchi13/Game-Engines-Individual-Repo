using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorManager : MonoBehaviour
{

    public static EditorManager instance;

    PlayerControls inputActions;

    [SerializeField]
    private GameObject prefab1;

    [SerializeField]
    private GameObject prefab2;

    public GameObject item;

    public bool instiated = false;

    public Camera gameCam;
    public Camera editorCam;

    public bool isEditing = false;

    ICommand command;

    UIManager ui;

    private void OnEnable() {
        inputActions.Enable();
    }

    private void OnDisable() {
        inputActions.Disable();
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(instance = null)
        {
            instance = this;
        }

        inputActions = new PlayerControls();

        inputActions.Editor.Activate.performed += cntxt => SwitchCam();

        inputActions.Editor.AddItem1.performed += cntxt => AddItem(1);

        inputActions.Editor.AddItem2.performed += cntxt => AddItem(2);

        inputActions.Editor.Confirm.performed += cntxt => ConfirmPlacement();

        gameCam.enabled = true;
        editorCam.enabled = false;

        ui = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
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

    private void SwitchCam()
    {
        gameCam.enabled = !gameCam.enabled;
        editorCam.enabled = !editorCam.enabled;
        ui.ToggleEditorUI();
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
        if(isEditing && instiated)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Collider>().enabled = true;

            //command = new 

            instiated = false;
        }

    }
}
