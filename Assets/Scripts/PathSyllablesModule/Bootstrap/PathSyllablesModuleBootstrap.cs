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

        public override void InitializationModule()
        {
        }

        public override ModuleDataBase GetModuleData() => moduleData;
    }
}