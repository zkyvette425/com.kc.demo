using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using YooAsset;

namespace KC
{
    public static class RootHelper
    {
        public static async UniTask Create(RootType rootType)
        {
            var root = World.CreateRoot((int)rootType);
            switch (rootType)
            {
                case RootType.Init:
                    await Init(root);
                    break;
                case RootType.Demo:
                    await Demo(root);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(rootType), rootType, null);
            }
        }

        private static async UniTask Init(Root root)
        {
            Debug.Log("创建 Init Root");
            await Create(RootType.Demo);
            root.AddComponent<InitComponent>();
            root.Dispose();
            Debug.Log("销毁 Init Root");
        }
        
        private static async UniTask Demo(Root root)
        {
            await YooAssets.LoadSceneAsync("Assets/Samples/KC.Demo/0.1.5/demo1/Bundles/Scene/Demo").ToUniTask(); 
            root.AddComponent<DemoComponent>();
        }
    }
}