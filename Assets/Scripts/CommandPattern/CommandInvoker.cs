using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{


    PlayerControls inputAction;
    static Queue<ICommand> commandBuffer;
    static List<ICommand> commandHistory;

    static int counter;
    // Start is called before the first frame update
    void Start()
    {
        commandBuffer = new Queue<ICommand>();
        commandHistory = new List<ICommand>();

        inputAction = Controller.controller.inputAction;

        inputAction.Editor.Undo.performed += cntxt => UndoCommand();
    }

    // Update is called once per frame
    public static void AddCommand(ICommand command)
    {
        while(commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);

        }

        commandBuffer.Enqueue(command);
    }

    public void UndoCommand()
    {
        if(commandBuffer.Count <= 0)
        {
            if (counter > 0)
            {
                counter--;
                commandHistory[counter].Undo();
            }
        }
    }

    private void Update() 
    {
        if(commandBuffer.Count >  0)
        {
            ICommand c = commandBuffer.Dequeue();
            c.Execute();

            commandHistory.Add(c);
            counter++;
            Debug.Log("Command History Length: " + commandHistory.Count);
        }    
    }
}
