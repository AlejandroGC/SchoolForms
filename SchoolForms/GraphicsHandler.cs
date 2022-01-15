using System.Data;

namespace SchoolForms
{
    public class GraphicsHandler
    {
        int _idxColumnLabels = -1;
        int _idxColumnValues = -1;
        string[] _labels     = { };
        double[] _positions  = { };
        double[] _values     = { };
        public GraphicsHandler()
        {

        }
        private void getColumnReferences(DataTable dtGraph, string columnNameLabels, string columnNameValues)
        {
            for (int colIdx = 0; colIdx < dtGraph.Columns.Count; colIdx++)
            {
                if (dtGraph.Columns[colIdx].ColumnName == columnNameLabels)
                {
                    _idxColumnLabels = colIdx;
                }
                if (dtGraph.Columns[colIdx].ColumnName == columnNameValues)
                {
                    _idxColumnValues = colIdx;
                }
            }
        }
        /// <summary>
        /// Load DataTable and two column references and sets the corresponding values that will be needed
        /// for the ScottPlot Plugin [Used for Graphics]
        /// </summary>
        /// <param name="dtGraph">DataTable containing the information expected to graphicate</param>
        /// <param name="columnNameLabels">Column that will be used for the labes/names in the Graphs</param>
        /// <param name="columnNameValues">Column that will be used for the raw data to be represented in the Graphs</param>
        /// <returns> status message of the operation upon finalization </returns>
        public string LoadGraphicsData(DataTable dtGraph, string columnNameLabels, string columnNameValues)
        {
            _values    = new double[dtGraph.Rows.Count];
            _positions = new double[dtGraph.Rows.Count];
            _labels    = new string[dtGraph.Rows.Count];
            getColumnReferences(dtGraph, columnNameLabels, columnNameValues);
            for (int rowIdx = 0; rowIdx < dtGraph.Rows.Count; rowIdx++)
            {
                if ((_idxColumnLabels == -1) || (_idxColumnValues == -1))
                {
                    return "Error: One or more of the specified columns was not found";
                }
                _positions[rowIdx] = rowIdx;
                _labels[rowIdx] = (string)dtGraph.Rows[rowIdx].ItemArray[_idxColumnLabels]!;
                _values[rowIdx] = (double)dtGraph.Rows[rowIdx].ItemArray[_idxColumnValues]!;
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
