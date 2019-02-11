
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFinderTask
{
    public class WordFinder : IWordFinder
    {
        private readonly int _matrixLenth;
        private readonly IEnumerable<string> _matrix;
        private DictionaryWord _hashtableWord = new DictionaryWord();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="matrix"></param>
        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
            _matrixLenth = this.GetMatrixLength();
        }

        /// <summary>
        /// Returns an IEnumerable<string> with the words found 
        /// </summary>
        /// <param name="wordstream"></param>
        /// <returns></returns>
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            Regex regex = default(Regex);

            foreach (string word in wordstream)
            {
                regex = new Regex(word);

                //First we look for Horizontally
                if (ExistWordHorizontally(regex))
                {
                    yield return word;
                    regex = null;
                    continue;
                }

                //if not exist word Horizontally, look for vertically
                if (ExistWordVertically(regex))
                {
                    yield return word;
                    regex = null;                    
                }
            }
        }

        /// <summary>
        /// ExistWordVertically
        /// </summary>
        /// <param name="regex"></param>
        /// <returns></returns>
        private bool ExistWordVertically(Regex regex)
        {
            for (int i = 0; i < this._matrixLenth; i++)
            {
                var wordToCompare = this.GetWordByPosition(i);

                if (!regex.Match(wordToCompare).Success)
                    continue;

                return true;
            }

            return false;
        }

        /// <summary>
        /// ExistWordHorizontally
        /// </summary>
        /// <param name="regex"></param>
        /// <returns></returns>
        private bool ExistWordHorizontally(Regex regex)
        {
            foreach (string wordmatrix in _matrix)
            {
                if (!regex.Match(wordmatrix).Success)
                    continue;

                return true;
            }
            return false;
        }

        /// <summary>
        /// return matrix's length, getting the first element
        /// </summary>
        /// <returns></returns>
        private int GetMatrixLength()
        {
            return _matrix.FirstOrDefault().Length;
        }

        /// <summary>
        /// return the word by column
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private string GetWordByPosition(int index)
        {
            var wordFound = string.Empty;

            //First verify if it exists in the dictionary 
            if (this._hashtableWord.GetWordByKey(index, out wordFound))
            {
                return wordFound;
            }

            //as not exist the word, will get it
            foreach (string word in _matrix)
            {
                wordFound += word.Substring(index, 1);
            }

            //add the word at the diccionary 
            this._hashtableWord.AddElement(index, wordFound);

            return wordFound;
        }
    }
}
