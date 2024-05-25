using SubstitutionLettersModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathSyllablesModule
{
    public class PathSyllablesModuleBootstrap : BaseModuleBootstrap
    {
        [SerializeField] private ModulePathSyllablesData moduleData;

        [SerializeField] private StoneMatrixController stoneMatrixController;

        public override void InitializationModule()
        {
            stoneMatrixController.Initialize();
        }

        public override ModuleDataBase GetModuleData() => moduleData;
    }
}