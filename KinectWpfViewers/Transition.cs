using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class Transition
    {
        private double probability;
        private String action;
        private State newState;

        public Transition()
        {
        }

        public Transition(double probability, String action, State _state)
        {
            this.probability = probability;
            this.action = action;
            this.newState = _state;
        }

        public String getAction()
        {
            return action;
        }

        public double getProbability()
        {
            return probability;
        }

        public void setAction(String action)
        {
            this.action = action;
        }

        public void setProbability(double probability)
        {
            this.probability = probability;
        }

        public State getNewState()
        {
            return newState;
        }

        public void setNewState(State newState)
        {
            this.newState = newState;
        }
    }
}
