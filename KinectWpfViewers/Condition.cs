using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.WpfViewers
{
    class Condition
    {
        private String member1;
        private double member2;
        private Constants.conditionType op;

        public String getMember1() {
            return member1;
        }

        public double getMember2() {
            return member2;
        }

        public Constants.conditionType getOperator() {
            return op;
        }

        public void setMember1(String member1) {
            this.member1 = member1;
        }

        public void setMember2(double member2) {
            this.member2 = member2;
        }

        public void setOperator(Constants.conditionType op) {
            this.op = op;
        }
    }
}
