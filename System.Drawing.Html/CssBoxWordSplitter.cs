using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace System.Drawing.Html
{
    /// <summary>
    /// Splits text on words for a box
    /// </summary>
    internal class CssBoxWordSplitter
    {
        #region Static

        /// <summary>
        /// Returns a bool indicating if the specified box white-space processing model specifies
        /// that sequences of white spaces should be collapsed on a single whitespace
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool CollapsesWhiteSpaces(CssBox b)
        {
            return b.WhiteSpace == CssConstants.Normal ||
                b.WhiteSpace == CssConstants.Nowrap ||
                b.WhiteSpace == CssConstants.PreLine;
        }

        /// <summary>
        /// Returns a bool indicating if line breaks at the source should be eliminated
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool EliminatesLineBreaks(CssBox b)
        {
            return b.WhiteSpace == CssConstants.Normal || b.WhiteSpace == CssConstants.Nowrap;
        }

        #endregion

        #region Fields
        private CssBox _box;
        private string _text;
        private List<CssBoxWord> _words;
        private CssBoxWord _curword;

        #endregion

        #region Ctor

        private CssBoxWordSplitter()
        {
            _words = new List<CssBoxWord>();
            _curword = null;
        }

        public CssBoxWordSplitter(CssBox box, string text)
            : this()
        {
            _box = box;
            _text = text.Replace("\r", string.Empty); ;
        }

        #endregion

        #region Props


        public List<CssBoxWord> Words
        {
            get { return _words; }
        }


        public string Text
        {
            get { return _text; }
        }


        public CssBox Box
        {
            get { return _box; }
        }


        #endregion

        #region Public Metods

        /// <summary>
        /// Splits the text on words using rules of the specified box
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
		public void SplitWords()
		{
			List<string> result = new List<string>();
			if (string.IsNullOrEmpty(Text)) return;

			TextElementEnumerator CurrentInputTextElement = StringInfo.GetTextElementEnumerator(Text);
			CurrentInputTextElement.Reset();

			_curword = new CssBoxWord(Box);

			bool onspace = IsSpace(Text[0]);
			List<char> characters = new List<char>();

			while (CurrentInputTextElement.MoveNext())
				characters.Add(CurrentInputTextElement.GetTextElement()[0]);

			for(int i = 0; i < characters.Count; i++)
			{
				char c = characters[i];
				char next = Char.MinValue;
				if (i < characters.Count - 1)
					next = characters[i + 1];
				if (IsSpace(c))
				{
					if (!onspace) CutWord();

					if (IsLineBreak(c))
					{
						_curword.AppendChar('\n');
						CutWord();
					}
					else if (IsTab(c))
					{
						_curword.AppendChar('\t');
						CutWord();
					}
					else
					{
						_curword.AppendChar(' ');
					}

					onspace = true;
				}
				else if (CssDefaults.SystemTextDirectionRTL && IsPunctuation(c))
				{
					_curword.PrependChar(c);
					onspace = true; // allow the text to be broken after a series of spaces or punctuation
				}
				else if (IsAsianWord(c, next))
				{
					_curword.AppendChar(c);
					CutWord();
				}
				else
				{
					if (onspace) CutWord();
					_curword.AppendChar(c);

					onspace = false;
				}
			}

			CutWord();
		}

		private bool IsPunctuation(char c)
		{
			return ".?!,:;".Contains(c.ToString());
		}

		private bool IsAsianWord(char c, char next)
		{
			bool result = false;

			// http://en.wikipedia.org/wiki/Line_breaking_rules_in_East_Asian_language

			// Japanese characters that can't start a line (so the current word must extend to them)
			if (")]｝〕〉》」』】〙〗〟’”｠»ヽヾーァィゥェォッャュョヮヵヶぁぃぅぇぉっゃゅょゎゕゖㇰㇱㇲㇳㇴㇵㇶㇷㇸㇹㇺㇻㇼㇽㇾㇿ々〻‐゠–〜 ?!‼⁇⁈⁉・、:;,。.".Contains(next.ToString()))
				return false;

			// Japanese characters that can't end a line
			if ("([｛〔〈《「『【〘〖〝‘“｟«—…‥〳〴〵".Contains(c.ToString()))
				return false;

			// Simplified Chinese characters that can't start a line
			if ("!%),.:;>?]}¢¨°·ˇˉ―‖’”„‟†‡›℃∶、。〃〆〈《「『〕〗〞︵︹︽︿﹃﹘﹚﹜！＂％＇），．：；？］｀｜｝～".Contains(next.ToString()))
				return false;

			// Simplified Chinese characters that can't end a line
			if ("$(*,£¥·‘“〈《「『【〔〖〝﹗﹙﹛＄（．［｛￡￥".Contains(c.ToString()))
				return false;

			// Traditional Chinese characters that can't start a line
			if ("!),.:;?]}¢·–— ’”•‥„‧ †╴ 、。〆〈《「『〕〞︰︱︲︳︵︷︹︻︽︿﹁﹃﹏﹐﹑﹒﹓﹔﹕﹖﹘﹚﹜！），．：；？］｜｝､".Contains(next.ToString()))
				return false;

			// Traditional Chinese characters that can't end a line
			if ("([{£¥‘“‵々〇〉》」〔〝︴︶︸︺︼︾﹀﹂﹗﹙﹛（｛".Contains(c.ToString()))
				return false;

			// Korean characters that can't start a line
			if ("!%),.:;?]}¢°’”†‡℃〆〈《「『〕！％），．：；？］｝".Contains(next.ToString()))
				return false;

			// Korean characters that can't end a line
			if (@"$([\{£¥‘“々〇〉》」〔＄（［｛｠￥￦ #".Contains(c.ToString()))
				return false;

			int i = Convert.ToInt32(c);
			if (i > 0x4e00 && i < 0x9fff) // CJK Unified Ideographs
				result = true;
			if (i > 0x3400 && i < 0x4dff) // CJK Unified Ideographs Extension A
				result = true;
			if (i > 0x20000 && i < 0x2a6df) // CJK Unified Ideographs Extension B 
				result = true;
			if (i > 0xf900 && i < 0xfaff) // CJK Compatibility Ideographs
				result = true;
			if (i > 0x2f800 && i < 0x2fa1f) // CJK Compatibility Ideographs Supplement
				result = true;
			if (i > 0x3130 && i < 0x318f) // Hangul symbols
				result = true;
			if (i > 0x3200 && i < 0x32ff) // Hangul specials
				result = true;
			if (i > 0x3260 && i < 0x327b) // Hangul specials
				result = true;
			if (i > 0x327f && i < 0x327f) // Korean symbol
				result = true;
			if (i > 0x4e00 && i < 0x9fa5) // CJK symbols
				result = true;
			if (i > 0xac00 && i < 0xd7a3) // Hangul symbols
				result = true;
			if (i > 0xf900 && i < 0xfa2d) // CJK symbols
				result = true;
			if (i > 0x3040 && i < 0x309f) // Hiragana
				result = true;
			if (i > 0x30a0 && i < 0x30ff) // Katakana
				result = true;
			if (i > 0x1100 && i < 0x11ff) // Hangul
				result = true;
			if (i > 0xa960 && i < 0xa97f) // Hangul
				result = true;
			if (i > 0xd7b0 && i < 0xd7ff) // Hangul
				result = true;
			if (i > 0xff00 && i < 0xffef) // Hangul
				result = true;
			return result;
		}

        private void CutWord()
        {
            if(_curword.Text.Length > 0)
                Words.Add(_curword);
            _curword = new CssBoxWord(Box);
        }

        private bool IsSpace(char c)
        {
            return c == ' ' || c == '\t' || c == '\n';
        }

        private bool IsLineBreak(char c)
        {
            return c == '\n' || c == '\a';
        }

        private bool IsTab(char c)
        {
            return c == '\t';
        }

        #endregion
    }

}
