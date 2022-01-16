using System.Data;

namespace SchoolForms
{
    public class DataHandler
    {
        int _idxColumnLabels;
        int _idxColumnValues;
        string[] _labels;
        double[] _positions;
        double[] _values;
        DataTable _dtGraph;
        public DataHandler(DataTable dtGraph, string columnNameLabels, string columnNameValues)
        {
            _dtGraph = dtGraph;
            _labels    = Array.Empty<string>();
            _positions = Array.Empty<double>();
            _values    = Array.Empty<double>();
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
        /// <param name="_dtGraph">DataTable containing the information expected to graphicate</param>
        /// <param name="columnNameLabels">Column that will be used for the labes/names in the Graphs</param>
        /// <param name="columnNameValues">Column that will be used for the raw data to be represented in the Graphs</param>
        /// <returns> status message of the operation upon finalization </returns>
        public string LoadGraphicsData()
        {
            _values    = new double[_dtGraph.Rows.Count];
            _positions = new double[_dtGraph.Rows.Count];
            _labels    = new string[_dtGraph.Rows.Count];
            for (int rowIdx = 0; rowIdx < _dtGraph.Rows.Count; rowIdx++)
            {
                if ((_idxColumnLabels == -1) || (_idxColumnValues == -1))
                {
                    return "Error: One or more of the specified columns was not found";
                }
                _positions[rowIdx] = rowIdx;
                _labels[rowIdx] = (string)_dtGraph.Rows[rowIdx].ItemArray[_idxColumnLabels]!;
                _values[rowIdx] = (double)_dtGraph.Rows[rowIdx].ItemArray[_idxColumnValues]!;
            }
            return "Success";
        }

        public string getBestStudentsName()
        {
            for (int rowIdx = 0; rowIdx < _dtGraph.Rows.Count; rowIdx++)
            {
                if ((_idxColumnLabels == -1) || (_idxColumnValues == -1))
                {
                    return "Error: One or more of the specified columns was not found";
                }

            }
            return "Success";
        }
        /// <summary>
        /// getter for array _values required for the ScottPlot Plugin [Used for Graphics]
        /// </summary>
        /// <returns>double[] _values array</returns>
        public double[] getGraphValues() { return _values; }
        /// <summary>
        /// getter for _labels array required for the ScottPlot Plugin [Used for Graphics]
        /// </summary>
        /// <returns>string[] _labels array</returns>
        public string[] getGraphLabels() { return _labels; }
        /// <summary>
        /// getter for _positions array required for the ScottPlot Plugin [Used for Graphics]
        /// </summary>
        /// <returns>double[] _positions array</returns>
        public double[] getGraphPositions() { return _positions; }
    }
}
