using UnityEngine;
namespace Grabli
{
    public class ComponentEnabler : Enabler
    {
        private MonoBehaviour component;

        public bool IsEnabled => component.enabled;

        public ComponentEnabler(MonoBehaviour component)
        {
            this.component = component;
        }

        public void Disable()
        {
            component.enabled = false;
        }

        public void Enable()
        {
            component.enabled = true;
        }
    }
}
