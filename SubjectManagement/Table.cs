using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace SubjectManagement
{
    // make this out of pure convenience

    /// <summary>
    /// this class provides some interfaces and stuff to interact with a table,
    /// including some stuff like insert, delete, select, the average CRUD stuff
    /// </summary>
    public class Table
    {
        private Dictionary<string, string> _fields;
        private string _name;

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

            // ensure we can work away
            this.Create();
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

        /// <summary>
        /// Used when connect to other place, convenience mainly
        /// </summary>
        public string ConnectionParam
        {
            get { return $"Data Source={this._name}.db"; }
        }

        /// <summary>
        /// this too
        /// </summary>
        public Dictionary<string, string> Fields
        { get { return this._fields; } }

        /// <summary>
        /// setter only because who renames a table?
        /// </summary>
        public string Name
        { get { return this._name; } }

        public void Create()
        {

            if (this._fields is null || this._fields.Count == 0)
            {
                throw new ArgumentException("Invalid fields!");
            }

            List<string> typeList = new List<string>();
            foreach (var pair in this._fields)
            {
                typeList.Add($"{pair.Key} {pair.Value} NOT NULL");
            }
            string typeListString = string.Join(",\n", typeList);

            string createCommandText = $@"CREATE TABLE IF NOT EXISTS {this._name}(
                    {typeListString});";

            using (var connection = new SQLiteConnection(this.ConnectionParam))
            {
                connection.Open();

                var createTableCommand = connection.CreateCommand();
                createTableCommand.CommandText = createCommandText;

                try { createTableCommand.ExecuteNonQuery(); }
                catch (Exception ex)
                {
                    UtilityFunctions.ShowException(ex, createTableCommand.CommandText);
                }

                connection.Close();
            }
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="conditions">list of conditions to remove values</param>
        /// <returns></returns>

        public void Delete(List<string> conditions = null)
        {
            conditions = conditions ?? new List<string>();
            string filter = "";
            if (conditions.Count > 0)
            {
                // need the space because otherwise it's just not gonna work
                filter = " WHERE " + string.Join(" AND ", conditions);
            }
            string deleteCommandText = $"DELETE FROM {this.Name} {filter}";

            using (var connection = new SQLiteConnection(this.ConnectionParam))
            {
                connection.Open();

                var deleteTableCommand = connection.CreateCommand();
                deleteTableCommand.CommandText = deleteCommandText;

                try { deleteTableCommand.ExecuteNonQuery(); }
                catch (Exception ex) {
                    UtilityFunctions.ShowException(ex, deleteCommandText);
                }
                connection.Close();
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
                var insertObjectCommand = connection.CreateCommand();
                string placeholders = string.Join(" , ", this.ColumnPlaceholdersList);
                insertObjectCommand.CommandText = $@"INSERT INTO {this._name} ({fieldNamesConcatenated}) VALUES ({placeholders});";

                for (int i = 0; i < valueList.Count; i++)
                {
                    insertObjectCommand.Parameters.AddWithValue(this.ColumnPlaceholdersList[i], paramValues[i]);
                }

                return insertObjectCommand.CommandText;
            }
        }

        public void Insert(List<object> valueList)
        {
            if (valueList == null || valueList.Count != this._fields.Count)
            {
                throw new ArgumentException("Invalid parameter set");
            }

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
                string placeholders = string.Join(" , ", this.ColumnPlaceholdersList);
                insertObjectCommand.CommandText = $@"INSERT INTO {this._name} ({fieldNamesConcatenated}) VALUES ({placeholders});";

                for (int i = 0; i < valueList.Count; i++)
                {
                    insertObjectCommand.Parameters.AddWithValue(
                        this.ColumnPlaceholdersList[i],
                        valueList[i]);
                }

                try { insertObjectCommand.ExecuteNonQuery(); }
                catch (Exception ex) {
                    UtilityFunctions.ShowException(ex, insertObjectCommand.CommandText);
                }

                connection.Close();
            }
        }

        public void InsertObject<T>(T t) where T : class, new()
        {
            var debug = ObjectFunctions.ObjectPropertyValues<T>(t);
            this.Insert(debug);
        }

        /// <summary>
        /// Return the set of all rows with full values that satisfies the conditions required
        /// </summary>
        /// <param name="conditions">Dictionary with a set of conditions: key for field name, value for condition</param>
        /// <returns>The command to do the select, then we'll actually do it with a void.</returns>

        public List<Dictionary<string, string>> Read(
                    List<string> columns = null,
                    List<string> conditions = null,
                    int limit = -1
                )
        {
            // if no specific column, just get everything
            columns = columns ?? new List<string>() { "*" };

            // if no conditions, just assume anything
            conditions = conditions ?? new List<string>() { };

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

            string filter = "";
            if (conditions.Count > 0)
            {
                // need the space because otherwise it's just not gonna work
                filter = " WHERE " + string.Join(" AND ", conditions);
            }

            if (limit > 0)
            {
                filter += $" LIMIT {limit}";
            }

            string readCommandText = $"SELECT {selector} FROM {this._name} {filter} ";
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>() { };
            using (var connection = new SQLiteConnection(this.ConnectionParam))
            {
                connection.Open();
                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = readCommandText ;

                try
                {
                    var reader = selectCommand.ExecuteReader();
                    int numberOfColumns = this.ColumnNames.Count;
                    while (reader.Read())
                    {
                        Dictionary<string, string> rowObject = new Dictionary<string, string>();
                        for (int i = 0; i < numberOfColumns; i++)
                        {
                            rowObject[UtilityFunctions.IR(this.ColumnNames[i])] = reader.IsDBNull(i) ? null : reader.GetValue(i).ToString();
                        }
                        result.Add(rowObject);

                        // limit = -1 assumes that this won't happen except overflow,
                        // because if your database have like 2 billion
                        // elements, you have other issues

                        if (limit > 0 && result.Count == limit)
                        {
                            break;
                        }
                    }
                }
                catch (Exception ex) { UtilityFunctions.ShowException(ex, readCommandText); }
            }
            return result;
        }

        public List<Dictionary<string, string>> ReadAll(
            List<string> columns = null,
            List<string> conditions = null)
        {
            return Read(columns, conditions, -1) ?? new List<Dictionary<string, string>>();
        }

        public Dictionary<string, string> ReadOne(
            List<string> columns = null,
                    List<string> conditions = null)
        {
            var result = Read(columns, conditions, 1);
            return result.Count > 0 ? result[0] : new Dictionary<string, string>();
        }

        //read object

        public List<T> ReadObject<T>(
            List<string> columns = null,
            List<string> conditions = null,
            int limit = -1
        ) where T : class, new()
        {
            var rows = this.Read(columns, conditions, limit);
            List<T> values = new List<T>();
            try
            {
                foreach (var row in rows)
                {
                    values.Add(ObjectFunctions.DictToObject<T>(ObjectFunctions.AutoConvert(row)));
                }
            }
            catch (Exception ex)
            {
                UtilityFunctions.ShowException(ex);
            }
            return values;
        }

        public T ReadOneObject<T>(
            List<string> columns = null,
            List<string> conditions = null,
            int limit = -1) where T : class, new()
        {
            var rows = ReadObject<T>(columns, conditions, 1);
            return (rows.Count > 0) ? rows[0] : null;
        }

        public List<T> ReadAllObjects<T>(
            List<string> columns = null,
            List<string> conditions = null,
            int limit = -1) where T : class, new()
        {
            return ReadObject<T>(columns, conditions, -1);
        }
    }
}