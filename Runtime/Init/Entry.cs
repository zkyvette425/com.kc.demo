using UnityEngine;

namespace KC
{
    public class Entry : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            SingleManager.Instance.AddSingleton<TimeInfo>();
            SingleManager.Instance.AddSingleton<IdGenerator>();
        }

        private void Update()
        {
            TimeInfo.Instance.Update();
            World.Update();
        }
        
        private void LateUpdate()
        {
            World.LateUpdate();
        }
        
        private void OnApplicationQuit()
        {
            SingleManager.Instance.Dispose();
        }
    }
}