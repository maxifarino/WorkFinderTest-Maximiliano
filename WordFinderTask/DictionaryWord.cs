using System.Collections.Generic;

namespace WordFinderTask
{
    public class DictionaryWord
    {
        private Dictionary<int, string> _dictionary = new Dictionary<int,string>();

        /// <summary>
        /// Contructor
        /// </summary>
        public DictionaryWord() { }

        /// <summary>
        /// This method add a new element
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddElement(int key, string value)
        {
            _dictionary.Add(key,value);
        }

        /// <summary>
        /// This method get element by key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="wordFound"></param>
        /// <returns></returns>
        public bool GetWordByKey(int key,out string wordFound)
        {
            return _dictionary.TryGetValue(key, out wordFound);
        }
    }
}
