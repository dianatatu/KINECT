using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class MotionUtils
    {
        Dictionary<String, State> bodyStates;
        Dictionary<String, State> handStates;
        Dictionary<String, State> legStates;

        public MotionUtils()
        {
            List<State> states = new List<State>();
            bodyStates = initBodyStates();
            handStates = initHandStates();
            legStates = initLegStates();
        }

        public State getNextBodyState(String stateName, String action)
        {
            //get state by name
            State currentState = new State("");
            if (bodyStates.TryGetValue(stateName, out currentState))
            {
                Transition transition;
                if (currentState.getTransitions().TryGetValue(action, out transition))
                {
                    return transition.getNewState();
                }
            }
            Console.Out.WriteLine("!!!!!!!!!!");
            return currentState;
        }

        public State getNextHandState(String stateName, String action)
        {
            //get state by name
            State currentState = new State("");
            if (handStates.TryGetValue(stateName, out currentState))
            {
                Transition transition;
                if (currentState.getTransitions().TryGetValue(action, out transition))
                {
                    return transition.getNewState();
                }
            }
            Console.Out.WriteLine("?????????");
            return currentState;
        }

        public State getNextLegState(String stateName, String action)
        {
            //get state by name
            State currentState = new State("");
            if (legStates.TryGetValue(stateName, out currentState))
            {
                Transition transition;
                if (currentState.getTransitions().TryGetValue(action, out transition))
                {
                    return transition.getNewState();
                }
            }
            Console.Out.WriteLine("::::::::::::::::");
            return currentState;
        }

        public Dictionary<String, State> initBodyStates()
        {
            Dictionary<String, State> bodyList = new Dictionary<String, State>();

            State state1 = new State(Constants.stateType.INTERMEDIATE, "");
            state1.setName("D");
            State state2 = new State(Constants.stateType.FINAL, "Aplecare laterala");
            state2.setName("Al.D");
            State state3 = new State(Constants.stateType.FINAL, "Ridicare din lateral");
            state3.setName("D.Al");
            State state4 = new State(Constants.stateType.FINAL, "Ridicare din asezat");
            state4.setName("D.AfAs");
            State state5 = new State(Constants.stateType.FINAL, "Aplecare frontala");
            state5.setName("Af.D");
            State state6 = new State(Constants.stateType.FINAL, "Asezare");
            state6.setName("As.Af");
            State state7 = new State(Constants.stateType.INTERMEDIATE, "");
            state7.setName("Af.As");
            State state8 = new State(Constants.stateType.FINAL, "Aplecare laterala din asezat");
            state8.setName("Al.As");
            State state9 = new State(Constants.stateType.FINAL, "Miscare circulara - aplecare frontala din asezat");
            state9.setName("Af.AlAs");
            State state10 = new State(Constants.stateType.FINAL, "Miscare circulara - aplecare laterala din asezat");
            state10.setName("Al.AfAs");
            State state11 = new State(Constants.stateType.FINAL, "Ridicare din lateral asezat");
            state11.setName("As.AlAs");
            State state12 = new State(Constants.stateType.FINAL, "Ridicare din frontal");
            state12.setName("D.Af");
            State state13 = new State(Constants.stateType.FINAL, "Miscare circulara - aplecare laterala din aplecare frontala");
            state13.setName("Al.Af");
            State state14 = new State(Constants.stateType.FINAL, "Miscare circulara - aplecare frontala din aplecare laterala");
            state14.setName("Af.Al");
            State state15 = new State(Constants.stateType.FINAL, "Ridicare din aplecat frontal asezat");
            state15.setName("As.AfAs");
            State state16 = new State(Constants.stateType.FINAL, "Cadere");
            state16.setName("C");

            state1.getTransitions().Add("drept", new Transition(0.2, "drept", state1));
            state1.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state5));
            state1.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state2));
            state1.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state1.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state2.getTransitions().Add("drept", new Transition(0.2, "drept", state3));
            state2.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state14));
            state2.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state2));
            state2.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state2.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state3.getTransitions().Add("drept", new Transition(0.2, "drept", state3));
            state3.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state5));
            state3.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state2));
            state3.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state3.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state4.getTransitions().Add("drept", new Transition(0.2, "drept", state4));
            state4.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state5));
            state4.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state2));
            state4.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state4.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state5.getTransitions().Add("drept", new Transition(0.2, "drept", state12));
            state5.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state5));
            state5.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state13));
            state5.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state5.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state6.getTransitions().Add("drept", new Transition(0.2, "drept", state6));
            state6.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state7));
            state6.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state8));
            state6.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state6.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state7.getTransitions().Add("drept", new Transition(0.2, "drept", state4));
            state7.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state7));
            state7.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state10));
            state7.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state7.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state8.getTransitions().Add("drept", new Transition(0.2, "drept", state6));
            state8.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state9));
            state8.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state8));
            state8.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state8.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state9.getTransitions().Add("drept", new Transition(0.2, "drept", state15));
            state9.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state9));
            state9.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state10));
            state9.getTransitions().Add("asezat", new Transition(0.2, "asezat", state15));
            state9.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state10.getTransitions().Add("drept", new Transition(0.2, "drept", state11));
            state10.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state9));
            state10.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state10));
            state10.getTransitions().Add("asezat", new Transition(0.2, "asezat", state11));
            state10.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state11.getTransitions().Add("drept", new Transition(0.2, "drept", state6));
            state11.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state7));
            state11.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state8));
            state11.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state11.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state12.getTransitions().Add("drept", new Transition(0.2, "drept", state12));
            state12.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state5));
            state12.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state2));
            state12.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state12.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state13.getTransitions().Add("drept", new Transition(0.2, "drept", state3));
            state13.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state14));
            state13.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state13));
            state13.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state13.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state14.getTransitions().Add("drept", new Transition(0.2, "drept", state12));
            state14.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state14));
            state14.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state13));
            state14.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state14.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            state15.getTransitions().Add("drept", new Transition(0.2, "drept", state6));
            state15.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state7));
            state15.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state8));
            state15.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state15.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            // TODO: modifica starea urmatoare
            state16.getTransitions().Add("drept", new Transition(0.2, "drept", state1));
            state16.getTransitions().Add("aplecat frontal", new Transition(0.2, "aplecat frontal", state5));
            state16.getTransitions().Add("aplecat lateral", new Transition(0.2, "aplecat lateral", state2));
            state16.getTransitions().Add("asezat", new Transition(0.2, "asezat", state6));
            state16.getTransitions().Add("culcat", new Transition(0.2, "culcat", state16));

            bodyList.Add(state1.getName(), state1);
            bodyList.Add(state2.getName(), state2);
            bodyList.Add(state3.getName(), state3);
            bodyList.Add(state4.getName(), state4);
            bodyList.Add(state5.getName(), state5);
            bodyList.Add(state6.getName(), state6);
            bodyList.Add(state7.getName(), state7);
            bodyList.Add(state8.getName(), state8);
            bodyList.Add(state9.getName(), state9);
            bodyList.Add(state10.getName(), state10);
            bodyList.Add(state11.getName(), state11);
            bodyList.Add(state12.getName(), state12);
            bodyList.Add(state13.getName(), state13);
            bodyList.Add(state14.getName(), state14);
            bodyList.Add(state15.getName(), state15);
            bodyList.Add(state16.getName(), state16);
            
            return bodyList;
        }

        public Dictionary<String, State> initHandStates()
        {
            Dictionary<String, State> handList = new Dictionary<String, State>();

            State state1 = new State(Constants.stateType.INTERMEDIATE, "");
            state1.setName("Lc");
            State state2 = new State(Constants.stateType.FINAL, "Ridicare frontala");
            state2.setName("Rf.Lc");
            State state3 = new State(Constants.stateType.FINAL, "Coborare din frontal");
            state3.setName("Lc.Rf");
            State state4 = new State(Constants.stateType.FINAL, "Ridicare laterala");
            state4.setName("Rl.Lc");
            State state5 = new State(Constants.stateType.FINAL, "Coborare din lateral");
            state5.setName("Lc.Rl");
            State state6 = new State(Constants.stateType.FINAL, "Ridicare sus");
            state6.setName("Rs");
            State state7 = new State(Constants.stateType.FINAL, "Coborare de sus in frontal");
            state7.setName("Rf.Rs");
            State state8 = new State(Constants.stateType.FINAL, "Coborare de sus in lateral");
            state8.setName("Rl.Rs");
            State state9 = new State(Constants.stateType.FINAL, "Lovitura pumn");
            state9.setName("Rf.Rl");
            State state10 = new State(Constants.stateType.FINAL, "Miscare circulara din frontal in lateral");
            state10.setName("Rl.Rf");

            state1.getTransitions().Add("langa corp", new Transition(0.2, "langa corp", state1));
            state1.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state2));
            state1.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state4));
            state1.getTransitions().Add("ridicat sus", new Transition(0.2, "ridicat sus", state6));

            state2.getTransitions().Add("langa corp", new Transition(0.2, "langa corp", state3));
            state2.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state2));
            state2.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state10));
            state2.getTransitions().Add("ridicat sus", new Transition(0.2, "ridicat sus", state6));

            state3.getTransitions().Add("langa corp", new Transition(0.2, "langa corp", state3));
            state3.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state2));
            state3.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state4));
            state3.getTransitions().Add("ridicat sus", new Transition(0.2, "ridicat sus", state6));

            state4.getTransitions().Add("langa corp", new Transition(0.2, "langa corp", state5));
            state4.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state9));
            state4.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state4));
            state4.getTransitions().Add("ridicat sus", new Transition(0.2, "ridicat sus", state6));

            state5.getTransitions().Add("langa corp", new Transition(0.2, "langa corp", state5));
            state5.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state2));
            state5.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state4));
            state5.getTransitions().Add("ridicat sus", new Transition(0.2, "ridicat sus", state6));

            state6.getTransitions().Add("langa corp", new Transition(0.2, "langa corp", state1));
            state6.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state7));
            state6.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state8));
            state6.getTransitions().Add("ridicat sus", new Transition(0.2, "ridicat sus", state6));

            state7.getTransitions().Add("langa corp", new Transition(0.2, "langa corp", state3));
            state7.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state7));
            state7.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state10));
            state7.getTransitions().Add("ridicat sus", new Transition(0.2, "ridicat sus", state6));

            state8.getTransitions().Add("langa corp", new Transition(0.2, "langa corp", state5));
            state8.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state9));
            state8.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state8));
            state8.getTransitions().Add("ridicat sus", new Transition(0.2, "ridicat sus", state6));

            state9.getTransitions().Add("langa corp", new Transition(0.2, "langa corp", state3));
            state9.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state9));
            state9.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state10));
            state9.getTransitions().Add("ridicat sus", new Transition(0.2, "ridicat sus", state6));

            state10.getTransitions().Add("langa corp", new Transition(0.2, "langa corp", state5));
            state10.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state9));
            state10.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state10));
            state10.getTransitions().Add("ridicat sus", new Transition(0.2, "ridicat sus", state6));


            handList.Add(state1.getName(), state1);
            handList.Add(state2.getName(), state2);
            handList.Add(state3.getName(), state3);
            handList.Add(state4.getName(), state4);
            handList.Add(state5.getName(), state5);
            handList.Add(state6.getName(), state6);
            handList.Add(state7.getName(), state7);
            handList.Add(state8.getName(), state8);
            handList.Add(state9.getName(), state9);
            handList.Add(state10.getName(), state10);

            return handList;
        }

        public Dictionary<String, State> initLegStates()
        {
            
            Dictionary<String, State> legList = new Dictionary<String, State>();
            
            State state1 = new State(Constants.stateType.INTERMEDIATE, "");
            state1.setName("D");
            State state2 = new State(Constants.stateType.INTERMEDIATE, "");
            state2.setName("I.D");
            State state3 = new State(Constants.stateType.FINAL, "Pas");
            state3.setName("D.I");
            State state4 = new State(Constants.stateType.FINAL, "Ridicare frontala");
            state4.setName("Rf.D");
            State state5 = new State(Constants.stateType.FINAL, "Ridicare laterala");
            state5.setName("Rl.D");
            State state6 = new State(Constants.stateType.FINAL, "Miscare circulara spre frontal");
            state6.setName("Rf.Rl");
            State state7 = new State(Constants.stateType.FINAL, "Coborare din frontal");
            state7.setName("D.Rf");
            State state8 = new State(Constants.stateType.INTERMEDIATE, "");
            state8.setName("I");
            State state9 = new State(Constants.stateType.FINAL, "Coborare din lateral");
            state9.setName("D.Rl");
            State state10 = new State(Constants.stateType.FINAL, "Miscare circulara spre lateral");
            state10.setName("Rl.Rf");

            state1.getTransitions().Add("drept", new Transition(0.2, "drept", state1));
            state1.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state4));
            state1.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state5));
            state1.getTransitions().Add("indoit", new Transition(0.2, "indoit", state2));

            state2.getTransitions().Add("drept", new Transition(0.2, "drept", state3));
            state2.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state4));
            state2.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state5));
            state2.getTransitions().Add("indoit", new Transition(0.2, "indoit", state2));
            
            state3.getTransitions().Add("drept", new Transition(0.2, "drept", state3));
            state3.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state4));
            state3.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state5));
            state3.getTransitions().Add("indoit", new Transition(0.2, "indoit", state2));
            
            state4.getTransitions().Add("drept", new Transition(0.2, "drept", state7)); // 3
            state4.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state4));
            state4.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state10));
            state4.getTransitions().Add("indoit", new Transition(0.2, "indoit", state8)); // 2

            state5.getTransitions().Add("drept", new Transition(0.2, "drept", state9));
            state5.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state6));
            state5.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state5));
            state5.getTransitions().Add("indoit", new Transition(0.2, "indoit", state8)); // sau 10

            state6.getTransitions().Add("drept", new Transition(0.2, "drept", state7));
            state6.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state6));
            state6.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state10));
            state6.getTransitions().Add("indoit", new Transition(0.2, "indoit", state8)); // sau 10 !

            state7.getTransitions().Add("drept", new Transition(0.2, "drept", state7));
            state7.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state4));
            state7.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state5));
            state7.getTransitions().Add("indoit", new Transition(0.2, "indoit", state2)); // sau 10 !

            state8.getTransitions().Add("drept", new Transition(0.2, "drept", state1)); // !!
            state8.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state4)); // !!
            state8.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state5)); // !!
            state8.getTransitions().Add("indoit", new Transition(0.2, "indoit", state8));

            state9.getTransitions().Add("drept", new Transition(0.2, "drept", state9));
            state9.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state4));
            state9.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state5));
            state9.getTransitions().Add("indoit", new Transition(0.2, "indoit", state2));

            state10.getTransitions().Add("drept", new Transition(0.2, "drept", state9)); //7
            state10.getTransitions().Add("ridicat frontal", new Transition(0.2, "ridicat frontal", state6));
            state10.getTransitions().Add("ridicat lateral", new Transition(0.2, "ridicat lateral", state10));
            state10.getTransitions().Add("indoit", new Transition(0.2, "indoit", state8)); // sau 2


            legList.Add(state1.getName(), state1);
            legList.Add(state2.getName(), state2);
            legList.Add(state3.getName(), state3);
            legList.Add(state4.getName(), state4);
            legList.Add(state5.getName(), state5);
            legList.Add(state6.getName(), state6);
            legList.Add(state7.getName(), state7);
            legList.Add(state8.getName(), state8);
            legList.Add(state9.getName(), state9);
            legList.Add(state10.getName(), state10);

            return legList;
             
        }
    }

}
