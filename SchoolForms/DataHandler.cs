using System.Data;

namespace SchoolForms
{
    public class DataHandler
    {
        int _idxColumnLabels;
        int _idxColumnValues;
        string keyGenAlphabet = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        string[]  _labels;
        double[]  _positions;
        double[]  _values;
        DataTable _dtGraph;
        enum KeyGenColumn
        {
            Undefined = -1,
            Nombre = 0,
            ApellidoMaterno = 1,
            FechaNacimiento = 2
        }
        /// <summary>
        /// Constructor used to load general purpose values for both the generation of Graphs and for the analysis of Data
        /// </summary>
        /// <param name="_dtGraph">DataTable containing the information expected to graphicate</param>
        /// <param name="columnNameLabels">Column that will be used for the labes/names in the Graphs</param>
        /// <param name="columnNameValues">Column that will be used for the raw data to be represented in the Graphs</param>
        public DataHandler(DataTable dtGraph, string columnNameLabels, string columnNameValues)
        {
            _dtGraph   = dtGraph;
            _values    = new double[_dtGraph.Rows.Count];
            _positions = new double[_dtGraph.Rows.Count];
            _labels    = new string[_dtGraph.Rows.Count];
            _idxColumnLabels = -1;
            _idxColumnValues = -1;

            for (int colIdx = 0; colIdx < _dtGraph.Columns.Count; colIdx++)
            {
                if (_dtGraph.Columns[colIdx].ColumnName == columnNameLabels)
                {
                    _idxColumnLabels = colIdx;
                }
                if (_dtGraph.Columns[colIdx].ColumnName == columnNameValues)
                {
                    _idxColumnValues = colIdx;
                }
            }
        }

