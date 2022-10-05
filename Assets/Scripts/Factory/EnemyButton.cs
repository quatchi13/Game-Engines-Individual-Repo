using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyButton : MonoBehaviour
{

    private EnemyFactory factory;

    private EditorManager editor;

    
    TextMeshProUGUI buttonText;

    // Start is called before the first frame update
    void Start()
    {
        factory = GameObject.Find("GameManager").GetComponent<EnemyFactory>();
        editor = EditorManager.instance;
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnClickSpawn()
    {

        switch (buttonText.text)
        {
            case "Crab":
                editor.item = factory.GetEnemy("Crab").Create(factory.prefab1);
                break;

            case "Monster":
                editor.item = factory.GetEnemy("Monster").Create(factory.prefab1);
                break;

        }

    }

}
