using Cysharp.Threading.Tasks;
using UnityEngine;

namespace KC
{
    public class InitComponent : Component,IAwake
    {
        public void Awake()
        {
            Debug.Log("Init Awake");
        }
    }
}