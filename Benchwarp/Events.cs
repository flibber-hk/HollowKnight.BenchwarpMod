﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using GlobalEnums;

namespace Benchwarp
{
    public static class Events
    {
        public static readonly SequentialEventHandler<string> OnGetSceneName = new();
        public static string GetSceneName(string sceneName) => OnGetSceneName.Invoke(sceneName);


        public static readonly SequentialEventHandler<string> OnGetBenchName = new();
        public static string GetBenchName(string benchName) => OnGetBenchName.Invoke(benchName);


        public static readonly SequentialEventHandler<(string respawnScene, string respawnMarkerName, int respawnType, int mapZone)>
            OnGetStartDef = new();
        public static (string respawnScene, string respawnMarkerName, int respawnType, int mapZone) GetStartDef() =>
            OnGetStartDef.Invoke(("Tutorial_01", "Death Respawn Marker", 0, 2));
        public static bool AtStart()
        {
            (string respawnScene, string respawnMarkerName, int _, int _) = GetStartDef();
            return !Benchwarp.LS.atDeployedBench
                && respawnScene == PlayerData.instance.respawnScene 
                && respawnMarkerName == PlayerData.instance.respawnMarkerName;
        }
        public static void SetToStart()
        {
            (string respawnScene, string respawnMarkerName, int respawnType, int mapZone) = GetStartDef();
            Benchwarp.LS.atDeployedBench = false;
            PlayerData.instance.respawnScene = respawnScene;
            PlayerData.instance.respawnMarkerName = respawnMarkerName;
            PlayerData.instance.respawnType = respawnType;
            PlayerData.instance.mapZone = (MapZone)mapZone;
        }

        /*
         // Example code for accessing events without referencing Benchwarp.dll
        public static void SafeAdd(Func<string, string> f)
        {
            try
            {
                FieldInfo field = Type.GetType("Benchwarp.Events, Benchwarp")
                    .GetField("OnGetSceneName", BindingFlags.Public | BindingFlags.Static);

                field.FieldType
                    .GetEvent("Event", BindingFlags.Public | BindingFlags.Instance)
                    .AddEventHandler(field.GetValue(null), f);
            }
            catch
            {
                return;
            }
        }
        */
    }

    public class SequentialEventHandler<T>
    {
        private readonly List<Func<T, T>> modifiers = new();

        public event Func<T, T> Event
        {
            add => modifiers.Add(value);
            remove => modifiers.Remove(value);
        }

        public T Invoke(T defaultValue)
        {
            foreach (Func<T, T> f in modifiers)
            {
                defaultValue = f(defaultValue);
            }
            return defaultValue;
        }
    }
}
