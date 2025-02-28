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

        public string CreateCommand
        {
            get
            {
                if (this._fields is null || this._fields.Count == 0)
                {
                    return "";
                }

                StringBuilder typeListBuilder = new StringBuilder();
                foreach (var pair in this._fields)
                {
                    typeListBuilder.AppendLine($"{pair.Key} {pair.Value} NOT NULL,");
                }
                string typeListString = typeListBuilder.ToString().TrimEnd(',');

                return $@"CREATE TABLE IF NOT EXISTS {this._name}(
                    {typeListString}
                );";
            }
        }

        /// <summary>
        /// this too
        /// </summary>
        public Dictionary<string, string> Fields { get { return this._fields; } }

        /// <summary>
        /// setter only because who renames a table?
        /// </summary>
        public string Name { get { return this._name; } }

        public void Create()
        {
            using (var connection = new SQLiteConnection(this.ConnectionParam))
            {
                connection.Open();

                var createTableCommand = connection.CreateCommand();
                createTableCommand.CommandText = this.CreateCommand;
                try { createTableCommand.ExecuteNonQuery(); }
                catch (Exception ex) { throw new SQLiteException(ex.Message); }

                connection.Close();
            }
        }

        public void Delete(List<string> conditions = null)
        {
            using (var connection = new SQLiteConnection(this.ConnectionParam))
            {
                connection.Open();

                var clearTableCommand = connection.CreateCommand();
                clearTableCommand.CommandText = this.DeleteCommand(conditions);

                try { clearTableCommand.ExecuteNonQuery(); }
                catch (Exception ex) { throw new SQLiteException(ex.ToString()); }
                connection.Close();
            }
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="conditions">list of conditions to remove values</param>
        /// <returns></returns>
        public string DeleteCommand(List<string> conditions = null)
        {
            conditions = conditions ?? new List<string>();
            string filter = "";
            if (conditions.Count > 0)
            {
                // need the space because otherwise it's just not gonna work
                filter = " WHERE " + string.Join(" AND ", conditions);
            }
            return $"DELETE FROM {this.Name} {filter}";
        }



        public void Insert(List<object> valueList)
        {
            using (var connection = new SQLiteConnection(this.ConnectionParam))
            {
                connection.Open();

                var insertObjectCommand = connection.CreateCommand();
                insertObjectCommand.CommandText = this.InsertCommand(valueList);

                try { insertObjectCommand.ExecuteNonQuery(); }
                catch (Exception ex) { throw new SQLiteException(ex.ToString()); }

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
                string placeholders = string.Join(", ", this.ColumnPlaceholdersList);
                insertObjectCommand.CommandText = $@"INSERT INTO {this._name} ({fieldNamesConcatenated}) VALUES ({placeholders});";

                for (int i = 0; i < valueList.Count; i++)
                {
                    insertObjectCommand.Parameters.AddWithValue(columnNames[i], paramValues[i]);
                }

                return insertObjectCommand.CommandText;
            }
        }

        /// <summary>
        /// Return the set of all rows with full values that satisfies the conditions required
        /// </summary>
        /// <param name="conditions">Dictionary with a set of conditions: key for field name, value for condition</param>
        /// <returns>The command to do the select, then we'll actually do it with a void.</returns>
        public string SelectCommand(
            List<string> columns = null,
            List<string> conditions = null,
            int limit = -1
        )
        {
            // filter out outlier columns
            foreach (string columnName in conditions)
            {
                if (!this._fields.ContainsKey(columnName))
                {
                    throw new System.ArgumentException($"Invalid column: {columnName}");
                }
            }

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

            if (limit >= 0)
            {
                filter += $" LIMIT {limit}";
            }

            return $"SELECT {selector} FROM {this._name} {filter} ";
        }

        public List<Dictionary<string, string>> Select(
                    List<string> columns = null,
                    List<string> conditions = null,
                    int limit = -1
                )
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>() { };
            using (var connection = new SQLiteConnection(this.ConnectionParam))
            {
                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = this.SelectCommand(columns, conditions, limit);

                try
                {
                    var reader = selectCommand.ExecuteReader();
                    int numberOfColumns = this.ColumnNames.Count;
                    while (reader.Read())
                    {
                        Dictionary<string, string> rowObject = new Dictionary<string, string>();
                        for (int i = 0; i < numberOfColumns; i++)
                        {
                            rowObject[
                                UtilityFunctions.ConvertSnakeCaseToPascalCase(this.ColumnNames[i])
                                ] = reader.IsDBNull(i) ? null : reader.GetString(i);
                        }
                        result.Add(rowObject);
                    }
                }
                catch (Exception ex) { throw new SQLiteException(ex.ToString()); }
            }
            return result;
        }


    }
}