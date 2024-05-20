using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager : MonoBehaviour
{
    [SerializeField] private int indexModuleStartUp;
    [SerializeField] private List<BaseModuleBootstrap> moduleBootstraps;

    private void Awake()
    {
        int count = moduleBootstraps.Count;

        if (indexModuleStartUp > count)
            indexModuleStartUp = count;
        else if(indexModuleStartUp < 1)
            indexModuleStartUp = 1;

        moduleBootstraps[indexModuleStartUp - 1].InitializationModule();
    }
}
