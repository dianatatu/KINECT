using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class State
    {
        private String name;
        Dictionary<String, Transition> transitions;
        Constants.stateType type;
        String motion;

        public State(String _motion)
        {
            transitions = new Dictionary<String, Transition>();
            this.motion = _motion;
        }

        public State(Constants.stateType _type, String _motion)
        {
            this.type = _type;
            transitions = new Dictionary<String, Transition>();
            this.motion = _motion;
        }

        public State(String name, Dictionary<String, Transition> transitions, String _motion)
        {
            this.name = name;
            transitions = new Dictionary<String, Transition>();
            this.transitions = transitions;
            this.motion = _motion;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public Dictionary<String, Transition> getTransitions()
        {
            return transitions;
        }

        public void setTransitions(Dictionary<String, Transition> transitions)
        {
            this.transitions = transitions;
        }

        public Constants.stateType getType()
        {
            return type;
        }

        public void setType(Constants.stateType type)
        {
            this.type = type;
        }

        public String getMotion()
        {
            return motion;
        }

        public void setMotion(String motion)
        {
            this.motion = motion;
        }
    }
}
