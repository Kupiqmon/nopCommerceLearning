using System.Collections;
using System.Collections.Generic;

namespace ProgrammingLanguage
{
    public partial class DictionaryLearning
    {
        IDictionary<string, int> myIDictionary = new Dictionary<string, int>();

        Dictionary<string, int> myDictionary = new Dictionary<string, int>();
        public void TestDictionaryLearning()
        {
            myIDictionary.Add("key1", 1);
            myIDictionary.Add("key2", 2);
            if (myIDictionary.ContainsKey("key1"))
            {
                int iDVal = (int)myIDictionary["key1"]; // Retrieves the value associated with "key1"
            }

            myDictionary.Add("key1", 1);
            myDictionary.Add("key2", 2);
            int dVal = myDictionary["key1"]; // Retrieves the value associated with "key1"
        }
    }
}
