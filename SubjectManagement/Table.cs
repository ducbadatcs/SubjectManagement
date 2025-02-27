using System.Collections.Generic;
using System.Data.SQLite;


namespace SubjectManagement
{
    // make this out of pure convenience

    /// <summary>
    /// this class provides some interfaces and stuff to interact with a table, 
    /// including some stuff like insert, delete, select, the average CRUD stuff
    /// </summary>
    public class Table
    {
        private string _name;
        private Dictionary<string, string> _fields;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Table Name</param>
        /// <param name="fields">
        /// Table Fields, in the form of a dictionary: with keys as field names, 
        /// values as types + extra conditions (e.g. primary keys)
        /// </param>
        public Table(string name, Dictionary<string, string> fields = null)
        {
            this._name = name;
            this._fields = new Dictionary<string, string>() { };

            // consistency is key

            fields = fields ?? new Dictionary<string, string>() { };

            foreach (KeyValuePair<string, string> pair in fields)
            {
                this._fields[pair.Key.ToUpper()] = pair.Value.ToUpper();
            }
        }

        /// <summary>
        /// Used when connect to other place, convenience mainly
        /// </summary>
        public string ConnectionParam
        {
            get
            {
                return $"Data Source={this._name}.db";
            }
        }

        /// <summary>
        /// setter only because who renames a table?
        /// </summary>
        public string Name
        {
            get { return this._name; }
        }

        /// <summary>
        /// this too
        /// </summary>
        public Dictionary<string, string> Fields
        {
            get { return this._fields; }
        }

        public string CreateCommand
        {
            get
            {
                if (this._fields is null || this._fields.Count == 0)
                {
                    return "";
                }

                List<string> typeList = new List<string>() { };

                foreach (KeyValuePair<string, string> pair in this._fields)
                {
                    typeList.Add(pair.Key + " " + pair.Value + " NOT NULL ");
                }

                string typeListString = string.Join(",\n", typeList);

                return $@"CREATE TABLE IF NOT EXISTS {this._name}(
                    {typeListString}
                );";
            }
        }

        public void Create()
        {
            using (var connection = new SQLiteConnection(this.ConnectionParam))
            {
                connection.Open();

                var createTableCommand = connection.CreateCommand();
                createTableCommand.CommandText = this.CreateCommand;
                createTableCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<string> ColumnNames
        {
            get
            {
                List<string> columnNames = new List<string>();
                foreach (string key in this._fields.Keys)
                {
                    columnNames.Add(key);
                }
                return columnNames;
            }
        }

        public List<string> ColumnPlaceholdersList
        {
            get
            {
                List<string> valuePlaceholdersList = new List<string>();
                foreach (string key in this._fields.Keys)
                {
                    valuePlaceholdersList.Add("$" + key.ToLower());
                }

                return valuePlaceholdersList;
            }
        }

        public string InsertCommand(List<object> valueList)
        {
            if (valueList == null || valueList.Count != this._fields.Count)
            {
                return "";
            }

            List<string> columnNames = this.ColumnNames;

            List<string> paramValues = new List<string>();
            foreach (object value in valueList)
            {
                paramValues.Add(value.ToString());
            }

            string fieldNamesConcatenated = string.Join(", ", this._fields.Keys);

            using (var connection = new SQLiteConnection(this.ConnectionParam))
            {
                connection.Open();

                var insertObjectCommand = connection.CreateCommand();
                insertObjectCommand.CommandText = $@"INSERT OR REPLACE INTO {this._name}({fieldNamesConcatenated}) VALUES ({this.ColumnPlaceholdersList});"; ;

                for (int i = 0; i < valueList.Count; i++)
                {
                    insertObjectCommand.Parameters.AddWithValue(columnNames[i], paramValues[i]);
                }
                connection.Close();
                return insertObjectCommand.CommandText;
            }
        }

        public void Insert(List<object> valueList)
        {
            using (var connection = new SQLiteConnection(this.ConnectionParam))
            {
                connection.Open();

                var insertObjectCommand = connection.CreateCommand();
                insertObjectCommand.CommandText = this.InsertCommand(valueList);

                insertObjectCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        /// <summary>
        /// don't need a method to generate a string for this one
        /// </summary>
        public void ClearTable()
        {
            using (var connection = new SQLiteConnection(this.ConnectionParam))
            {
                connection.Open();

                var clearTableCommand = connection.CreateCommand();
                clearTableCommand.CommandText = $"DELETE FROM {this._name}; VACUUM";

                clearTableCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Return the set of all rows with full values that satisfies the conditions required
        /// </summary>
        /// <param name="conditions">Dictionary with a set of conditions: key for field name, value for condition</param>
        /// <returns>The command to do the select, then we'll actually do it with a void.</returns>
        public string SelectCommand(
            List<string> columns = null,
            Dictionary<string, string> conditions = null)
        {
            // filter out outlier columns
            foreach (string columnName in conditions.Keys)
            {
                if (!this._fields.ContainsKey(columnName))
                {
                    throw new System.Exception($"Invalid column: {columnName}");
                    return "";
                }
            }

            columns = columns ?? new List<string>() { "*" };
            conditions = conditions ?? new Dictionary<string, string>() { };

            // if we already have "*", why do we need anything else?

            string selector = "";
            if (columns.Contains("*"))
            {
                selector = "*";
            }
            else
            {
                selector = "(" + string.Join(",", columns) + ")";
            }

            List<string> fullConditions = new List<string>();
            foreach (KeyValuePair<string, string> condition in conditions)
            {
                fullConditions.Add(condition.Key + " " + condition.Value);
            }

            string filter = "";
            if (fullConditions.Count > 0)
            {
                // need the space because otherwise it's just not gonna work
                filter = " WHERE " + string.Join(" AND ", fullConditions);
            }

            return $"SELECT {selector} FROM {this._name} {filter}";
        }

        public void Select(List<string> columns = null,
            Dictionary<string, string> conditions = null)
        {
            using (var connection = new SQLiteConnection(this.ConnectionParam))
            {
                connection.Open();

                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = this.SelectCommand(columns, conditions);

                selectCommand.ExecuteNonQuery();
                connection.Clone();
            }
        }
    }
}
