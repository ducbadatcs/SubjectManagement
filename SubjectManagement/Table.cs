using System.Collections.Generic;
using System.Data.SQLite;
namespace SubjectManagement
{
    // make this out of pure convenience
    public class Table
    {
        private string _name;
        private Dictionary<string, string> _fields;

        public Table(string name, Dictionary<string, string> fields = null)
        {
            this._name = name;
            this._fields = new Dictionary<string, string>() { };

            // consistency is key

            if (!(fields is null))
            {
                foreach (KeyValuePair<string, string> pair in fields)
                {
                    this._fields[pair.Key.ToUpper()] = pair.Value.ToUpper();
                }
            }

        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public Dictionary<string, string> Fields
        {
            get { return this._fields; }
            set { this._fields = value; }
        }

        public string CreateTableCommand
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

        public string InsertIntoTableCommand
        {
            get
            {
                // whatever, it's basically a collection of strings anyway
                var keys = this._fields.Keys;

                string valuePlaceholders = string.Join(", ", this.ColumnPlaceholdersList);

                // having double quotes in a formatted string, 500 IQ move
                string fieldNamesConcatenated = string.Join(", ", this._fields.Keys);
                return $@"INSERT OR REPLACE INTO {this._name}({fieldNamesConcatenated}) VALUES ({this.ColumnPlaceholdersList});";
            }
        }

        public string ClearTableCommand
        {
            get
            {
                return $"DELETE FROM {this._name}; VACUUM";
            }
        }

        public string InsertObjectCommand(List<object> valueList)
        {
            if (valueList == null || valueList.Count != this._fields.Count)
            {
                return "";
            }
            List<string> paramValues = new List<string>();
            foreach (object value in valueList)
            {
                paramValues.Add(value.ToString());
            }

            using (var connection = new SQLiteConnection($"Data Source={this.Name}.db"))
            {
                connection.Open();
                var insertObjectCommand = connection.CreateCommand();
                for (int i = 0;)

                    connection.Close();
            }
        }

    }
}
