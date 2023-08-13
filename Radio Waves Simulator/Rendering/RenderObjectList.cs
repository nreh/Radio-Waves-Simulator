using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radio_Waves_Simulator.Rendering {
    /// <summary>
    /// Represents a list of RenderObjects
    /// </summary>
    internal class RenderObjectList : List<RenderObject> {

        /// <summary>
        /// Returns first object found with given name, or else returns null
        /// </summary>
        /// <returns></returns>
        public RenderObject? getObjectByName(string name) {
            foreach (RenderObject obj in this) {
                if (obj.name == name) {
                    return obj;
                }
            }

            return null; // object wasn't found
        }

        public void removeRenderObjectByName(string name) {
            RenderObject? obj = getObjectByName(name);

            if (obj == null) {
                throw new KeyNotFoundException("RenderObject with name " + name + " was not found");
            }

            this.Remove(obj);
        }

    }
}
