namespace Advent2021.Extensions
{
    public static class StringExtensions
    {
        public static List<string> ToStringList(this string s, string seperator = " ", bool multiLineGrouping = false)
        {
            List<string> results = new List<string>();

            string multiLine = "";
            using (StringReader reader = new StringReader(s))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (multiLineGrouping)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            if (!string.IsNullOrWhiteSpace(multiLine))
                            {
                                multiLine = string.Concat(multiLine, seperator, line);
                            }
                            else
                            {
                                multiLine = line;
                            }
                        }
                        else
                        {
                            results.Add(multiLine);
                            multiLine = null;
                        }
                    }
                    else
                    {
                        results.Add(line);
                    }
                }

                if (!string.IsNullOrWhiteSpace(multiLine))
                {
                    results.Add(multiLine);
                    multiLine = null;
                }
            }

            return results.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }

        public static List<KeyValuePair<string, string>> GetKeyValues(this string s, string seperator = " ", string keyValueSeperator = ":")
        {
            List<KeyValuePair<string, string>> results = new List<KeyValuePair<string, string>>();

            var kvsStrings = s.Split(seperator);

            foreach (var kvsString in kvsStrings)
            {
                var kvs = kvsString.Split(keyValueSeperator);
                results.Add(new KeyValuePair<string, string>(kvs[0], kvs[1]));
            }

            return results;
        }

        public static List<T> ToObjectList<T>(this string s, string seperator = " ", string keyValueSeperator = ":", bool multiLineGrouping = false) where T : class, new()
        {
            var results = new List<T>();

            var lines = s.ToStringList(seperator, multiLineGrouping);
            foreach (var line in lines)
            {
                var obj = line.GetKeyValues(seperator, keyValueSeperator).KeyValuesToClass<T>();
                results.Add(obj);
            }

            return results;
        }

        public static T KeyValuesToClass<T>(this List<KeyValuePair<string, string>> keyValuePairs) where T : class, new()
        {
            T result = new T();

            foreach (var prop in typeof(T).GetProperties())
            {
                object value = keyValuePairs.FirstOrDefault(x => x.Key.Equals(prop.Name)).Value ?? null;

                if (prop.PropertyType == typeof(string)) { }
                else if (prop.PropertyType == typeof(int))
                {
                    value = Convert.ToInt32(value);
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    value = value?.ToString() == "1" || value?.ToString().ToLower() == "true";
                }
                else
                {
                    throw new Exception($"{prop.PropertyType} not implemented for KeyValuesToClass");
                }

                prop.SetValue(result, value);
            }

            return result;
        }
    }
}