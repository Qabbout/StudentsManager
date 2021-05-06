using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager
{
    class Studentt
    {
        public string id1;
        public string name1;
        public string age1;
        public string major1;
        public string signedCourse1;

        public override string ToString()
        {
            return "ID:" + id1 + ", Name:" + name1 + ", Age:" + age1 + ", Major: " + major1;
        }
    }
}
