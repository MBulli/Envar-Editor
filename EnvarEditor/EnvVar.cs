using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvarEditor
{
    class EnvVar
    {
        private bool userSpecific;
        private string name;
        private string varValue;

        public bool UserSpecific
        {
            get { return userSpecific; }
            set
            {
                if (userSpecific != value)
                {
                    userSpecific = value;
                    IsChanged = true;
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    IsChanged = true;
                }
            }
        }

        public string Value
        {
            get { return varValue; }
            set
            {
                if (varValue != value)
                {
                    varValue = value;
                    IsChanged = true;
                }
            }
        }

        [System.ComponentModel.Browsable(false)]
        public bool IsChanged
        {
            get;
            private set;
        }

        private EnvironmentVariableTarget VariableTarget
        {
            get { return this.UserSpecific ? EnvironmentVariableTarget.User : EnvironmentVariableTarget.Machine; }
        }

        public EnvVar()
        {

        }

        private EnvVar(bool user, string name, string value)
        {
            this.userSpecific = user;
            this.name = name;
            this.varValue = value;
        }

        public static List<EnvVar> GetEnvironmentVariables()
        {
            List<EnvVar> result = new List<EnvVar>();

            result.AddRange(GetEnvironmentVariables(EnvironmentVariableTarget.User));
            result.AddRange(GetEnvironmentVariables(EnvironmentVariableTarget.Machine));
 
            result.Sort((x, y) =>
            {
                return string.Compare(x.Name, y.Name);
            });

            return result;
        }

        private static IEnumerable<EnvVar> GetEnvironmentVariables(EnvironmentVariableTarget target)
        {
            IDictionary vars = Environment.GetEnvironmentVariables(target);

            foreach (string name in vars.Keys)
            {
                if (string.IsNullOrEmpty(name))
                    continue;

                string value = vars[name] as string;

                if (value != null)
                    yield return new EnvVar(target == EnvironmentVariableTarget.User ? true : false , name, value); 
            }
        }

        public string[] ValuesSeperated()
        {
            return string.IsNullOrEmpty(Value) ? new string[] { } : this.Value.Split(';');
        }

        public void SaveToRegistry()
        {
            if (!IsChanged)
                return;

            Environment.SetEnvironmentVariable(this.Name, this.Value, this.VariableTarget);
        }

        public void DeleteFromRegistry()
        {
            Environment.SetEnvironmentVariable(this.Name, null, this.VariableTarget);
        }
    }
}
