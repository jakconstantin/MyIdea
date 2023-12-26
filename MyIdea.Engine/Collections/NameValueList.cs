using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyIdea.Engine.Collections
{
    public class NameValueList : Dictionary<string, string>
    {

        
        public NameValueList(bool caseSensitive = false) : base(caseSensitive ? null : StringComparer.OrdinalIgnoreCase) { }

        public NameValueList(NameValueList other, bool caseSensitive = false) : base(other, caseSensitive ? null : StringComparer.OrdinalIgnoreCase) { }

        public NameValueList(IEqualityComparer<string> comparer) : base(comparer) { }

        protected NameValueList(NameValueList other, IEqualityComparer<string> comparer) : base(other, comparer)
        {
        }


        public static NameValueList From(System.Collections.Specialized.NameValueCollection values)
        {
            NameValueList rt = new NameValueList();
            foreach (string key in values.AllKeys)
            {
                rt[key] = values[key];
            }
            return rt;
        }



        public void SetIfNotExists(string name, string value)
        {
            if (!this.ContainsKey(name))
            {
                this[name] = value;
            }
        }

        public string GetIfExists(string name)
        {
            if (!this.ContainsKey(name))
            {
                return null;
            }
            return this[name];
        }

        public override string ToString()
        {
            return Utils.Join(",", this);
        }


        public bool ContainsKeys(params string[] keys)
        {
            foreach (string key in keys)
            {
                if (!this.ContainsKey(key))
                {
                    return false;
                }
            }
            return true;
        }

        
        //public IEnumerable<TOutput> ConvertAll<TOutput>(Converter<KeyValuePair<string, string>, TOutput> converter)
        //{
        //    return Utils.ConvertAll(this, converter);
        //}


        public void AddRange(IEnumerable<KeyValuePair<string, string>> values)
        {
            foreach (KeyValuePair<string, string> value in values)
            {
                this.Add(value.Key, value.Value);
            }
        }

    }
}
