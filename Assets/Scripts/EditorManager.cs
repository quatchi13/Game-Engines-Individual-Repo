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

    

    public Camera gameCam;
    public Camera editorCam;

    public bool isEditing = false;
    bool instantiated;

    public Vector3 mousePos;

    Subject subject = new Subject();



    // Start is called before the first frame update
    void Start()
    {
        inputActions = PlayerInputController.controller.inputAction;

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
        //replace with SceneControl.instance.GetCurrentScene() == 1
        if(true)
        {
            if(gameCam.enabled == false && editorCam.enabled ==true)
        { 
            {
                isEditing = true;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
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

        if(instantiated)
        {
            mousePos = Mouse.current.position.ReadValue();
            mousePos = new Vector3(mousePos.x, mousePos.y, 7);

            item.transform.position = editorCam.ScreenToWorldPoint(mousePos);
        }
        
    }

    private void SwitchCam()
    {
        gameCam.enabled = !gameCam.enabled;
        editorCam.enabled = !editorCam.enabled;
    }

    private void AddItem(int itemNumber)
    {
        if(isEditing && !instantiated)
        {


            switch(itemNumber)
            {
                case 1:
                item = Instantiate(prefab1);
                    SpikeBall spike1 = new SpikeBall(item, new GreenMat());
                    subject.AddObserver(spike1);
                break;
                case 2:
                item = Instantiate(prefab2);
                SpikeBall spike2 = new SpikeBall(item, new YellowMat());
                subject.AddObserver(spike2);
                break;
                default:
                break;
            }


            subject.Notify();
            instantiated = true;
        }
    }

    private void ConfirmPlacement()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<SphereCollider>().enabled = true;

        instantiated = false;

    }
}
