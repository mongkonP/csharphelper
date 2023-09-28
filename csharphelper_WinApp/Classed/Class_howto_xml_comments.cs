
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

  namespace  howto_xml_comments

 { 

/// <summary>
    /// Represents a test score for a student on a particular test.
    /// </summary>
    class TestScore
    {
        /// <summary>
        /// This test's identifying number.
        /// </summary>
        private int _TestNumber;
        public int TestNumber
        {
            get { return _TestNumber; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException(
                        "TestNumber", "Test numbers must be greater than 0.");
                _TestNumber = value;
            }
        }

        /// <summary>
        /// This score the student got on this test.
        /// </summary>
        private int _Score;
        public int Score
        {
            get { return _Score; }
            set
            {
                if ((value < 0) || (value > 100))
                    throw new ArgumentOutOfRangeException(
                        "Score", "Test scores must be between 0 and 100.");
                _Score = value;
            }
        }

        /// <summary>
        /// Constructor that initializes a specific test score.
        /// </summary>
        /// <param name="test_number">The test number.</param>
        /// <param name="score">The student's score between 0 and 100.</param>
        public TestScore(int test_number, int score)
        {
            TestNumber = test_number;
            Score = score;
        }

        /// <summary>
        /// Return the letter grade for this test.
        /// </summary>
        /// <param name="grade_breaks">Break points for letter grades A, B, C, D, and F.
        /// For example, if score >= grade_breaks[0] then the score is A.</param>
        /// <param name="grade_names">The name of the grade for the corresponding break point.</param>
        /// <returns>The letter grade for this test.</returns>
        public string Grade(int[] grade_breaks, string[] grade_names)
        {
            // If we have no grade_breaks, use standard percentages.
            if (grade_breaks == null)
                grade_breaks = new int[]
                    {
                        98, 93, 90,
                        88, 83, 80,
                        78, 73, 70,
                        68, 63, 60
                    };

            // If we have no grade_names, use A+, A-, etc.
            if (grade_names == null)
                grade_names = new string[]
                    {
                        "A+", "A", "A-",
                        "B+", "B", "B-",
                        "C+", "C", "C-",
                        "D+", "D", "D-",
                        "F"
                    };

            for (int i = 0; i < grade_breaks.Length; i++)
            {
                if (Score >= grade_breaks[i]) return grade_names[i];
            }
            return grade_names[grade_names.Length - 1];
        }
    }

}