        /// <summary>
        /// Load DataTable and two column references and sets the corresponding values that will be needed
        /// for the ScottPlot Plugin [Used for Graphics]
        /// </summary>
        /// <returns> status message of the operation upon finalization </returns>
        public string LoadGraphicsData()
        {
            if ((_idxColumnLabels == -1) || (_idxColumnValues == -1))
            {
                return "Error: One or more of the specified columns was not found";
            }
            for (int rowIdx = 0; rowIdx < _dtGraph.Rows.Count; rowIdx++)
            {
                _positions[rowIdx] = rowIdx;
                _labels[rowIdx]    = (string)_dtGraph.Rows[rowIdx].ItemArray[_idxColumnLabels]!;
                _values[rowIdx]    = (double)_dtGraph.Rows[rowIdx].ItemArray[_idxColumnValues]!;
            }
            return "Success";
        }
        public string GetBestStudentName(string[] fullNameColumns)
        {
            double highestValue = 0;
            double currentRowValue;
            string bestStudent = "";
            int[] idxFullNameColumns;
            idxFullNameColumns = FindColumnIndexes(fullNameColumns);
            for (int rowIdx = 0; rowIdx < _dtGraph.Rows.Count; rowIdx++)
            {
                currentRowValue = (double)_dtGraph.Rows[rowIdx].ItemArray[_idxColumnValues]!;
                if (highestValue < currentRowValue)
                {
                    highestValue = currentRowValue;
                    bestStudent = "";
                    for (int i = 0; i < idxFullNameColumns.Length; i++)
                    {
                        bestStudent += (string)_dtGraph.Rows[rowIdx].ItemArray[idxFullNameColumns[i]]!+" ";
                    }
                }
            }
            return bestStudent;
        }
        public string GetWorstStudentName(string[] fullNameColumns)
        {
            double lowestValue = 999;
            double currentRowValue;
            string worstStudent = "";
            int[] idxFullNameColumns;
            idxFullNameColumns = FindColumnIndexes(fullNameColumns);
            for (int rowIdx = 0; rowIdx < _dtGraph.Rows.Count; rowIdx++)
            {
                currentRowValue = (double)_dtGraph.Rows[rowIdx].ItemArray[_idxColumnValues]!;
                if (lowestValue > currentRowValue)
                {
                    lowestValue = currentRowValue;
                    worstStudent = "";
                    for (int i = 0; i < idxFullNameColumns.Length; i++)
                    {
                        worstStudent += " " + (string)_dtGraph.Rows[rowIdx].ItemArray[idxFullNameColumns[i]]!;
                    }
                }
            }
            return worstStudent;
        }
        public double GetValuesAverage()
        {
            double summatoryValues = 0;
            for (int rowIdx = 0; rowIdx < _dtGraph.Rows.Count; rowIdx++)
            {
                summatoryValues += (double)_dtGraph.Rows[rowIdx].ItemArray[_idxColumnValues]!;
            }
            return ( summatoryValues / _dtGraph.Rows.Count );
        }
        public string GetKeyGenValues(DataRow Row, string[] keyGenColumns, int shiftValue)
        {
            int[] idxKeyGenColumns;
            string encodedResult = "";
            idxKeyGenColumns = FindColumnIndexes(keyGenColumns);
            string name         = (string) Row.ItemArray[ idxKeyGenColumns[ (int) KeyGenColumn.Nombre] ]!;
            string mthrLastName = (string) Row.ItemArray[ idxKeyGenColumns[ (int) KeyGenColumn.ApellidoMaterno] ]!;
            string birthDate    = (string) Row.ItemArray[ idxKeyGenColumns[ (int) KeyGenColumn.FechaNacimiento] ]!;

            encodedResult += getEncodedLetter(name.Substring(0, 1), shiftValue);
            encodedResult += getEncodedLetter(name.Substring(1, 1), shiftValue);
            encodedResult += getEncodedLetter(mthrLastName.Substring(mthrLastName.Length - 2, 1), shiftValue);
            encodedResult += getEncodedLetter(mthrLastName.Substring(mthrLastName.Length - 1, 1), shiftValue);
            encodedResult += getAge(birthDate);
            return encodedResult;
        }
        /// <summary>
        /// getter for array _values required for the ScottPlot Plugin [Used for Graphics]
        /// </summary>
        /// <returns>double[] _values array</returns>
        public double[] GetGraphValues() { return _values; }
        /// <summary>
        /// getter for _labels array required for the ScottPlot Plugin [Used for Graphics]
        /// </summary>
        /// <returns>string[] _labels array</returns>
        public string[] GetGraphLabels() { return _labels; }
        /// <summary>
        /// getter for _positions array required for the ScottPlot Plugin [Used for Graphics]
        /// </summary>
        /// <returns>double[] _positions array</returns>
        public double[] GetGraphPositions() { return _positions; }
        private int[] FindColumnIndexes(string[] fullNameColumns)
        {
            int[] idxFullNameColumns = new int[fullNameColumns.Length];
            for (int colIdx = 0; colIdx < _dtGraph.Columns.Count; colIdx++)
            {
                for (int i = 0; i < fullNameColumns.Length; i++)
                {
                    if (fullNameColumns[i] == _dtGraph.Columns[colIdx].ColumnName)
                    {
                        idxFullNameColumns[i] = colIdx;
                    }
                }
            }
            return idxFullNameColumns;
        }
        private string getEncodedLetter(string letter, int shiftValue)
        {
            for (int i = 0; i < keyGenAlphabet.Length; i++)
            {
                if (letter.ToUpper() == keyGenAlphabet.Substring(i, 1))
                {
                    shiftValue = ((i - shiftValue) + keyGenAlphabet.Length) % keyGenAlphabet.Length;
                }
            }
            return keyGenAlphabet.Substring(shiftValue, 1);
        }
        private string getAge(string birthDate)
        {
            DateTime bday = DateTime.Parse(birthDate);
            return Math.Floor((DateTime.Now - bday).TotalDays / 365).ToString();
        }
    }
}
