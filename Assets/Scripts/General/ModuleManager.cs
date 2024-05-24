using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModuleManager : MonoBehaviour
{
    [SerializeField] private Image backGroundImage;
    [SerializeField] private Text taskText;
    [SerializeField] private int indexModuleStartUp;
    [SerializeField] private List<BaseModuleBootstrap> moduleBootstraps;

    private void Awake()
    {
        int count = moduleBootstraps.Count;

        if (indexModuleStartUp > count)
            indexModuleStartUp = count;
        else if (indexModuleStartUp < 1)
            indexModuleStartUp = 1;

        BaseModuleBootstrap moduleBootstrap = moduleBootstraps[indexModuleStartUp - 1];
        moduleBootstrap.InitializationModule();
        ModuleDataBase moduleData = moduleBootstrap.GetModuleData();
        taskText.text = moduleData.TaskText;
        backGroundImage.sprite = moduleData.BackGroundSprite;
    }
}
